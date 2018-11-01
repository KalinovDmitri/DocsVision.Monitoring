using System;

namespace DocsVision.Monitoring.Options
{
	public class SmtpOptions
	{
		public string HostName { get; set; }

		public int Port { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string Sender { get; set; }
	}
}