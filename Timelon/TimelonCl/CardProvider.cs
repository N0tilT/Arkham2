﻿using System.Collections.Generic;
using System.Linq;

namespace TimelonCl
{
    /// <summary>
    /// Провайдер и хранилище карт
    /// </summary>
    public class CardProvider
    {
        /// <summary>
        /// Хранилище карт
        /// </summary>
        private readonly Dictionary<int, Card> _pool = new Dictionary<int, Card>();

        /// <summary>
        /// Отсортированный по убыванию даты изменения
        /// список идентификаторов карт
        /// (сначала свежие)
        /// </summary>
        private readonly List<int> _idByLastChange = new List<int>();

        /// <summary>
        /// Отсортированный по убыванию приоритета и даты изменения
        /// список идентификаторов карт
        /// (сначала приоритетные)
        /// </summary>
        private readonly List<int> _idByPriority = new List<int>();

        /// <summary>
        /// Отсортированный по статусу выполнения и по убыванию даты изменения
        /// список идентификаторов карт
        /// (сначала невыполненные)
        /// </summary>
        private readonly List<int> _idCompleted = new List<int>();

        /// <summary>
        /// Конструктор пустого провайдера
        /// </summary>
        public CardProvider() { }

        /// <summary>
        /// Конструктор провайдера из заданного списка карт
        /// </summary>
        /// <param name="list">Список карт</param>
        public CardProvider(List<Card> list)
        {
            Set(list);
        }

        /// <summary>
        /// Доступ к хранилищу карт
        /// </summary>
        public Dictionary<int, Card> All => _pool;

        /// <summary>
        /// Получить карту из хранилища по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        /// <returns>Объект карты</returns>
        public Card Get(int id)
        {
            return _pool[id];
        }

        /// <summary>
        /// Получить отсортированный по убыванию
        /// даты изменения список карт
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListByLastChange()
        {
            List<Card> result = new List<Card>();

            foreach (int id in _idByLastChange)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Получить отсортированный по убыванию
        /// приоритета и даты изменения список карт
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListByPriority()
        {
            List<Card> result = new List<Card>();

            foreach (int id in _idByPriority)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Получить отсортированный по статусу выполнения
        /// и по убыванию даты изменения список карт
        /// </summary>
        /// <returns>Список карт</returns>
        public List<Card> GetListCompleted()
        {
            List<Card> result = new List<Card>();

            foreach (int id in _idCompleted)
            {
                result.Add(Get(id));
            }

            return result;
        }

        /// <summary>
        /// Сохранить карту
        /// </summary>
        /// <param name="card">Объект карты</param>
        public void Set(Card card)
        {
            _pool[card.Id] = card;

            Sort();
        }

        /// <summary>
        /// Сохранить несколько карт
        /// </summary>
        /// <param name="cardList">Список карт</param>
        public void Set(List<Card> cardList)
        {
            foreach (Card card in cardList)
            {
                _pool[card.Id] = card;
            }

            Sort();
        }

        /// <summary>
        /// Удалить карту с заданным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор карты</param>
        public void Remove(int id)
        {
            _pool.Remove(id);

            Sort();
        }

        /// <summary>
        /// Удалить карты с заданными идентификаторами
        /// </summary>
        /// <param name="idList">Список идентификаторов карт</param>
        public void Remove(List<int> idList)
        {
            foreach (int id in idList)
            {
                _pool.Remove(id);
            }

            Sort();
        }

        /// <summary>
        /// Отсортировать списки идентификаторов по убыванию
        /// </summary>
        private void Sort()
        {
            SortByLastChange();
            SortByPriority();
            SortByCompletion();
        }

        /// <summary>
        /// Отсортировать список идентификаторов
        /// по убыванию даты изменения
        /// (сначала свежие)
        /// </summary>
        private void SortByLastChange()
        {
            _idByLastChange.Clear();

            foreach (KeyValuePair<int, Card> card in _pool.OrderByDescending(item => item.Value.LastChange))
            {
                _idByLastChange.Add(card.Key);
            }
        }

        /// <summary>
        /// Отсортировать список идентификаторов
        /// по убыванию приоритета и даты изменения
        /// (сначала приоритетные)
        /// </summary>
        private void SortByPriority()
        {
            _idByPriority.Clear();

            // Наполнение _idByPriority из _idByLastChange (только с приоритетом)
            foreach (KeyValuePair<int, Card> card in _pool.OrderByDescending(item => item.Value.LastChange))
            {
                if (card.Value.Priority.Id == PriorityId.DEFAULT)
                {
                    continue;
                }

                _idByPriority.Add(card.Key);
            }

            // Остальные
            foreach (int id in _idByLastChange)
            {
                if (_idByPriority.Contains(id))
                {
                    continue;
                }

                _idByPriority.Add(id);
            }
        }

        /// <summary>
        /// Отсортировать список идентификаторов
        /// по статусу выполнения и убыванию даты изменения
        /// (сначала невыполненные)
        /// </summary>
        private void SortByCompletion()
        {
            _idCompleted.Clear();

            // Выборка завершенных из _idByLastChange и наполнение _idCompleted (только невыполненные)
            foreach (KeyValuePair<int, Card> card in _pool.OrderByDescending(item => item.Value.LastChange))
            {
                if (card.Value.IsCompleted == true)
                {
                    continue;
                }

                _idCompleted.Add(card.Key);
            }

            // Остальные
            foreach (int id in _idByLastChange)
            {
                if (_idCompleted.Contains(id))
                {
                    continue;
                }

                _idCompleted.Add(id);
            }
        }
    }
}