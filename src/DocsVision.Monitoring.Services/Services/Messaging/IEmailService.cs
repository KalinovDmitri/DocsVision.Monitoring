using System;
using System.Threading;
using System.Threading.Tasks;

using MimeKit;

namespace DocsVision.Monitoring.Services
{
	public interface IEmailService
	{
		Task SendAsync(MimeMessage message, CancellationToken cancellationToken = default(CancellationToken));
	}
}