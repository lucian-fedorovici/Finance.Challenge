using Finance.Shared.Common;

namespace Finance.Shared.Models.Codes.VATCodes
{
    public class VatCodeEditModel
    {
        public long Id { get; set; }
        private string _desc;
        private string _code;
        
        public string VATCode
        {
            get
            {
                return Helper.SanitizeString(_code);
            }
            set
            {
                _code = value;
            }
        }

        public string VATCodeDescription
        {
            get
            {
                return Helper.SanitizeString(_desc);
            }
            set
            {
                _desc = value;
            }
        }
    }
}
