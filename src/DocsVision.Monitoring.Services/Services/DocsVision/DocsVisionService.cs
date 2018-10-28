using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DocsVision.Monitoring.DataModel;
using DocsVision.Monitoring.DataModel.Framework;
using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public class DocsVisionService : ApplicationService, IDocsVisionService
	{
		public DocsVisionService(DocsVisionDbContext docsvisionContext) : base(docsvisionContext) { }

		public async Task<EmployeeModel> GetEmployeeAsync(string accountName)
		{
			var userInfo = await _docsvisionContext.Set<User>().AsNoTracking()
				.Where(x => x.AccountName.ToUpper() == accountName.ToUpper())
				.Select(x => new
				{
					UserID = x.Id,
					x.SID
				})
				.FirstOrDefaultAsync();

			if (userInfo != null)
			{
				var employeeInfo = await _docsvisionContext.Set<StaffEmployee>().AsNoTracking()
					.Where(x => x.SysAccountName == accountName.ToLower())
					.Select(x => new
					{
						EmployeeID = x.Id,
						x.SysAccountName,
						x.DisplayString,
						x.AccountSID
					})
					.FirstOrDefaultAsync();

				if (employeeInfo != null)
				{
					var employeeModel = new EmployeeModel
					{
						AccountName = accountName,
						UserID = userInfo.UserID,
						EmployeeID = employeeInfo.EmployeeID,
						AccountSID = employeeInfo.AccountSID,
						DisplayString = employeeInfo.DisplayString,
						SysAccountName = employeeInfo.SysAccountName
					};
					return employeeModel;
				}
			}

			return null;
		}
	}
}