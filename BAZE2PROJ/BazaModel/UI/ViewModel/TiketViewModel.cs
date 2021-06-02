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
    public class TiketViewModel : ValidationBase
    {
        private ObservableCollection<Tiket> tiketTemp = new ObservableCollection<Tiket>();
        private ObservableCollection<Klijent> klijentsTemp = new ObservableCollection<Klijent>();
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private Tiket selectedTiket = new Tiket();
        private int brParova;
        private int brParovaM;
        private int izbor;
        private List<int> klijenti = new List<int>();

        public TiketViewModel()
        {
            SelectedTiket = null;
            tiketTemp = new ObservableCollection<Tiket>(new KmpIgreDBModelContext().Tikets.ToList());
            klijentsTemp = new ObservableCollection<Klijent>(new KmpIgreDBModelContext().Klijents.ToList());
            foreach (var item in klijentsTemp)
            {
                klijenti.Add(item.IdKlijenta);
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


        public List<int> Klijenti
        {
            get { return klijenti; }
            set
            {
                if (this.klijenti != value)
                {
                    this.klijenti = value;
                    OnPropertyChanged("Klijenti");
                }
            }
        }

        public Tiket SelectedTiket
        {
            get { return selectedTiket; }
            set
            {
                if (this.selectedTiket != value)
                {
                    this.selectedTiket = value;
                    OnPropertyChanged("SelectedTiket");

                }
            }
        }

        public int BrParova
        {
            get { return brParova; }
            set
            {
                if (brParova != value)
                {
                    brParova = value;
                    OnPropertyChanged("BrParova");
                }
            }
        }


        public int BrParovaM
        {
            get { return brParovaM; }
            set
            {
                if (brParovaM != value)
                {
                    brParovaM = value;
                    OnPropertyChanged("BrParovaM");
                }
            }
        }


        public ObservableCollection<Tiket> TiketTemp
        {
            get { return tiketTemp; }
            set
            {
                if (this.tiketTemp != value)
                {
                    this.tiketTemp = value;
                    OnPropertyChanged("TiketTemp");
                }
            }
        }

        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }


        protected override void ValidateSelf()
        {


            if (BrParova <= 0 || string.IsNullOrWhiteSpace(this.BrParova.ToString()))
            {
                this.ValidationErrors["BrParova"] = "Niste uneli broj parova.";
            }
            else if (BrParova.ToString().Contains(","))
            {
                this.ValidationErrors["BrParova"] = "BrParova ne sme da sadrzi zarez.";
            }


        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                Tiket k = new Tiket();
                k.BrParova = BrParova;
                k.KlijentIdKlijenta = Izbor;
                context.Tikets.Add(k);
                context.SaveChanges();
                TiketTemp.Add(k);

                TiketTemp = new ObservableCollection<Tiket>(new KmpIgreDBModelContext().Tikets.ToList());
                BrParova = 0;

            }
        }


        public void OnDelete()
        {
            if (SelectedTiket != null)
            {
                if (SelectedTiket.SifraTiket != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Tiket k = context.Tikets.Where(x => x.SifraTiket == SelectedTiket.SifraTiket).FirstOrDefault();
                    context.Tikets.Remove(k);
                    context.SaveChanges();
                    TiketTemp.Remove(k);
                    TiketTemp = new ObservableCollection<Tiket>(new KmpIgreDBModelContext().Tikets.ToList());
                    SelectedTiket = null;

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
            if (SelectedTiket != null)
            {
                if (SelectedTiket.SifraTiket != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Tiket k = context.Tikets.Where(x => x.SifraTiket == SelectedTiket.SifraTiket).FirstOrDefault();
                    BrParovaM = SelectedTiket.BrParova;


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
            if (SelectedTiket != null)
            {
                var context = new KmpIgreDBModelContext();
                Tiket k = context.Tikets.Where(x => x.SifraTiket == SelectedTiket.SifraTiket).FirstOrDefault();
                k.BrParova = BrParovaM;

                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                TiketTemp.Remove(k);
                TiketTemp.Add(k);
                TiketTemp = new ObservableCollection<Tiket>(new KmpIgreDBModelContext().Tikets.ToList());
                BrParova = 0;

                SelectedTiket = null;
            }

            else
            {

                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }
    }
}
