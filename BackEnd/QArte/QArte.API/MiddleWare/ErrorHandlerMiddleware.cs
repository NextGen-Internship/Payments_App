using System;
using QArte.Persistance.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace QArte.API.MiddleWare
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		public ErrorHandlerMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext contex)
		{
			try
			{
				await _next(contex);
			}
			catch(Exception error)
			{
				var response = contex.Response;
				response.ContentType = "application/json";

				switch (error)
				{
					case AppException e:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					case UnauthorizedAccessException e:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					case KeyNotFoundException e:
						response.StatusCode = (int)HttpStatusCode.NotFound;
						break;
					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}
				var result = JsonSerializer.Serialize(new { message = error?.Message });
				await response.WriteAsync(result);
			}
		}
	}
}

