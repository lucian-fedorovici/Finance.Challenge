using System;

namespace Finance.Shared.ErrorLogging
{
    public class FinanceException : Exception
    {
        public string AjaxRedirect { get; set; }
        public string ExceptionMessage { get; set; }
        public FinanceExceptionType Type { get; set; }
        public bool Logged { get; set; }

        public FinanceException(string message, string ajaxRedirect = null) : base(message)
        {
            ExceptionMessage = message;
            Type = FinanceExceptionType.Exception;
            AjaxRedirect = ajaxRedirect;
        }

        public FinanceException(string message, Exception inner, string ajaxRedirect = null) : base(message, inner)
        {
            Type = FinanceExceptionType.Exception;
            AjaxRedirect = ajaxRedirect;
        }

        public FinanceException(string message, FinanceExceptionType type, string ajaxRedirect = null)
            : base(message)
        {
            ExceptionMessage = message;
            Type = type;
            AjaxRedirect = ajaxRedirect;
        }

        public FinanceException(string message, Exception inner, FinanceExceptionType type, string ajaxRedirect = null) : base(message, inner)
        {
            ExceptionMessage = message;
            Type = type;
            AjaxRedirect = ajaxRedirect;
        }

        public FinanceException(string message, FinanceException inner, FinanceExceptionType type, string ajaxRedirect = null) : base(message, inner)
        {
            ExceptionMessage = message;
            Type = type;
            Logged = inner.Logged;
            AjaxRedirect = ajaxRedirect;
        }


    }
}
