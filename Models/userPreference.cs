//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIT5032Assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class userPreference
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userPreference()
        {
            this.tourPlan = new HashSet<tourPlan>();
        }
    
        public int preferenceID { get; set; }
        public Nullable<System.DateTime> durationDays { get; set; }
        public string attractionName { get; set; }
        public Nullable<int> budget { get; set; }
        public string guideType { get; set; }
        public Nullable<System.DateTime> generateTime { get; set; }
        public string UID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tourPlan> tourPlan { get; set; }
    }
}
