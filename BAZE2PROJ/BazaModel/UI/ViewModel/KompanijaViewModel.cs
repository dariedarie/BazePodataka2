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
    public class KompanijaViewModel:ValidationBase
    {
        private ObservableCollection<KompanijaZaIgreNaSrecu> kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>();
        private int id;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private KompanijaZaIgreNaSrecu selectedKmp = new KompanijaZaIgreNaSrecu();


        private string nazKmp;
        private string nazMKmp;
        private string adrKmp;
        private string adrMKmp;
        


        public KompanijaViewModel()
        {
            SelectedKmp = null;
            kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);

        }

        public KompanijaZaIgreNaSrecu SelectedKmp
        {
            get { return selectedKmp; }
            set
            {
                if (this.selectedKmp != value)
                {
                    this.selectedKmp = value;
                    OnPropertyChanged("SelectedKmp");

                }
            }
        }

        public ObservableCollection<KompanijaZaIgreNaSrecu> KmpsTemp
        {
            get { return kmpsTemp; }
            set
            {
                if (this.kmpsTemp != value)
                {
                    this.kmpsTemp = value;
                    OnPropertyChanged("KmpsTemp");
                }
            }
        }

        


        public string NazKmp
        {
            get { return nazKmp; }
            set
            {
                if (nazKmp != value)
                {
                    nazKmp = value;
                    OnPropertyChanged("NazKmp");
                }
            }
        }



        public string AdrKmp
        {
            get { return adrKmp; }
            set
            {
                if (adrKmp != value)
                {
                    adrKmp = value;
                    OnPropertyChanged("AdrKmp");
                }
            }
        }

        public string NazMKmp
        {
            get { return nazMKmp; }
            set
            {
                if (nazMKmp != value)
                {
                    nazMKmp = value;
                    OnPropertyChanged("NazMKmp");
                }
            }
        }



        public string AdrMKmp
        {
            get { return adrMKmp; }
            set
            {
                if (adrMKmp != value)
                {
                    adrMKmp = value;
                    OnPropertyChanged("AdrMKmp");
                }
            }
        }



        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }

        protected override void ValidateSelf()
        {
           
            

            if (string.IsNullOrWhiteSpace(this.NazKmp))
            {
                this.ValidationErrors["Naziv"] = "Naziv je obavezan";
            }
            if (string.IsNullOrWhiteSpace(this.AdrKmp))
            {
                this.ValidationErrors["Adresa"] = "Adresa je obavezna";
            }

        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                KompanijaZaIgreNaSrecu k = new KompanijaZaIgreNaSrecu();
                k.NazKmp = NazKmp;
                k.AdrKmp = AdrKmp;
                context.KompanijaZaIgreNaSrecus.Add(k);
                context.SaveChanges();
                KmpsTemp.Add(k);
                
                KmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
                NazKmp = "";
                AdrKmp = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedKmp != null)
            {
                if (SelectedKmp.IdKmp != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    KompanijaZaIgreNaSrecu kmp = context.KompanijaZaIgreNaSrecus.Where(x => x.IdKmp == SelectedKmp.IdKmp).FirstOrDefault();
                    context.KompanijaZaIgreNaSrecus.Remove(kmp);
                    context.SaveChanges();
                    KmpsTemp.Remove(kmp);
                    KmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
                    SelectedKmp = null;

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
            if (SelectedKmp != null)
            {
                if (SelectedKmp.IdKmp != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    KompanijaZaIgreNaSrecu k = context.KompanijaZaIgreNaSrecus.Where(x => x.IdKmp == SelectedKmp.IdKmp).FirstOrDefault();
                    NazMKmp = SelectedKmp.NazKmp;
                    AdrMKmp = SelectedKmp.AdrKmp;

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
            if (SelectedKmp != null)
            {
                var context = new KmpIgreDBModelContext();
                KompanijaZaIgreNaSrecu k = context.KompanijaZaIgreNaSrecus.Where(x => x.IdKmp == SelectedKmp.IdKmp).FirstOrDefault();
                k.NazKmp = NazMKmp;
                k.AdrKmp = AdrMKmp;
                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                KmpsTemp.Remove(k);
                KmpsTemp.Add(k);
                KmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
                NazMKmp = "";
                AdrMKmp = "";
                SelectedKmp = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
