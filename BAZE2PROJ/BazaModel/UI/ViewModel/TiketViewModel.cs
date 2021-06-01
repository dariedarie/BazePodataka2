using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class TiketViewModel:BindableNotify
    {
        private int brParova;

        public TiketViewModel()
        {

        }

        public int BrParova { get => brParova; set => brParova = value; }
    }
}
