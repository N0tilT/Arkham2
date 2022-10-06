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
        public const int DEFAULT_PRIORITY = 5;

        int id;
        string name;
        string description = "";

        /**
         * TODO: Сделать класс Priority
         * 
         * Color prioritycolor;
         * 
         * List<Color> priorities = new List<Color>
         * {
         *     Color.FromRgb(255,0,0),   //Красный - максимальный
         *     Color.FromRgb(255,125,0),   //Оранжевый
         *     Color.FromRgb(255, 255, 0),     //Жёлтый
         *     Color.FromRgb(0, 255, 0),   //Зелёный
         *     Color.FromRgb(0, 255, 255)  //Бирюзовый
         * };
         */
        int priority = DEFAULT_PRIORITY;

        //bool favourite - избранное
        //DateTime datePlaned - когда нужно сделать

        bool isDone = false;

        //Когда карточку меняли последний раз
        DateTime dateChanged;

        public Card(int id, string name, string desc = "", int priority = DEFAULT_PRIORITY, bool isDone = false)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
            this.isDone = isDone;
            this.priority = priority;
            this.dateChanged = DateTime.Now; // TODO: Придумать дефолт значение для передачи в конструктор
        }

        public static Card Random()
        {
            Card card = new Card(
                Util.Random().Next(0, 1024),
                Util.RandomString(8, 16),
                Util.RandomString(16),
                Util.Random().Next(1, 5),
                Util.RandomBool()
            );

            card.dateChanged = Util.RandomDateTime();

            return card;
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
            set { priority = value; }
        }

        public bool Done
        {
            get { return isDone; }
            set { isDone = value; }
        }

        public Card Update()
        {
            dateChanged = DateTime.Now;

            return this;
        }

        public DateTime GetDateChanged
        {
            get { return dateChanged; }
        }

        public override string ToString()
        {
            return $"ID: {id}\nNAME: {name}\nDESC: {description}\nDONE: {isDone}\nPRIOR: {priority}\nCHANGED: {dateChanged}";
        }
    }
}
