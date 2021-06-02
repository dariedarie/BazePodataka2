using BazaModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Views;

namespace UI.ViewModel
{
    public class KlijentViewModel:ValidationBase
    {
        
        private ObservableCollection<Klijent> klijentsTemp = new ObservableCollection<Klijent>();
        private int id;
        private string imeKlijenta;
        private string imeMKlijenta;
        private string prezKlijenta;
        private string prezMKlijenta;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private Klijent selectedKlijent = new Klijent();



        
       
        public KlijentViewModel()
        {
            SelectedKlijent = null;
            klijentsTemp = new ObservableCollection<Klijent>(new KmpIgreDBModelContext().Klijents.ToList());
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);
            
        }


        public Klijent SelectedKlijent
        {
            get { return selectedKlijent; }
            set
            {
                if (this.selectedKlijent != value)
                {
                    this.selectedKlijent = value;
                    OnPropertyChanged("SelectedKlijent");

                }
            }
        }

        public ObservableCollection<Klijent> KlijentsTemp
        {
            get { return klijentsTemp; }
            set
            {
                if (this.klijentsTemp != value)
                {
                    this.klijentsTemp = value;
                    OnPropertyChanged("KlijentsTemp");
                }
            }
        }



        public string ImeKlijenta
        {
            get { return imeKlijenta; }
            set
            {
                if (imeKlijenta != value)
                {
                    imeKlijenta = value;
                    OnPropertyChanged("ImeKlijenta");
                }
            }
        }



        public string PrezKlijenta
        {
            get { return prezKlijenta; }
            set
            {
                if (prezKlijenta != value)
                {
                    prezKlijenta = value;
                    OnPropertyChanged("PrezKlijenta");
                }
            }
        }

        public string ImeMKlijenta
        {
            get { return imeMKlijenta; }
            set
            {
                if (imeMKlijenta != value)
                {
                    imeMKlijenta = value;
                    OnPropertyChanged("ImeMKlijenta");
                }
            }
        }



        public string PrezMKlijenta
        {
            get { return prezMKlijenta; }
            set
            {
                if (prezMKlijenta != value)
                {
                    prezMKlijenta = value;
                    OnPropertyChanged("PrezMKlijenta");
                }
            }
        }



        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }

        protected override void ValidateSelf()
        {
           
            
            
            if (string.IsNullOrWhiteSpace(this.ImeKlijenta))
            {
                this.ValidationErrors["Ime"] = "Ime je obavezano";
            }
            if (string.IsNullOrWhiteSpace(this.PrezKlijenta))
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
                Klijent k = new Klijent();
                k.ImeKlijenta = ImeKlijenta;
                k.PrezKlijenta = PrezKlijenta;
                k.Tikets = new List<Tiket>();
                context.Klijents.Add(k);
                context.SaveChanges();
                KlijentsTemp.Add(k);
                
                KlijentsTemp = new ObservableCollection<Klijent>(new KmpIgreDBModelContext().Klijents.ToList());
                ImeKlijenta = "";
                PrezKlijenta = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedKlijent != null)
            {
                if(SelectedKlijent.IdKlijenta != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Klijent k = context.Klijents.Where(x => x.IdKlijenta == SelectedKlijent.IdKlijenta).FirstOrDefault();
                    context.Klijents.Remove(k);
                    context.SaveChanges();
                    KlijentsTemp.Remove(k);
                    KlijentsTemp = new ObservableCollection<Klijent>(new KmpIgreDBModelContext().Klijents.ToList());
                    SelectedKlijent = null; 

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
            if (SelectedKlijent != null)
            {
                if (SelectedKlijent.IdKlijenta != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    Klijent k = context.Klijents.Where(x => x.IdKlijenta == SelectedKlijent.IdKlijenta).FirstOrDefault();
                    ImeMKlijenta = SelectedKlijent.ImeKlijenta;
                    PrezMKlijenta = SelectedKlijent.PrezKlijenta;
                   
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
            if (SelectedKlijent != null)
            {
                var context = new KmpIgreDBModelContext();
                Klijent k = context.Klijents.Where(x => x.IdKlijenta == SelectedKlijent.IdKlijenta).FirstOrDefault();
                k.ImeKlijenta = ImeMKlijenta;
                k.PrezKlijenta = PrezMKlijenta;
                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                KlijentsTemp.Remove(k);
                KlijentsTemp.Add(k);
                KlijentsTemp = new ObservableCollection<Klijent>(new KmpIgreDBModelContext().Klijents.ToList());
                ImeMKlijenta = "";
                PrezMKlijenta = "";
                SelectedKlijent = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }


    }
}
