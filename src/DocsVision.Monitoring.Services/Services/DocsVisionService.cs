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
			var nowTime = DateTime.Now;

			var documentsQuery = from doc in _docsvisionContext.Set<Document>().AsNoTracking()
								 join dates in _docsvisionContext.Set<BaseCardDates>().AsNoTracking() on doc.Id equals dates.Id
								 join system in _docsvisionContext.Set<DocumentSystemInfo>().AsNoTracking() on doc.Id equals system.InstanceID
								 where
									system.Kind == kindID
									&& EF.Functions.DateDiffSecond(dates.CreationDateTime, nowTime) <= creationSeconds
								 select doc;

			var shortcutsQuery = _docsvisionContext.Set<Shortcut>().AsNoTracking();

			var resultQuery = from doc in documentsQuery
							  where !shortcutsQuery.Any(x => doc.Id == x.CardID && x.ParentRowID == folderID)
							  select new CardFolderModel
							  {
								  CardID = doc.Id,
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