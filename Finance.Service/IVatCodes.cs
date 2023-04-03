using Finance.Shared.Common;
using Finance.Shared.Models.Codes.VATCodes;
using Finance.Shared.Models.Shared;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Finance.Service
{
    [ServiceContract]
    public interface IVatCodes
    {
        [OperationContract]
        OperationResponse<List<VatCodeModel>> GetVatCodes(OperationRequest<GetFilter> request);

        [OperationContract]
        OperationResponse<Null> UpdateVatCodes(OperationRequest<List<VatCodeEditModel>> request);
    }
}
