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
    
    public partial class Radnik
    {
        public int IdRad { get; set; }
        public string ImeRad { get; set; }
        public string PrezRad { get; set; }
        public string TipRad { get; set; }
        public int PoslovnicaIdPosl { get; set; }
        public int PoslovnicaKompanijaZaIgreNaSrecuIdKmp { get; set; }
    
        public virtual Poslovnica Poslovnica { get; set; }
    }
}
