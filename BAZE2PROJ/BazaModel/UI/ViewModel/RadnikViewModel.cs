using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class RadnikViewModel:BindableNotify
    {
        private string imeRad;
        private string tipRad;
        private string prezRad;

        public string ImeRad { get => imeRad; set => imeRad = value; }
        public string TipRad { get => tipRad; set => tipRad = value; }
        public string PrezRad { get => prezRad; set => prezRad = value; }

      public RadnikViewModel()
      {

      }
    }
}
