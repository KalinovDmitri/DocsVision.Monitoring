using System;

using DocsVision.Monitoring.DataModel.CardDefs;

namespace DocsVision.Monitoring.DataModel.Mapping
{
	public sealed class DocumentSystemInfoMapper : CardSystemInfoMapper<DocumentSystemInfo>
	{
		public DocumentSystemInfoMapper() : base(CardDocument.System.ID) { }
	}
}