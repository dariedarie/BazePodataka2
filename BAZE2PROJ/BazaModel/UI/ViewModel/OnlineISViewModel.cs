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
    public class OnlineISViewModel:ValidationBase
    {
        private ObservableCollection<OnlineIgraNaSrecu> onlineISTemp = new ObservableCollection<OnlineIgraNaSrecu>();
       
        private ObservableCollection<OnlineSajt> onlineSajtTemp = new ObservableCollection<OnlineSajt>();
        private string nazIgre;
        private string nazIgreM;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;
        private OnlineIgraNaSrecu selectedIS = new OnlineIgraNaSrecu();
        private List<int> kompanije = new List<int>();
        private List<int> sajt = new List<int>();
        private int izbor;
        private int izborO;



        public OnlineISViewModel()
        {
            SelectedIS = null;
            onlineISTemp = new ObservableCollection<OnlineIgraNaSrecu>(new KmpIgreDBModelContext().OnlineIgraNaSrecus.ToList());
            onlineSajtTemp = new ObservableCollection<OnlineSajt>(new KmpIgreDBModelContext().OnlineSajts.ToList());
            foreach (var item in onlineSajtTemp)
            {
                kompanije.Add(item.KompanijaZaIgreNaSrecuIdKmp);
            }
            foreach (var item in onlineSajtTemp)
            {
                sajt.Add(item.IdSajta);
            }





            AddCommand = new MyICommand(OnAdd);
            DeleteCommand = new MyICommand(OnDelete);
            ModifyCommand = new MyICommand(OnModify);
            OKCommand = new MyICommand(OnOKModify);
        }

        public ObservableCollection<OnlineIgraNaSrecu> OnlineISTemp
        {
            get { return onlineISTemp; }
            set
            {
                if (this.onlineISTemp != value)
                {
                    this.onlineISTemp = value;
                    OnPropertyChanged("OnlineISTemp");
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


        public int IzborO
        {
            get { return izborO; }
            set
            {
                if (izborO != value)
                {
                    izborO = value;
                    OnPropertyChanged("IzborO");
                }
            }
        }

        public List<int> Sajt
        {
            get { return sajt; }
            set
            {
                if (this.sajt != value)
                {
                    this.sajt = value;
                    OnPropertyChanged("Sajt");
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
        public OnlineIgraNaSrecu SelectedIS
        {
            get { return selectedIS; }
            set
            {
                if (this.selectedIS != value)
                {
                    this.selectedIS = value;
                    OnPropertyChanged("SelectedIS");

                }
            }
        }

        public string NazIgre
        {
            get { return nazIgre; }
            set
            {
                if (nazIgre != value)
                {
                    nazIgre = value;
                    OnPropertyChanged("NazIgre");
                }
            }
        }


        public string NazIgreM
        {
            get { return nazIgreM; }
            set
            {
                if (nazIgreM != value)
                {
                    nazIgreM = value;
                    OnPropertyChanged("NazIgreM");
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

            if (string.IsNullOrWhiteSpace(this.NazIgre))
            {
                this.ValidationErrors["Naziv"] = "Naziv je obavezan";
            }
           

        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                OnlineIgraNaSrecu p = new OnlineIgraNaSrecu();
                p.NazIgre = NazIgre;
                p.OnlineSajtKompanijaZaIgreNaSrecuIdKmp = Izbor;
                p.OnlineSajtIdSajta = IzborO;
                context.OnlineIgraNaSrecus.Add(p);
                context.SaveChanges();
                OnlineISTemp.Add(p);
                OnlineISTemp = new ObservableCollection<OnlineIgraNaSrecu>(new KmpIgreDBModelContext().OnlineIgraNaSrecus.ToList());
                NazIgre = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedIS != null)
            {
                if (SelectedIS.IdIgre != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    OnlineIgraNaSrecu kmp = context.OnlineIgraNaSrecus.Where(x => x.IdIgre == SelectedIS.IdIgre).FirstOrDefault();
                    context.OnlineIgraNaSrecus.Remove(kmp);
                    context.SaveChanges();
                    OnlineISTemp.Remove(kmp);
                    OnlineISTemp = new ObservableCollection<OnlineIgraNaSrecu>(new KmpIgreDBModelContext().OnlineIgraNaSrecus.ToList());
                    SelectedIS = null;

                }
                else
                {
                    System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }


        }


        public void OnModify()
        {
            if (SelectedIS != null)
            {
                if (SelectedIS.IdIgre != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    OnlineIgraNaSrecu k = context.OnlineIgraNaSrecus.Where(x => x.IdIgre == SelectedIS.IdIgre).FirstOrDefault();
                    NazIgreM = SelectedIS.NazIgre;
               
                    


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
            OnlineIgraNaSrecu k = context.OnlineIgraNaSrecus.Where(x => x.IdIgre == SelectedIS.IdIgre).FirstOrDefault();
            k.NazIgre = NazIgreM;

            context.Entry(k).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            OnlineISTemp.Remove(k);
            OnlineISTemp.Add(k);
            OnlineISTemp = new ObservableCollection<OnlineIgraNaSrecu>(new KmpIgreDBModelContext().OnlineIgraNaSrecus.ToList());
            NazIgreM = "";
            SelectedIS = null;

        }
    }
}
