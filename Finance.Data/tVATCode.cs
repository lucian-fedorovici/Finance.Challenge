//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finance.Data
{
    using Finance.Entities.Interfaces;
    using System;

    public partial class tVATCode : IAuditable
    {
        public long Id { get; set; }
        public string LACode { get; set; }
        public string SchoolCode { get; set; }
        public long CompanyId { get; set; }
        public string VATCode { get; set; }
        public string VATCodeDescription { get; set; }
        public bool Active { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
