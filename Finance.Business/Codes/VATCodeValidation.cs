using System.ComponentModel.DataAnnotations;

namespace Finance.Business.Codes
{
    public class VATCodeValidation
    {
        [Required, StringLength(12)]
        public virtual string vatCode { get; set; }
        [Required, StringLength(50)]
        public virtual string vatCodeDescription { get; set; }
        [Required]
        public virtual bool active { get; set; }
    }
}
