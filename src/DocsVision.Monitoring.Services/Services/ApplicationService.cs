using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DocsVision.Monitoring.DataModel.Framework;

namespace DocsVision.Monitoring.Services
{
	public abstract class ApplicationService : IDisposable
	{
		protected readonly DocsVisionDbContext _docsvisionContext;

		protected internal ApplicationService(DocsVisionDbContext docsvisionContext)
		{
			_docsvisionContext = docsvisionContext;
		}

		public void Dispose()
		{
			_docsvisionContext?.Dispose();
		}
	}
}