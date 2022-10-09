﻿using System;

namespace TimelonCl
{
    public class Card
    {
        private int _id;
        private string _name;
        private string _description;
        private CardPriority _priority;
        private bool _isCompleted;

        //bool favourite - избранное
        //DateTime datePlaned - когда нужно сделать

        //Когда карточку меняли последний раз
        private DateTime _lastChange;

        public Card(int id, string name, string desc, PriorityId priority, bool isCompleted, DateTime change)
        {
            _id = id;
            _name = name;
            _description = desc;
            _priority = new CardPriority(priority);
            _isCompleted = isCompleted;
            _lastChange = change;
        }

        public Card(int id, string name)
        {
            _id = id;
            _name = name;
            _description = "";
            _priority = new CardPriority(PriorityId.DEFAULT);
            _isCompleted = false;
            _lastChange = DateTime.Now;
        }

        // Для тестов
        public static Card Random()
        {
            Card card = new Card(
                Util.Random().Next(0, 1024),
                Util.RandomString(8, 16),
                Util.RandomString(16),
                CardPriority.RandomId(),
                Util.RandomBool(),
                Util.RandomDateTime()
            );

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

        public CardPriority Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }

        public DateTime LastChange => _lastChange;

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
            return $"ID: {Id}\nNAME: {Name}\nDESC: {Description}\nCOMPLETE: {IsCompleted}\nPRIOR: {Priority}\nCHANGED: {LastChange}";
        }
    }
}
