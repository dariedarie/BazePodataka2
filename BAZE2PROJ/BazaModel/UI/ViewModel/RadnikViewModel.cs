using BazaModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class RadnikViewModel:ValidationBase
    {
        private ObservableCollection<Radnik> radniksTemp = new ObservableCollection<Radnik>();
        private string imeRad;
        private string imeRadM;
        private string tipRad;
        private string tipRadM;
        private string prezRad;
        private string prezRadM;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private Radnik selectedRadnik = new Radnik();

        public RadnikViewModel()
        {
            SelectedRadnik = null;
            radniksTemp = new ObservableCollection<Radnik>(new KmpIgreDBModelContext().Radniks.ToList());
            //AddCommand = new MyICommand(OnAdd);
            //DeleteCommand = new MyICommand(OnDelete);
            //ModifyCommand = new MyICommand(OnModify);
            //OKCommand = new MyICommand(OnOKModify);
        }


        public string TipRad
        {
            get { return tipRad; }
            set
            {
                if (tipRad != value)
                {
                    tipRad = value;
                    OnPropertyChanged("TipRad");
                }
            }
        }

        public string TipRadM
        {
            get { return tipRadM; }
            set
            {
                if (tipRadM != value)
                {
                    tipRadM = value;
                    OnPropertyChanged("TipRadM");
                }
            }
        }




        public string ImeRad
        {
            get { return imeRad; }
            set
            {
                if (imeRad != value)
                {
                    imeRad = value;
                    OnPropertyChanged("ImeRad");
                }
            }
        }

        public string ImeRadM
        {
            get { return imeRadM; }
            set
            {
                if (imeRadM != value)
                {
                    imeRadM = value;
                    OnPropertyChanged("ImeRadM");
                }
            }
        }



        public string PrezRad
        {
            get { return prezRad; }
            set
            {
                if (prezRad != value)
                {
                    prezRad = value;
                    OnPropertyChanged("PrezRad");
                }
            }
        }

        public string PrezRadM
        {
            get { return prezRadM; }
            set
            {
                if (prezRadM != value)
                {
                    prezRadM = value;
                    OnPropertyChanged("PrezRadM");
                }
            }
        }


        public Radnik SelectedRadnik
        {
            get { return selectedRadnik; }
            set
            {
                if (this.selectedRadnik != value)
                {
                    this.selectedRadnik = value;
                    OnPropertyChanged("SelectedRadnik");

                }
            }
        }

        public ObservableCollection<Radnik> RadniksTemp
        {
            get { return radniksTemp; }
            set
            {
                if (this.radniksTemp != value)
                {
                    this.radniksTemp = value;
                    OnPropertyChanged("RadniksTemp");
                }
            }
        }

        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }


        protected override void ValidateSelf()
        {



            if (string.IsNullOrWhiteSpace(this.ImeRad))
            {
                this.ValidationErrors["Ime"] = "Ime je obavezano";
            }
            if (string.IsNullOrWhiteSpace(this.PrezRad))
            {
                this.ValidationErrors["Prez"] = "Prez  je obavezano";
            }

        }
    }
}
