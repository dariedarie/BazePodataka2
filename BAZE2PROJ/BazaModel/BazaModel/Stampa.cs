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
    
    public partial class Stampa
    {
        public int OperaterNaUplatnomMestuIdRad { get; set; }
        public int TiketSifraTiket { get; set; }
    
        public virtual OperaterNaUplatnomMestu OperaterNaUplatnomMestu { get; set; }
        public virtual Tiket Tiket { get; set; }
    }
}
