using System;

namespace TimelonCl
{
    public class Card
    {
        private int _id;
        private string _name;
        private string _description;
        private bool _isImportant;
        private bool _isCompleted;

        //DateTime datePlaned - когда нужно сделать

        //Когда карточку меняли последний раз
        private DateTime _lastUpdate;

        public Card(int id, string name, string desc, bool isImportant, bool isCompleted, DateTime change)
        {
            Id = id;
            Name = name;
            Description = desc;
            IsImportant = isImportant;
            IsCompleted = isCompleted;

            _lastUpdate = change;
        }

        public Card(int id, string name, string desc = "")
        {
            Id = id;
            Name = name;
            Description = desc;
            IsImportant = false;
            IsCompleted = false;

            _lastUpdate = DateTime.Now;
        }

        // Для тестов
        public static Card Random()
        {
            return new Card(
                Util.Random.Next(0, 1024),
                Util.NextString(4, 8),
                Util.NextString(16, 32),
                Util.NextBool(),
                Util.NextBool(),
                Util.NextDateTime()
            );
        }

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("id не может быть отрицательным числом");
                }

                _id = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                value = value.Trim();

                if (value.Length == 0)
                {
                    throw new ArgumentException("name не может быть пустой строкой");
                }

                _name = value;
            }
        }

        public string Description
        {
            get => _description;
            set => _description = value.Trim();
        }

        public bool IsImportant
        {
            get => _isImportant;
            set => _isImportant = value;
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }

        public DateTime LastUpdate => _lastUpdate;

        // TODO: Переделать
        public Card Update()
        {
            _lastUpdate = DateTime.Now;

            return this;
        }

        // Для тестов
        // TODO: Использовать json?
        public override string ToString()
        {
            return $"ID: {Id}\nNAME: {Name}\nDESC: {Description}\n" +
                $"IMPORTANT: {IsImportant}\nCOMPLETE: {IsCompleted}\nCHANGED: {LastUpdate}";
        }
    }
}
