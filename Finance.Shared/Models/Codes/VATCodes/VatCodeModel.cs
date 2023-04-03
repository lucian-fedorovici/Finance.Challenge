namespace Finance.Shared.Models.Codes.VATCodes
{
    public class VatCodeModel
    {
        public long Id { get; set; }
        public string VATCode { get; set; }
        public string VATCodeDescription { get; set; }
        public bool Active { get; set; }
    }
}
