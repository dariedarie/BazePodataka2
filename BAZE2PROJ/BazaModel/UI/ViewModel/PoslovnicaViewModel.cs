using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class PoslovnicaViewModel:BindableNotify
    {
        private string lokacija;
        private string nazPoslovnice;

        public string Lokacija { get => lokacija; set => lokacija = value; }
        public string NazPoslovnice { get => nazPoslovnice; set => nazPoslovnice = value; }

        public PoslovnicaViewModel()
        {

        }
    }
}
