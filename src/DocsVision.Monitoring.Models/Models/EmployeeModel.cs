using System;

namespace DocsVision.Monitoring.Models
{
	public class EmployeeModel
	{
		public Guid UserID { get; set; }

		public Guid EmployeeID { get; set; }

		public string AccountName { get; set; }

		public string SysAccountName { get; set; }

		public string AccountSID { get; set; }

		public string DisplayString { get; set; }
	}
}