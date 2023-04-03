using Finance.Data;
using Finance.Shared.Common;
using Finance.Shared.Models.Codes.VATCodes;
using Finance.Shared.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataVatCode = Finance.Data.Codes.VATCode;

namespace Finance.Business.Codes
{
    public class VATCode
    {
        public void Get(OperationRequest<GetFilter> request, ref OperationResponse<List<VatCodeModel>> response)
        {
            if (!Validation.ValidateContext(request, response))
                return;

            response.ReturnValue = new DataVatCode()
                .Get(request.Context, request.InputValue)
                .Select(c => new VatCodeModel
                {
                    Id = c.Id,
                    VATCode = c.VATCode,
                    VATCodeDescription = c.VATCodeDescription,
                    Active = c.Active
                })
                .ToList();
        }

        public void Update(OperationRequest<List<VatCodeEditModel>> request, ref OperationResponse<Null> response)
        {
            if (!Validation.ValidateContext(request, response))
                return;
            else if (!request.InputValue.All(m => ValidateUpdateModel(m)))
                response.SetMessage("Invalid code(s)");
            else
            {
                List<string> errors = new List<string>();
                foreach (VatCodeEditModel code in request.InputValue)
                {
                    if (new DataVatCode().CodeExists(request.Context, code.VATCode, code.Id))
                    {
                        tVATCode errorCode = new DataVatCode().GetById(request.Context, code.Id);
                        errors.Add(String.Format("{0} -> {1} - Code Exists!", errorCode.VATCode, code.VATCode));
                    }
                }

                if (errors.Count > 0)
                    response.SetMessage(string.Join("\n", errors));
                else
                    new DataVatCode().Update(request, ref response);
            }
        }

        private bool ValidateUpdateModel(VatCodeEditModel code)
        {
            if (!Validation.ValidateLong(code.Id))
                return false;

            VATCodeValidation codeValid = new VATCodeValidation()
            {
                vatCode = code.VATCode,
                vatCodeDescription = code.VATCodeDescription
            };

            ValidationContext validateContext = new ValidationContext(codeValid);
            return Validator.TryValidateObject(codeValid, validateContext, new List<ValidationResult>());
        }
    }
}
