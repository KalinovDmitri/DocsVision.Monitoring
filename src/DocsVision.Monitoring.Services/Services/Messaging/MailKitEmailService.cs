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

		private InternetAddress _senderAddress;
		private SmtpClient _smtpClient;

		public MailKitEmailService(IOptions<SmtpOptions> smtpOptions)
		{
			_smtpOptions = smtpOptions.Value;

			_senderAddress = MailboxAddress.Parse(_smtpOptions.Sender);
			_smtpClient = new SmtpClient();
		}

		public async Task SendAsync(MimeMessage message, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message), "Mail message cannot be null.");
			}

			if (message.From.Count == 0)
				message.From.Add(_senderAddress);

			if (!_smtpClient.IsConnected)
			{
				await _smtpClient.ConnectAsync(_smtpOptions.HostName, _smtpOptions.Port, cancellationToken: cancellationToken)
								 .ConfigureAwait(false);
			}

			if (!_smtpClient.IsAuthenticated)
			{
				await _smtpClient.AuthenticateAsync(_smtpOptions.UserName, _smtpOptions.Password, cancellationToken)
								 .ConfigureAwait(false);
			}
			
			await _smtpClient.SendAsync(message, cancellationToken)
							 .ConfigureAwait(false);
		}

		void IDisposable.Dispose()
		{
			_smtpClient.Disconnect(true);
			_smtpClient.Dispose();
		}
	}
}