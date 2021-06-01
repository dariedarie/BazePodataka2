using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class KompanijaViewModel:BindableNotify
    {
        private string nazKmp;
        private string adrKmp;

        public string NazKmp { get => nazKmp; set => nazKmp = value; }
        public string AdrKmp { get => adrKmp; set => adrKmp = value; }

        public KompanijaViewModel()
        {

        }
    }
}
