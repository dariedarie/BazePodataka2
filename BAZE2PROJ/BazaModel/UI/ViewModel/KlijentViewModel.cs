using BazaModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ViewModel
{
    public class KlijentViewModel:BindableNotify
    {
        public static ObservableCollection<Klijent> Klijenti = new ObservableCollection<Klijent>();
        private ObservableCollection<Klijent> klijentTemp = new ObservableCollection<Klijent>(Klijenti);
        private int id;
        private string imeKlijenta;
        private string prezKlijenta;
        private MyICommand addRoadCommand;

        public int Id { get => id; set => id = value; }
        public string ImeKlijenta { get => imeKlijenta; set => imeKlijenta = value; }
        public string PrezKlijenta { get => prezKlijenta; set => prezKlijenta = value; }
        public MyICommand AddRoadCommand { get => addRoadCommand; set => addRoadCommand = value; }

        public KlijentViewModel()
        {
            klijentTemp = new ObservableCollection<Klijent>(Klijenti);
            AddRoadCommand = new MyICommand(OnAdd);
        }


        public void OnAdd()
        {
            //CurrentRoad.Validate();
            //  if (CurrentRoad.IsValid)
            //{
            var context = new KmpIgreDBModelContext();
            Klijent k = new Klijent();
            k.IdKlijenta = 1;
            k.ImeKlijenta = ImeKlijenta;
            k.PrezKlijenta = PrezKlijenta;
            k.Tikets = new List<Tiket>();
            context.Klijents.Add(k);
            context.SaveChanges();


                //Road road = new Road(CurrentRoad.Id, CurrentRoad.Naziv, CurrentRoad.Izbor);
                //Roads.Add(road);
                //RoadsTemp = new ObservableCollection<Road>(Roads);
                //CurrentRoad = new Road();

            //}

        }
    }
}
