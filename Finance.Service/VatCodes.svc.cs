using Finance.Business.Codes;
using Finance.Entities.AutoEnum;
using Finance.Shared.Common;
using Finance.Shared.Models.Codes.VATCodes;
using Finance.Shared.Models.Shared;
using System.Collections.Generic;

namespace Finance.Service
{
    public class VatCodes : ServiceBase, IVatCodes
    {
        public OperationResponse<List<VatCodeModel>> GetVatCodes(OperationRequest<GetFilter> request)
        {
            var response = new OperationResponse<List<VatCodeModel>>();
            return GetOperationResponse(response, () =>
            {
                if (!HasReadAccess(AccessArea.VatCodes, request.Context))
                    ThrowUnauthorisedException(null, request.Context);

                new VATCode().Get(request, ref response);
            });
        }

        public OperationResponse<Null> UpdateVatCodes(OperationRequest<List<VatCodeEditModel>> request)
        {
            var response = new OperationResponse<Null>();
            return GetOperationResponse(response, () =>
            {
                if (!HasWriteAccess(AccessArea.VatCodes, request.Context))
                    ThrowUnauthorisedException(null, request.Context);

                new VATCode().Update(request, ref response);
            });
        }
    }
}
