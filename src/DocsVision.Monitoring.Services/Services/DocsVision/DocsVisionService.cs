using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionService : ApplicationService, IDocsVisionService
	{
		public DocsVisionService(DocsVisionDbContext docsvisionContext) : base(docsvisionContext) { }

		public async Task<EmployeeModel> GetEmployeeAsync(string accountName)
		{
			var userInfo = await _docsvisionContext.Set<User>().AsNoTracking()
				.Where(x => x.AccountName.ToUpper() == accountName.ToUpper())
				.Select(x => new
				{
					x.UserID,
					x.SID
				})
				.FirstOrDefaultAsync();

			if (userInfo != null)
			{
				var employeeInfo = await _docsvisionContext.Set<StaffEmployee>().AsNoTracking()
					.Where(x => x.SysAccountName == accountName.ToLower())
					.Select(x => new
					{
						EmployeeID = x.RowID,
						x.SysAccountName,
						x.DisplayString,
						x.AccountSID
					})
					.FirstOrDefaultAsync();

				if (employeeInfo != null)
				{
					var employeeModel = new EmployeeModel
					{
						AccountName = accountName,
						UserID = userInfo.UserID,
						EmployeeID = employeeInfo.EmployeeID,
						AccountSID = employeeInfo.AccountSID,
						DisplayString = employeeInfo.DisplayString,
						SysAccountName = employeeInfo.SysAccountName
					};
					return employeeModel;
				}
			}

			return null;
		}

		public async Task<List<DocumentFolderModel>> GetDocumentsWithoutShortcutsAsync(List<KindFolderLinkModel> kindFolderLinks, DateTime startTime)
		{
			if (kindFolderLinks == null)
			{
				throw new ArgumentNullException(nameof(kindFolderLinks), "Collection of kind-folder links cannot be null.");
			}
			if (kindFolderLinks.Count == 0)
			{
				return new List<DocumentFolderModel>();
			}

			var documentTasks = new Task<List<DocumentFolderModel>>[kindFolderLinks.Count];

			for (int idx = 0; idx < kindFolderLinks.Count; ++idx)
			{
				var current = kindFolderLinks[idx];

				documentTasks[idx] = GetDocumentsWithoutShortcutsAsync(current.KindID, current.FolderID, startTime);
			}

			var documentsWithoutShortcuts = await Task.WhenAll(documentTasks);

			var foundedDocuments = documentsWithoutShortcuts
				.Where(x => x.Count > 0)
				.SelectMany(x => x)
				.ToList();

			return foundedDocuments;
		}

		public async Task<List<DocumentFolderModel>> GetDocumentsWithoutShortcutsAsync(Guid kindID, Guid folderID, DateTime startTime)
		{
			var documentsQuery = _docsvisionContext.Set<Document>().AsNoTracking()
				.Where(x =>
					x.System.Kind == kindID
					&& x.Dates.CreationDateTime >= startTime);

			var shortcutsQuery = _docsvisionContext.Set<Shortcut>().AsNoTracking();

			var resultQuery = from doc in documentsQuery
							  where !shortcutsQuery.Any(x => doc.InstanceID == x.CardID && x.ParentRowID == folderID)
							  select new DocumentFolderModel
							  {
								  DocumentID = doc.InstanceID,
								  Name = doc.MainInfo.Name,
								  Description = doc.Description,
								  KindID = kindID,
								  FolderID = folderID
							  };

			var documentsWithoutShortcuts = await resultQuery.ToListAsync();
			return documentsWithoutShortcuts;
		}
	}
}