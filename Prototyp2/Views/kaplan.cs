//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prototyp2.Views
{
    using System;
    using System.Collections.Generic;
    
    public partial class kaplan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kaplan()
        {
            this.osoba = new HashSet<osoba>();
        }
    
        public int id_kaplan { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<osoba> osoba { get; set; }
    }
}
