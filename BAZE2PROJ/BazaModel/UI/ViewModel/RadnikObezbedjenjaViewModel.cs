using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class RadnikObezbedjenjaViewModel:BindableNotify
    {
        private string vestine;
        public RadnikObezbedjenjaViewModel()
        {

        }

        public string Vestine { get => vestine; set => vestine = value; }
    }
}
