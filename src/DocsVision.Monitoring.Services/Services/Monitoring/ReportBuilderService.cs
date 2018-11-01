using System;
using System.Collections.Generic;
using System.Globalization;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.Models;
using DocsVision.Monitoring.Resources;

namespace DocsVision.Monitoring.Services
{
	public class ReportBuilderService : IReportBuilderService
	{
		private CultureInfo _dateCulture;
		private CultureInfo _invariantCulture;

		public ReportBuilderService()
		{
			_dateCulture = new CultureInfo("ru-RU");
			_invariantCulture = CultureInfo.InvariantCulture;
		}

		public DocumentsWithoutShortcutsReport BuildDocumentsWithoutShortcutsReport(List<KindFolderLinkModel> kindFolderLinks, List<DocumentFolderModel> foundedDocuments)
		{
			if (kindFolderLinks == null)
			{
				throw new ArgumentNullException(nameof(kindFolderLinks), "Collection of kind-folder links cannot be null.");
			}
			if (foundedDocuments == null)
			{
				throw new ArgumentNullException(nameof(foundedDocuments), "Collection of founded documents cannot be null.");
			}

			var linksDictionary = ToDictionaryByFolder(kindFolderLinks);

			var reportName = string.Format(_dateCulture, ReportTemplates.DocumentsWithoutShortcutsName, DateTime.Now);
			
			var report = new DocumentsWithoutShortcutsReport
			{
				Name = reportName
			};

			var reportRows = new List<DocumentsWithoutShortcutsReportRow>(5 * foundedDocuments.Count);

			LinkInfo itemLink;

			foreach (var document in foundedDocuments)
			{
				itemLink = linksDictionary[document.FolderID];

				var reportRow = new DocumentsWithoutShortcutsReportRow
				{
					DocumentId = document.DocumentID,
					DocumentName = document.Name,
					DocumentDescription = document.Description,
					DocumentKindName = itemLink.Kinds[document.KindID],
					TargetFolderName = itemLink.FolderName,
					LinkId = itemLink.LinkId,
					ParentReport = report
				};

				reportRows.Add(reportRow);
			}

			report.Rows = reportRows;

			return report;
		}

		private Dictionary<Guid, LinkInfo> ToDictionaryByFolder(List<KindFolderLinkModel> kindFolderLinks)
		{
			var linksDictionary = new Dictionary<Guid, LinkInfo>(5);

			LinkInfo linkInfo;

			foreach (var item in kindFolderLinks)
			{
				if (linksDictionary.TryGetValue(item.FolderID, out linkInfo))
				{
					linkInfo.Kinds[item.KindID] = item.KindName;
				}
				else
				{
					linkInfo = new LinkInfo
					{
						LinkId = item.Id,
						FolderName = item.FolderName,
						Kinds = new Dictionary<Guid, string>
						{
							[item.KindID] = item.KindName
						}
					};
					linksDictionary[item.FolderID] = linkInfo;
				}
			}

			return linksDictionary;
		}

		internal class LinkInfo
		{
			public long LinkId { get; set; }

			public string FolderName { get; set; }

			public Dictionary<Guid, string> Kinds { get; set; }
		}
	}
}