using Finance.Shared.ErrorLogging;
using System;

namespace Finance.Shared.Common
{

    [Serializable]
    public class OperationResponse<ReturnValueType>
    {
        public bool HasError { get; set; }
        public bool HasWarning { get; set; }
        public bool Authenticated { get; set; }
        public string AjaxRedirect { get; set; }

        /*
         * If is true means that client wll reloads the current page by himself.
         */
        public bool SelfReload { get; set; }

        public string Message { get; set; }
        public FinanceExceptionType MessageType { get; set; }
        public ReturnValueType ReturnValue { get; set; }
        public int RowsAffected { get; set; }
        public string MessageStackTrace { get; set; }

        public void SetMessage(string message, FinanceExceptionType messageType = FinanceExceptionType.Error, Exception exceptionToBeLogged = null)
        {
            Message = message;
            MessageType = messageType;
            MessageStackTrace = exceptionToBeLogged != null ? exceptionToBeLogged.StackTrace : new System.Diagnostics.StackTrace().ToString();
            HasError = MessageType == FinanceExceptionType.Error || MessageType == FinanceExceptionType.Exception;
            HasWarning = MessageType == FinanceExceptionType.Warning;
            Authenticated = MessageType != FinanceExceptionType.Unauthorised;

            /* Error logging functionality removed to reduce complexity. */ 
        }
    }

    [Serializable]
    public class Null { }
}
