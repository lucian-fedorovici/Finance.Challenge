using Finance.Entities.AutoEnum;
using Finance.Shared.Common;
using Finance.Shared.ErrorLogging;
using System;

namespace Finance.Service
{
    public abstract class ServiceBase
    {
        const string GENERIC_ERROR_MESSAGE = "A problem occurred during the service request...";

        protected OperationResponse<T> GetOperationResponse<T>(OperationResponse<T> response, Action action)
        {
            try
            {
                action();
            }
            catch (FinanceException e)
            {
                response.SetMessage(e.Message, e.Type, e);
                response.AjaxRedirect = e.AjaxRedirect;
            }
            catch (Exception e)
                {
                response.SetMessage(GENERIC_ERROR_MESSAGE, FinanceExceptionType.Exception, e);
            }

            return response;
        }

        public bool HasReadAccess(AccessArea area, RequestContext context)
        {
            /* Code ommitted to reduce complexity. */
            return true;
        }

        public bool HasWriteAccess(AccessArea area, RequestContext context)
        {
            /* Code ommitted to reduce complexity. */
            return true;
        }

        protected void ThrowUnauthorisedException(string action = null, RequestContext context = null, string navigationUrl = null)
        {
            var message = string.IsNullOrEmpty(action) ?
               "You are unauthorised to perform this action." :
               string.Format("You are unauthorised to perform the ({0}) action.", action);

            var ex = new FinanceException(message, FinanceExceptionType.Unauthorised);

            /* Error logging functionality removed to reduce complexity. */

            throw ex;
        }
    }
}