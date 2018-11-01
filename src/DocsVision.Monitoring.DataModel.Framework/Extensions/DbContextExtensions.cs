using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Storage;

namespace Microsoft.EntityFrameworkCore
{
	public static class DbContextExtensions
	{
		public static async Task ExecuteInTransactionAsync<TContext, TParameter>(this TContext context, Action<TContext, TParameter> action, TParameter parameter,
			CancellationToken cancellationToken = default(CancellationToken))
			where TContext : DbContext
			where TParameter : class
		{
			using (var transaction = await context.Database.BeginTransactionAsync(cancellationToken))
			{
				try
				{
					action.Invoke(context, parameter);

					await context.SaveChangesAsync(cancellationToken);

					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
}