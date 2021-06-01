using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class OnlinePrenosSPViewModel:BindableNotify
    {
        private string tipDogadjaj;

        public OnlinePrenosSPViewModel()
        {

        }

        public string TipDogadjaj { get => tipDogadjaj; set => tipDogadjaj = value; }
    }
}
