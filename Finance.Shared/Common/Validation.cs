using Finance.Shared.ErrorLogging;
using System;

namespace Finance.Shared.Common
{
    public static class Validation
    {
        public static bool ValidateLong(long l)
        {
            bool isValidated = (l != 0);
            return isValidated;
        }

        public static bool ValidateContext<T1, T2>(OperationRequest<T1> request, OperationResponse<T2> response)
        {
            if (!ValidateContext(request.Context))
            {
                response.SetMessage("Invalid Common Members");
                return false;
            }

            return true;
        }

        public static bool ValidateContext(RequestContext context)
        {
            try
            {
                if (context == null) return false;
                if (context.CompanyId == 0) return false;
                
                if (String.IsNullOrEmpty(context.LACode) || context.LACode.Length > 10) return false;
                if (String.IsNullOrEmpty(context.SchoolCode) || context.SchoolCode.Length > 10) return false;
                
                return true;
            }
            catch (Exception e)
            {
                throw new FinanceException("Validation has failed against Common Members.", e);
            }
        }
    }
}
