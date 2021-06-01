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
    public class OnlineSajtViewModel:ValidationBase
    {

        private ObservableCollection<OnlineSajt> onlineSajtTemp = new ObservableCollection<OnlineSajt>();
        private ObservableCollection<KompanijaZaIgreNaSrecu> kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>();

        private string domen;
        private string domenM;
        private string nazSajta;
        private string nazSajtaM;

        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private OnlineSajt selectedSajt = new OnlineSajt();
        private List<int> kompanije = new List<int>();
        private int izbor;
        



        public OnlineSajtViewModel()
        {
            SelectedSajt = null;
            onlineSajtTemp = new ObservableCollection<OnlineSajt>(new KmpIgreDBModelContext().OnlineSajts.ToList());
            kmpsTemp = new ObservableCollection<KompanijaZaIgreNaSrecu>(new KmpIgreDBModelContext().KompanijaZaIgreNaSrecus.ToList());
            foreach (var item in kmpsTemp)
            {
                kompanije.Add(item.IdKmp);
            }
            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);
        }

        public OnlineSajt SelectedSajt
        {
            get { return selectedSajt; }
            set
            {
                if (this.selectedSajt != value)
                {
                    this.selectedSajt = value;
                    OnPropertyChanged("SelectedSajt");

                }
            }
        }

        public string NazSajta
        {
            get { return nazSajta; }
            set
            {
                if (nazSajta != value)
                {
                    nazSajta = value;
                    OnPropertyChanged("NazSajta");
                }
            }
        }



        public string Domen
        {
            get { return domen; }
            set
            {
                if (domen != value)
                {
                    domen = value;
                    OnPropertyChanged("Domen");
                }
            }
        }

        public string NazSajtaM
        {
            get { return nazSajtaM; }
            set
            {
                if (nazSajtaM != value)
                {
                    nazSajtaM = value;
                    OnPropertyChanged("NazSajtaM");
                }
            }
        }



        public string DomenM
        {
            get { return domenM; }
            set
            {
                if (domenM != value)
                {
                    domenM = value;
                    OnPropertyChanged("DomenM");
                }
            }
        }


        public ObservableCollection<OnlineSajt> OnlineSajtTemp
        {
            get { return onlineSajtTemp; }
            set
            {
                if (this.onlineSajtTemp != value)
                {
                    this.onlineSajtTemp = value;
                    OnPropertyChanged("OnlineSajtTemp");
                }
            }
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

        public List<int> Kompanije
        {
            get { return kompanije; }
            set
            {
                if (this.kompanije != value)
                {
                    this.kompanije = value;
                    OnPropertyChanged("Kompanije");
                }
            }
        }

        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }


        protected override void ValidateSelf()
        {
            bool valid = true;
            //foreach (var item in ViewModel.NetworkEntitiesViewModel.Roads)
            //{
            //    if (item.id.Equals(Id))
            //        valid = false;
            //}

            if (string.IsNullOrWhiteSpace(this.NazSajta))
            {
                this.ValidationErrors["Naziv"] = "Naziv je obavezan";
            }
            if (string.IsNullOrWhiteSpace(this.Domen))
            {
                this.ValidationErrors["Domen"] = "Domen je obavezan";
            }

        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                OnlineSajt p = new OnlineSajt();
                p.NazSajta = NazSajta;
                p.Domen = Domen;
                p.KompanijaZaIgreNaSrecuIdKmp = Izbor;
                context.OnlineSajts.Add(p);
                context.SaveChanges();
                OnlineSajtTemp.Add(p);
                //KlijentsTemp.Clear();
                OnlineSajtTemp = new ObservableCollection<OnlineSajt>(new KmpIgreDBModelContext().OnlineSajts.ToList());
                NazSajta = "";
                Domen = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedSajt != null)
            {
                if (SelectedSajt.IdSajta != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    OnlineSajt kmp = context.OnlineSajts.Where(x => x.IdSajta == SelectedSajt.IdSajta).FirstOrDefault();
                    context.OnlineSajts.Remove(kmp);
                    context.SaveChanges();
                    OnlineSajtTemp.Remove(kmp);
                    OnlineSajtTemp = new ObservableCollection<OnlineSajt>(new KmpIgreDBModelContext().OnlineSajts.ToList());
                    SelectedSajt = null;

                }
                else
                {
                    System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }


        }


        public void OnModify()
        {
            if (SelectedSajt != null)
            {
                if (SelectedSajt.IdSajta != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    OnlineSajt k = context.OnlineSajts.Where(x => x.IdSajta == SelectedSajt.IdSajta).FirstOrDefault();
                    NazSajtaM = SelectedSajt.NazSajta;
                    DomenM = SelectedSajt.Domen;
                    

                }
                else
                {
                    System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }
        public void OnOKModify()
        {

            var context = new KmpIgreDBModelContext();
            OnlineSajt k = context.OnlineSajts.Where(x => x.IdSajta == SelectedSajt.IdSajta).FirstOrDefault();
            k.NazSajta = NazSajtaM;
            k.Domen = DomenM;
            context.Entry(k).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            OnlineSajtTemp.Remove(k);
            OnlineSajtTemp.Add(k);
            OnlineSajtTemp = new ObservableCollection<OnlineSajt>(new KmpIgreDBModelContext().OnlineSajts.ToList());
            NazSajtaM = "";
            DomenM = "";
            SelectedSajt = null;

        }
    }
}
