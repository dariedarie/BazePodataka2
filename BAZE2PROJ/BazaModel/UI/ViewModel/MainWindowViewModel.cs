using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class MainWindowViewModel:BindableNotify
    {
        private BindableNotify currentViewModel;
        private KompanijaViewModel kompanijaViewModel = new KompanijaViewModel();
        private KlijentViewModel klijentViewModel = new KlijentViewModel();
        private TiketViewModel tiketViewModel = new TiketViewModel();
        private PoslovnicaViewModel poslovnicaViewModel = new PoslovnicaViewModel();
        private OnlineSajtViewModel onlineSajtViewModel = new OnlineSajtViewModel();
        private OnlineISViewModel onlineISViewModel = new OnlineISViewModel();
        private OnlinePrenosSPViewModel onlinePSViewModel = new OnlinePrenosSPViewModel();
        public MyICommand<string> NavCommand { get; private set; }

        public MainWindowViewModel()
        {
           
            NavCommand = new MyICommand<string>(OnNav);
            currentViewModel = klijentViewModel;
        }


        public BindableNotify CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "kmp":
                    CurrentViewModel = kompanijaViewModel;
                    break;
                case "klijent":
                    CurrentViewModel = klijentViewModel;
                    break;
                case "poslovnica":
                    CurrentViewModel = poslovnicaViewModel;
                    break;
                case "onlinesajt":
                    CurrentViewModel = onlineSajtViewModel;
                    break;
                case "onlineis":
                    CurrentViewModel = onlineISViewModel;
                    break;
                case "onlineps":
                    CurrentViewModel = onlinePSViewModel;
                    break;
                case "tiket":
                    CurrentViewModel = tiketViewModel;
                    break;




            }
        }



    }
}
