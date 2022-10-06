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

        private int _id;
        private string _name;
        private string _description = "";

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
        private int _priority = DEFAULT_PRIORITY;

        //bool favourite - избранное
        //DateTime datePlaned - когда нужно сделать

        private bool _isDone = false;

        //Когда карточку меняли последний раз
        private DateTime _lastChange;

        public Card(int id, string name, string desc = "", int priority = DEFAULT_PRIORITY, bool isDone = false)
        {
            _id = id;
            _name = name;
            _description = desc;
            _isDone = isDone;
            _priority = priority;
            _lastChange = DateTime.Now; // TODO: Придумать дефолт значение для передачи в конструктор
        }

        // Для тестов
        public static Card Random()
        {
            Card card = new Card(
                Util.Random().Next(0, 1024),
                Util.RandomString(8, 16),
                Util.RandomString(16),
                Util.Random().Next(1, 5),
                Util.RandomBool()
            );

            card._lastChange = Util.RandomDateTime();

            return card;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }

        public DateTime LastChange
        {
            get { return _lastChange; }
        }

        // TODO: Переделать
        public Card Update()
        {
            _lastChange = DateTime.Now;

            return this;
        }

        // Для тестов
        // TODO: Использовать json?
        public override string ToString()
        {
            return $"ID: {Id}\nNAME: {Name}\nDESC: {Description}\nDONE: {IsDone}\nPRIOR: {Priority}\nCHANGED: {LastChange}";
        }
    }
}
