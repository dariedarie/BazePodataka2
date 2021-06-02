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
    public class PoslovnicaViewModel:ValidationBase
    {
        private ObservableCollection<Poslovnica> poslsTemp = new ObservableCollection<Poslovnica>();
        private ObservableCollection<KompanijaZaIgreNaSrecu> kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>();
        private string lokacija;
        private string lokacijaM;
        private string nazPosl;
        private string nazMPosl;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private Poslovnica selectedPosl = new Poslovnica();
        private List<int> kompanijeP = new List<int>();
        private int izbor;
        private int izborM;

        public PoslovnicaViewModel()
        {
            SelectedPosl = null;
            poslsTemp = new ObservableCollection<Poslovnica>(new KmpIgreDBModelContext().Poslovnicas.ToList());
            kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
            foreach (var item in kmpsTemp)
            {
                KompanijeP.Add(item.IdKmp);
            }
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);
        }


        public int Izbor
        {
            get { return izbor; }
            set
            {
                if (izbor != value)
                {
                    izbor = value;
                    OnPropertyChanged("Izbor");
                }
            }
        }

        public int IzborM
        {
            get { return izborM; }
            set
            {
                if (izborM != value)
                {
                    izborM = value;
                    OnPropertyChanged("IzborM");
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

        public Poslovnica SelectedPosl
        {
            get { return selectedPosl; }
            set
            {
                if (this.selectedPosl != value)
                {
                    this.selectedPosl = value;
                    OnPropertyChanged("SelectedPosl");

                }
            }
        }

        public ObservableCollection<Poslovnica> PoslsTemp
        {
            get { return poslsTemp; }
            set
            {
                if (this.poslsTemp != value)
                {
                    this.poslsTemp = value;
                    OnPropertyChanged("PoslsTemp");
                }
            }
        }

        public string NazPosl
        {
            get { return nazPosl; }
            set
            {
                if (nazPosl != value)
                {
                    nazPosl = value;
                    OnPropertyChanged("NazPosl");
                }
            }
        }



        public string Lokacija
        {
            get { return lokacija; }
            set
            {
                if (lokacija != value)
                {
                    lokacija = value;
                    OnPropertyChanged("Lokacija");
                }
            }
        }


        public string NazMPosl
        {
            get { return nazMPosl; }
            set
            {
                if (nazMPosl != value)
                {
                    nazMPosl = value;
                    OnPropertyChanged("NazMPosl");
                }
            }
        }



        public string LokacijaM
        {
            get { return lokacijaM; }
            set
            {
                if (lokacijaM != value)
                {
                    lokacijaM = value;
                    OnPropertyChanged("LokacijaM");
                }
            }
        }


        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }


        protected override void ValidateSelf()
        {
           

            if (string.IsNullOrWhiteSpace(this.NazPosl))
            {
                this.ValidationErrors["Naziv"] = "Naziv je obavezan";
            }
            if (string.IsNullOrWhiteSpace(this.Lokacija))
            {
                this.ValidationErrors["Lokacija"] = "Lokacija je obavezna";
            }

        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {
                
                var context = new KmpIgreDBModelContext();
                Poslovnica p = new Poslovnica();
                p.NazPoslovnice = NazPosl;
                p.Lokacija = Lokacija;
                p.KompanijaZaIgreNaSrecuIdKmp = Izbor;
                context.Poslovnicas.Add(p);
                context.SaveChanges();
                PoslsTemp.Add(p);
                PoslsTemp = new ObservableCollection<Poslovnica>(new KmpIgreDBModelContext().Poslovnicas.ToList());
                NazPosl = "";
                Lokacija = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedPosl != null)
            {
                if (SelectedPosl.IdPosl != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Poslovnica kmp = context.Poslovnicas.Where(x => x.IdPosl == SelectedPosl.IdPosl).FirstOrDefault();
                    context.Poslovnicas.Remove(kmp);
                    context.SaveChanges();
                    PoslsTemp.Remove(kmp);
                    PoslsTemp = new ObservableCollection<Poslovnica>(new KmpIgreDBModelContext().Poslovnicas.ToList());
                    SelectedPosl = null;

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
            if (SelectedPosl != null)
            {
                if (SelectedPosl.IdPosl != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Poslovnica k = context.Poslovnicas.Where(x => x.IdPosl == SelectedPosl.IdPosl).FirstOrDefault();
                    NazMPosl = SelectedPosl.NazPoslovnice;
                    LokacijaM = SelectedPosl.Lokacija;
                 

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
            if (SelectedPosl != null)
            {
                var context = new KmpIgreDBModelContext();
                Poslovnica k = context.Poslovnicas.Where(x => x.IdPosl == SelectedPosl.IdPosl).FirstOrDefault();
                k.NazPoslovnice = NazMPosl;
                k.Lokacija = LokacijaM;
                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                PoslsTemp.Remove(k);
                PoslsTemp.Add(k);
                PoslsTemp = new ObservableCollection<Poslovnica>(new KmpIgreDBModelContext().Poslovnicas.ToList());
                NazMPosl = "";
                LokacijaM = "";
                SelectedPosl = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }



    }
}
