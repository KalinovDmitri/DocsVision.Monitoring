using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionService : IDocsVisionService, IDisposable
	{
		private DocsVisionDbContext _docsvisionContext;

		public DocsVisionService(DocsVisionDbContext docsvisionContext)
		{
			_docsvisionContext = docsvisionContext;
		}

		public async Task<List<CardFolderModel>> GetDocumentsWithoutShortcutsAsync(Guid kindID, Guid folderID, TimeSpan creationSpan)
		{
			var creationSeconds = (int)creationSpan.TotalSeconds;

			var documentsQuery = _docsvisionContext.Set<Document>().AsNoTracking()
				.Include(x => x.Dates)
				.Include(x => x.MainInfo)
				.Include(x => x.System)
				.Where(x =>
					x.System.Kind == kindID
					&& EF.Functions.DateDiffSecond(x.Dates.CreationDateTime, DateTime.Now) <= creationSeconds);
			
			var shortcutsQuery = _docsvisionContext.Set<Shortcut>().AsNoTracking();

			var resultQuery = from doc in documentsQuery
							  where !shortcutsQuery.Any(x => doc.InstanceID == x.CardID && x.ParentRowID == folderID)
							  select new CardFolderModel
							  {
								  CardID = doc.InstanceID,
								  Name = doc.MainInfo.Name,
								  Description = doc.Description,
								  FolderID = folderID
							  };

			var documentsWithoutShortcuts = await resultQuery.ToListAsync();
			return documentsWithoutShortcuts;
		}

		void IDisposable.Dispose()
		{
			_docsvisionContext?.Dispose();
			_docsvisionContext = null;
		}
	}
}