using System;

namespace DocsVision.Monitoring.DataModel
{
	public class Session : BaseEntity<Guid>
	{
		public Guid UserID { get; set; }

		public Guid AppID { get; set; }

		public int LocaleID { get; set; }

		public DateTime LoginTime { get; set; }

		public DateTime LastAccessTime { get; set; }

		public string ComputerName { get; set; }

		public string ComputerAddress { get; set; }

		public int ClientVersion { get; set; }

		public string ServerName { get; set; }

		public bool Offline { get; set; }

		public virtual User SessionUser { get; set; }
	}
}