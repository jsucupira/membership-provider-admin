using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Membership.Common.Exceptions;

namespace Membership.Site
{
    public class ControllerActionInvoker : ApiControllerActionInvoker
    {
        public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            Uri uri = actionContext.Request.RequestUri;
            string name = actionContext.Request.RequestUri.AbsolutePath;
            string method = actionContext.Request.Method.ToString();

            try
            {
                Task<HttpResponseMessage> result = base.InvokeActionAsync(actionContext, cancellationToken);

                if (result.Exception != null)
                {
                    Exception baseException = result.Exception.GetBaseException();

                    if (baseException is NotFoundException)
                    {
                        ExceptionBase exceptionBase = baseException as ExceptionBase;
                        HttpResponseMessage responseMessage = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, WebErrorResponse.FromExceptionBase(exceptionBase));
                        responseMessage.ReasonPhrase = "Not Found";
                        return Task.Run(() => responseMessage, cancellationToken);
                    }
                    else if (baseException is ExceptionBase)
                    {
                        ExceptionBase exceptionBase = baseException as ExceptionBase;
                        HttpResponseMessage responseMessage = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, WebErrorResponse.FromExceptionBase(exceptionBase));
                        responseMessage.ReasonPhrase = "Bad Request";
                        return Task.Run(() => responseMessage, cancellationToken);
                    }
                    else if (baseException is UnauthorizedAccessException)
                    {
                        HttpResponseMessage responseMessage = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        responseMessage.ReasonPhrase = "Unauthorized";
                        return Task.Run(() => responseMessage, cancellationToken);
                    }
                    else
                    {
                        WebErrorResponse webError = null;
                        webError = new WebErrorResponse(baseException.Message.Replace(Environment.NewLine, ""), "Internal Server Error", null);
                        HttpResponseMessage responseMessage = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError, webError);
                        responseMessage.ReasonPhrase = "Internal Server Error";
                        return Task.Run(() => responseMessage, cancellationToken);
                    }
                }
                return result;
            }
            finally
            {
            }
        }
    }
}