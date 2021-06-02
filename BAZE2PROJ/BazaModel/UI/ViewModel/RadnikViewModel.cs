using BazaModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    public class RadnikViewModel:ValidationBase
    {
        private ObservableCollection<Radnik> radniksTemp = new ObservableCollection<Radnik>();
        private ObservableCollection<Poslovnica> poslsTemp = new ObservableCollection<Poslovnica>();
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
        private string izbor1;
        private int izbor2;
        private int izbor3;
        private Radnik selectedRadnik = new Radnik();
        private List<int> kompanijeP = new List<int>();
        private List<int> poslovnicaR = new List<int>();

        private List<String> radnikTypes = new List<String>() { "OBEZBEDJNJE", "RADNIKSLOT","RADNIKUPLATNO" };

        public RadnikViewModel()
        {
            SelectedRadnik = null;
            radniksTemp = new ObservableCollection<Radnik>(new KmpIgreDBModelContext().Radniks.ToList());
            poslsTemp = new ObservableCollection<Poslovnica>(new KmpIgreDBModelContext().Poslovnicas.ToList());
            foreach (var item in poslsTemp)
            {
                KompanijeP.Add(item.KompanijaZaIgreNaSrecuIdKmp);
            }
            foreach (var item in poslsTemp)
            {
                PoslovnicaR.Add(item.IdPosl);
            }
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);
        }


        public List<int> PoslovnicaR
        {
            get { return poslovnicaR; }
            set
            {
                if (this.poslovnicaR != value)
                {
                    this.poslovnicaR = value;
                    OnPropertyChanged("PoslovnicaR");
                }
            }
        }

        public List<int> KompanijeP
        {
            get { return kompanijeP; }
            set
            {
                if (this.kompanijeP != value)
                {
                    this.kompanijeP = value;
                    OnPropertyChanged("KompanijeP");
                }
            }
        }

        public string Izbor1
        {
            get { return izbor1; }
            set
            {
                if (izbor1 != value)
                {
                    izbor1 = value;
                    OnPropertyChanged("Izbor1");
                }
            }
        }

        public int Izbor3
        {
            get { return izbor3; }
            set
            {
                if (izbor3 != value)
                {
                    izbor3 = value;
                    OnPropertyChanged("Izbor3");
                }
            }
        }

        public int Izbor2
        {
            get { return izbor2; }
            set
            {
                if (izbor2 != value)
                {
                    izbor2 = value;
                    OnPropertyChanged("Izbor2");
                }
            }
        }

        public List<String> RadnikTypes
        {
            get { return radnikTypes; }
            set
            {
                if (this.radnikTypes != value)
                {
                    this.radnikTypes = value;
                    OnPropertyChanged("RadnikTypes");
                }
            }
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


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                Radnik p = new Radnik();
                p.ImeRad = ImeRad;
                p.PrezRad = PrezRad;
                p.TipRad = Izbor1;
                p.PoslovnicaKompanijaZaIgreNaSrecuIdKmp = Izbor2;
                p.PoslovnicaIdPosl = Izbor3;
                context.Radniks.Add(p);
                context.SaveChanges();
                RadniksTemp.Add(p);
                RadniksTemp = new ObservableCollection<Radnik>(new KmpIgreDBModelContext().Radniks.ToList());
                TipRad = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedRadnik != null)
            {
                if (SelectedRadnik.IdRad != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Radnik kmp = context.Radniks.Where(x => x.IdRad == SelectedRadnik.IdRad).FirstOrDefault();
                    context.Radniks.Remove(kmp);
                    context.SaveChanges();
                    RadniksTemp.Remove(kmp);
                    RadniksTemp = new ObservableCollection<Radnik>(new KmpIgreDBModelContext().Radniks.ToList());
                    SelectedRadnik = null;

                }
                else
                {
                    System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }


        public void OnModify()
        {
            if (SelectedRadnik != null)
            {
                if (SelectedRadnik.IdRad != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Radnik k = context.Radniks.Where(x => x.IdRad== SelectedRadnik.IdRad).FirstOrDefault();
                    ImeRadM = SelectedRadnik.ImeRad;
                    PrezRadM = SelectedRadnik.PrezRad;




                }
                else
                {
                    System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        public void OnOKModify()
        {
            if (SelectedRadnik.IdRad != 0)
            {

                var context = new KmpIgreDBModelContext();
                Radnik k = context.Radniks.Where(x => x.IdRad == SelectedRadnik.IdRad).FirstOrDefault();
                k.ImeRad = ImeRadM;
                k.PrezRad = PrezRadM;

                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                RadniksTemp.Remove(k);
                RadniksTemp.Add(k);
                RadniksTemp = new ObservableCollection<Radnik>(new KmpIgreDBModelContext().Radniks.ToList());
                TipRadM = "";
                SelectedRadnik = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
