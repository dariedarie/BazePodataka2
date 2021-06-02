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
    public class OnlinePrenosSPViewModel:ValidationBase
    {

        private ObservableCollection<PrenosSportskogDogadjaja> prenosTemp = new ObservableCollection<PrenosSportskogDogadjaja>();
        private ObservableCollection<OnlineSajt> onlineSajtTemp = new ObservableCollection<OnlineSajt>();

        private string tipDogadjaj;
        private string tipDogadjajM;
        private MyICommand addCommand;
        private MyICommand deleteCommand;
        private MyICommand modifyCommand;
        private MyICommand oKCommand;

        private PrenosSportskogDogadjaja selectedPS = new PrenosSportskogDogadjaja();
        private List<int> kompanije = new List<int>();
        private List<int> sajt = new List<int>();
        private int izbor;
        private int izborO;

        public OnlinePrenosSPViewModel()
        {
            SelectedPS = null;
            prenosTemp = new ObservableCollection<PrenosSportskogDogadjaja>(new KmpIgreDBModelContext().PrenosSportskogDogadjajas.ToList());
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



        public ObservableCollection<PrenosSportskogDogadjaja> PrenosTemp
        {
            get { return prenosTemp; }
            set
            {
                if (this.prenosTemp != value)
                {
                    this.prenosTemp = value;
                    OnPropertyChanged("PrenosTemp");
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


        public PrenosSportskogDogadjaja SelectedPS
        {
            get { return selectedPS; }
            set
            {
                if (this.selectedPS != value)
                {
                    this.selectedPS = value;
                    OnPropertyChanged("SelectedPS");

                }
            }
        }

        public string TipDogadjaj
        {
            get { return tipDogadjaj; }
            set
            {
                if (tipDogadjaj != value)
                {
                    tipDogadjaj = value;
                    OnPropertyChanged("TipDogadjaj");
                }
            }
        }


        public string TipDogadjajM
        {
            get { return tipDogadjajM; }
            set
            {
                if (tipDogadjajM != value)
                {
                    tipDogadjajM = value;
                    OnPropertyChanged("TipDogadjajM");
                }
            }
        }

        public MyICommand AddCommand { get => addCommand; set => addCommand = value; }
        public MyICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public MyICommand ModifyCommand { get => modifyCommand; set => modifyCommand = value; }
        public MyICommand OKCommand { get => oKCommand; set => oKCommand = value; }



        protected override void ValidateSelf()
        {
           

            if (string.IsNullOrWhiteSpace(this.TipDogadjaj))
            {
                this.ValidationErrors["Tip"] = "Tip je obavezan";
            }


        }


        public void OnAdd()
        {

            this.Validate();
            if (this.IsValid)
            {

                var context = new KmpIgreDBModelContext();
                PrenosSportskogDogadjaja p = new PrenosSportskogDogadjaja();
                p.tipDogadjaja = TipDogadjaj;
                p.OnlineSajtKompanijaZaIgreNaSrecuIdKmp = Izbor;
                p.OnlineSajtIdSajta = IzborO;
                context.PrenosSportskogDogadjajas.Add(p);
                context.SaveChanges();
                PrenosTemp.Add(p);
                PrenosTemp = new ObservableCollection<PrenosSportskogDogadjaja>(new KmpIgreDBModelContext().PrenosSportskogDogadjajas.ToList());
                TipDogadjaj = "";
            }
        }


        public void OnDelete()
        {
            if (SelectedPS != null)
            {
                if (SelectedPS.SifraDogadjaja != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    PrenosSportskogDogadjaja kmp = context.PrenosSportskogDogadjajas.Where(x => x.SifraDogadjaja == SelectedPS.SifraDogadjaja).FirstOrDefault();
                    context.PrenosSportskogDogadjajas.Remove(kmp);
                    context.SaveChanges();
                    PrenosTemp.Remove(kmp);
                    PrenosTemp = new ObservableCollection<PrenosSportskogDogadjaja>(new KmpIgreDBModelContext().PrenosSportskogDogadjajas.ToList());
                    SelectedPS = null;

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
            if (SelectedPS != null)
            {
                if (SelectedPS.SifraDogadjaja != 0)
                {
                    var context = new KmpIgreDBModelContext();
                    PrenosSportskogDogadjaja k = context.PrenosSportskogDogadjajas.Where(x => x.SifraDogadjaja == SelectedPS.SifraDogadjaja).FirstOrDefault();
                    TipDogadjajM = SelectedPS.tipDogadjaja;




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
            if (SelectedPS.SifraDogadjaja != 0)
            {

                var context = new KmpIgreDBModelContext();
                PrenosSportskogDogadjaja k = context.PrenosSportskogDogadjajas.Where(x => x.SifraDogadjaja == SelectedPS.SifraDogadjaja).FirstOrDefault();
                k.tipDogadjaja = TipDogadjajM;

                context.Entry(k).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                PrenosTemp.Remove(k);
                PrenosTemp.Add(k);
                PrenosTemp = new ObservableCollection<PrenosSportskogDogadjaja>(new KmpIgreDBModelContext().PrenosSportskogDogadjajas.ToList());
                TipDogadjajM = "";
                SelectedPS = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Niste selektovali nista iz tabele!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
