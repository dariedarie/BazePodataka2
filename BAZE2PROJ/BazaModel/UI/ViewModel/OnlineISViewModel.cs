using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class OnlineISViewModel:BindableNotify
    {
        private string nazIgre;

        public string NazIgre { get => nazIgre; set => nazIgre = value; }


        public OnlineISViewModel()
        {

        }
    }
}
