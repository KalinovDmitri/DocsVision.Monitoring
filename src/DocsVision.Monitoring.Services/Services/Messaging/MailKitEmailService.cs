using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using MimeKit;
using MailKit;
using MailKit.Net.Smtp;

using DocsVision.Monitoring.Options;

namespace DocsVision.Monitoring.Services
{
	public class MailKitEmailService : IEmailService
	{
		private readonly SmtpOptions _smtpOptions;

		private SmtpClient _client;

		public MailKitEmailService(IOptions<SmtpOptions> smtpOptions)
		{
			_smtpOptions = smtpOptions.Value;

			_client = new SmtpClient();
		}

		public async Task SendAsync(MimeMessage message, CancellationToken cancellationToken = default(CancellationToken))
		{
			await _client.ConnectAsync(_smtpOptions.HostName, _smtpOptions.Port, cancellationToken: cancellationToken)
						 .ConfigureAwait(false);

			await _client.AuthenticateAsync(_smtpOptions.UserName, _smtpOptions.Password, cancellationToken)
						 .ConfigureAwait(false);

			await _client.SendAsync(message, cancellationToken)
						 .ConfigureAwait(false);

			await _client.DisconnectAsync(true, cancellationToken)
						 .ConfigureAwait(false);
		}
	}
}