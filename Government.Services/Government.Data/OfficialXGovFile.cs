//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Government.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class OfficialXGovFile
    {
        public int Id { get; set; }
        public int OfficialId { get; set; }
        public int GovernmentFileId { get; set; }
        public Nullable<bool> Sponsored { get; set; }
        public Nullable<bool> CoSponsored { get; set; }
        public string Vote { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool ISDELETED { get; set; }
    }
}