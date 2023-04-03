using Finance.ConsoleApp.FinanceService;
using Finance.Shared.Common;
using Finance.Shared.Models.Codes.VATCodes;
using Finance.Shared.Models.Shared;
using System;
using System.Linq;

namespace Finance.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            VatCodesClient client = new VatCodesClient();

            RequestContext context = new RequestContext
            {
                CompanyId = 3,
                LACode = "101",
                SchoolCode = "6706"
            };

            GetVatCodesRequest getRequest = new GetVatCodesRequest(new OperationRequest<GetFilter>
            {
                Context = context,
                InputValue = new GetFilter
                {
                    StartRecord = 2,
                    MaxRecords = 2
                }
            });

            GetVatCodesResponse getResponse = client.GetVatCodes(getRequest);
            if (getResponse.GetVatCodesResult.HasError || getResponse.GetVatCodesResult.HasWarning)
            {
                Console.WriteLine("Get request failed with: " + getResponse.GetVatCodesResult.Message);
                return;
            }

            Console.WriteLine("Get returned {0} entities", getResponse.GetVatCodesResult.ReturnValue.Length);

            VatCodeModel vatCode = getResponse.GetVatCodesResult.ReturnValue.First();
            UpdateVatCodesRequest updateRequest = new UpdateVatCodesRequest(
                new OperationRequest<VatCodeEditModel[]>()
                {
                    Context = context,
                    InputValue = new[]
                    {
                        new VatCodeEditModel
                        {
                            Id = vatCode.Id,
                            VATCode = vatCode.VATCode,
                            VATCodeDescription = vatCode.VATCodeDescription.Substring(0, Math.Min(10, vatCode.VATCodeDescription.Length-1)) + DateTime.Now.Ticks.ToString()
                        }
                    }
                });


            UpdateVatCodesResponse response = client.UpdateVatCodes(updateRequest);
            Console.WriteLine("Update affected {0} entities.", response.UpdateVatCodesResult.RowsAffected);

            Console.ReadLine();
        }
    }
}
