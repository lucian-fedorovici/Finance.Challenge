using Finance.Shared.Common;
using Finance.Shared.Models.Codes.VATCodes;
using Finance.Shared.Models.Shared;
using System.Collections.Generic;
using System.Linq;

namespace Finance.Data.Codes
{
    public class VATCode : DataBase
    {
        public tVATCode GetById(RequestContext context, long id)
        {
            using (Context)
            {
                return Context.tVATCode.First(c =>
                    c.CompanyId == context.CompanyId &&
                    c.LACode == context.LACode &&
                    c.SchoolCode == context.SchoolCode &&
                    c.Id == id);
            }
        }

        public List<tVATCode> Get(RequestContext context, GetFilter filter)
        {
            using (Context)
            {
                return Context.tVATCode
                    .Where(c =>
                        c.CompanyId == context.CompanyId &&
                        c.LACode == context.LACode &&
                        c.SchoolCode == context.SchoolCode)
                    .OrderBy(c => c.Id)
                    .Skip(filter.StartRecord)
                    .Take(filter.MaxRecords)
                    .ToList();
            }
        }

        public void Update(OperationRequest<List<VatCodeEditModel>> request, ref OperationResponse<Null> response)
        {
            using (Context)
            {
                RequestContext context = request.Context;
                IEnumerable<long> ids = request.InputValue.Select(m => m.Id);

                foreach (tVATCode code in Context.tVATCode.Where(c =>
                    c.CompanyId == context.CompanyId &&
                    c.LACode == context.LACode &&
                    c.SchoolCode == context.SchoolCode &&
                    ids.Contains(c.Id)))
                {
                    VatCodeEditModel model = request.InputValue.First(v => v.Id == code.Id);
                    code.VATCode = model.VATCode.ToUpper();
                    code.VATCodeDescription = model.VATCodeDescription;
                }

                response.RowsAffected = SaveChanges(request.Context);
            }
        }

        public bool CodeExists(RequestContext context, string vatCode, long? id = null)
        {
            using (Context)
            {
                return Context.tVATCode.Any(c =>
                    c.CompanyId == context.CompanyId &&
                    c.LACode == context.LACode &&
                    c.SchoolCode == context.SchoolCode &&
                    c.VATCode.ToUpper() == vatCode.ToUpper() &&
                    (id == null || c.Id != id.Value));
            }
        }
    }
}
