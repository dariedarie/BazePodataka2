using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class OnlineSajtViewModel:BindableNotify
    {
        private string domen;
        private string nazSajta;

        public string Domen { get => domen; set => domen = value; }
        public string NazSajta { get => nazSajta; set => nazSajta = value; }

       public OnlineSajtViewModel()
        {

        }
    }
}
