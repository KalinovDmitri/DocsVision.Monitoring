using System;
using System.Threading.Tasks;

using DocsVision.Monitoring.Models;

namespace DocsVision.Monitoring.Services
{
	public interface IDocsVisionService
	{
		Task<EmployeeModel> GetEmployeeAsync(string accountName);
	}
}