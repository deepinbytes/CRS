//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABC_CRS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public Company()
        {
            this.Participants = new HashSet<Participant>();
        }
    
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUEN { get; set; }
        public Nullable<int> OrganizationSize { get; set; }
        public string CompanyAddress { get; set; }
        public string Country { get; set; }
        public Nullable<int> PostalCode { get; set; }
    
        public virtual CompanyHR CompanyHR { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
