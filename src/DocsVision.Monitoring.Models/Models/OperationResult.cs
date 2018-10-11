using System;
using System.Net;

namespace DocsVision.Monitoring.Models
{
	public abstract class OperationResultBase
	{
		public bool Succeeded { get; internal set; }

		public string ErrorMessage { get; internal set; }

		public HttpStatusCode StatusCode { get; internal set; }

		protected internal OperationResultBase(HttpStatusCode statusCode, bool succeeded)
		{
			StatusCode = statusCode;
			Succeeded = succeeded;
		}

		protected internal OperationResultBase(HttpStatusCode statusCode, string errorMessage) : this(statusCode, false)
		{
			ErrorMessage = errorMessage;
		}
	}

	public class OperationResult : OperationResultBase
	{
		protected internal OperationResult(HttpStatusCode statusCode, bool succeeded) : base(statusCode, succeeded) { }

		protected internal OperationResult(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage) { }

		public static OperationResult Ok()
		{
			return new OperationResult(HttpStatusCode.OK, true);
		}

		public static OperationResult<TModel> Ok<TModel>(TModel data)
		{
			return new OperationResult<TModel>(HttpStatusCode.OK, data);
		}

		public static OperationResult BadRequest(string message)
		{
			return new OperationResult(HttpStatusCode.BadRequest, message);
		}

		public static OperationResult NotFound(string message)
		{
			return new OperationResult(HttpStatusCode.NotFound, message);
		}

		public static OperationResult Error(string message)
		{
			return new OperationResult(HttpStatusCode.InternalServerError, message);
		}
	}

	public class OperationResult<TModel> : OperationResultBase
	{
		public TModel Data { get; internal set; }

		protected internal OperationResult(HttpStatusCode statusCode, bool succeeded) : base(statusCode, succeeded) { }

		protected internal OperationResult(HttpStatusCode statusCode, string errorMessage) : base(statusCode, errorMessage) { }

		protected internal OperationResult(HttpStatusCode statusCode, TModel data) : this(statusCode, true)
		{
			Data = data;
		}

		public static OperationResult<TModel> Ok(TModel data)
		{
			return new OperationResult<TModel>(HttpStatusCode.OK, data);
		}

		public static implicit operator OperationResult<TModel>(OperationResult result)
		{
			return new OperationResult<TModel>(result.StatusCode, result.ErrorMessage)
			{
				Succeeded = result.Succeeded
			};
		}
	}
}