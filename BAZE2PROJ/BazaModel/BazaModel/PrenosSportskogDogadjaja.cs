//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BazaModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrenosSportskogDogadjaja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrenosSportskogDogadjaja()
        {
            this.Gledas = new HashSet<Gleda>();
        }
    
        public int SifraDogadjaja { get; set; }
        public string tipDogadjaja { get; set; }
        public int OnlineSajtIdSajta { get; set; }
        public int OnlineSajtKompanijaZaIgreNaSrecuIdKmp { get; set; }
    
        public virtual OnlineSajt OnlineSajt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gleda> Gledas { get; set; }
    }
}
