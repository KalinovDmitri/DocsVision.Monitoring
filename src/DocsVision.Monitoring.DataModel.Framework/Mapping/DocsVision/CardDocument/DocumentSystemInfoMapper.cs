using System;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public class DocumentSystemInfoMapper : CardSystemInfoMapper<DocumentSystemInfo>
	{
		public DocumentSystemInfoMapper() : base(CardDocument.System.ID) { }
	}
}