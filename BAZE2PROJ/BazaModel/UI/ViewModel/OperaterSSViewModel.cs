using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class OperaterSSViewModel:BindableNotify
    {

        private string plata;

        public string Plata { get => plata; set => plata = value; }

        public OperaterSSViewModel()
        {

        }
    }
}
