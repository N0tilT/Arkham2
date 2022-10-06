using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TimelonCl
{
    public class Card
    {
        int id;
        string name;
        string description = "";

        bool done = false;

        int priority = 5;  //1-5

        /*
        Color prioritycolor;

        List<Color> priorities = new List<Color> 
        { Color.FromRgb(255,0,0),   //Красный - максимальный
            Color.FromRgb(255,125,0),   //Оранжевый
            Color.FromRgb(255, 255, 0),     //Жёлтый
            Color.FromRgb(0, 255, 0),   //Зелёный
            Color.FromRgb(0, 255, 255)  //Бирюзовый
        };

        bool favourite - избранное
        DateTime datePlaned - когда нужно сделать

        */

        DateTime dateChanged;   //Когда карточку меняли последний раз

        static Random rnd = new Random();

        public Card(string inputName)
        {
            dateChanged = DateTime.Now;
            id = rnd.Next(100,999); //rework
            name = inputName;
        }

        public Card Random()
        {
            Card randcard = new Card(rnd.Next(0,100).ToString());
            randcard.description = rnd.Next(0, 100).ToString();
            randcard.priority = rnd.Next(1, 5);
            randcard.SetDateChanged = new DateTime(2022, 10, rnd.Next(1, 31));
            return randcard;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value;}
        }

        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        public void Update()
        {
            dateChanged = DateTime.Now;
        }

        public DateTime GetDateChanged
        {
            get { return dateChanged; }
        }

        private DateTime SetDateChanged
        {
            set { dateChanged = value; }
        }
        


    }
}
