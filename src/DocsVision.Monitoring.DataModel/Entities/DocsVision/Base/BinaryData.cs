using System;

namespace DocsVision.Monitoring.DataModel
{
	public class BinaryData
	{
		public Guid ID { get; set; }

		public byte[] FullTextTimeStamp { get; set; }

		public string Type { get; set; }

		public byte[] Data { get; set; }

		public byte[] StreamData { get; set; }
	}
}