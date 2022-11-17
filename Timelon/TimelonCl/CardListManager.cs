using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TimelonCl
{
    /// <summary>
    /// Менеджер списков карт и провайдер данных
    /// Допустимо существование лишь одного экземпляра этого класса
    /// (зависимость от потока)
    /// </summary>
    public sealed class CardListManager
    {
        /// <summary>
        /// Название файла с данными
        /// </summary>
        public const string FileName = "data.xml";

        /// <summary>
        /// Название директории с данными
        /// </summary>
        public const string DirectoryName = "Timelon";

        /// <summary>
        /// Экземпляр класса одиночки
        /// </summary>
        private static CardListManager _instance = null;
        
        /// <summary>
        /// Полный путь до директории "Documents"
        /// </summary>
        private string _source = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Списки карт
        /// </summary>
        private readonly SortedList<int, CardList> _list = new SortedList<int, CardList>();

        /// <summary>
        /// Закрепленные списки карт
        /// </summary>
        private readonly List<CardList> _listEssential = new List<CardList>
        {
            new CardList(0, "Задачи", true),
            new CardList(1, "Важное", true)
        };

        /// <summary>
        /// Конструктор менеджера
        /// Не может быть вызван извне
        /// </summary>
        private CardListManager()
        {
            Load();
            InjectEssentials();
        }

        /// <summary>
        /// Глобальная точка доступа к классу
        /// </summary>
        public static CardListManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardListManager();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Доступ к файлу с данными
        /// </summary>
        public string Source => Path.Combine(SourceDirectory, FileName);

        /// <summary>
        /// Доступ к директории с данными
        /// </summary>
        public string SourceDirectory => Path.Combine(_source, DirectoryName);

        /// <summary>
        /// Доступ к спискам карт
        /// </summary>
        public SortedList<int, CardList> All => _list;

        /// <summary>
        /// Получить список карт по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор списка карт</param>
        /// <returns>Список карт</returns>
        public CardList GetList(int id)
        {
            return All[id];
        }

        /// <summary>
        /// Вставить список карт
        /// </summary>
        /// <param name="list">Список карт</param>
        public void SetList(CardList list)
        {
            All[list.Id] = list;
        }

        /// <summary>
        /// Удалить список карт по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор списка карт</param>
        /// <returns>Статус успешности удаления</returns>
        public bool RemoveList(int id)
        {
            return All.Remove(id);
        }

        /// <summary>
        /// Проверить, существует ли список с указанным идентификатором
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Статус проверки</returns>
        public bool ContainsList(int id)
        {
            return All.ContainsKey(id);
        }

        /// <summary>
        /// Поиск по части названия или описания по всем подспискам
        /// </summary>
        /// <param name="content">искомое значение</param>
        /// <returns>Список найденных карт</returns>
        public List<Card> SearchByContent(string content)
        {
            List<Card> result = new List<Card>();

            foreach(KeyValuePair<int,CardList> item in All)
            {
                List<Card> found = item.Value.SearchByContent(content);

                foreach (Card card in found)
                {
                    result.Add(card);
                }
            }

            return result;
        }

        /// <summary>
        /// Внедрить закрепленные списки карт
        /// </summary>
        private void InjectEssentials()
        {
            foreach (CardList cardList in _listEssential)
            {
                if (ContainsList(cardList.Id))
                {
                    if (cardList.Name == GetList(cardList.Id).Name)
                    {
                        continue;
                    }
                }

                SetList(cardList);
            }
        }

        /// <summary>
        /// Сохранить данные в файл
        /// </summary>
        public void Sync()
        {
            Directory.CreateDirectory(SourceDirectory);

            if (!File.Exists(Source))
            {
                File.Create(Source).Close();
            }

            InjectEssentials();

            List<CardListData> data = new List<CardListData>();

            foreach (KeyValuePair<int, CardList> item in All)
            {
                data.Add(item.Value.ToData());
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<CardListData>));
            StreamWriter writer = new StreamWriter(Source);

            serializer.Serialize(writer, data);
            writer.Close();
        }

        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        private void Load()
        {
            Directory.CreateDirectory(SourceDirectory);

            if (!File.Exists(Source))
            {
                Sync();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<CardListData>));
            StreamReader reader = new StreamReader(Source);

            // TODO: Бросает неприятные исключения при "повреждении" данных в файле
            List<CardListData> data = (List<CardListData>)serializer.Deserialize(reader);

            reader.Close();
            All.Clear();

            foreach (CardListData item in data)
            {
                CardList cardList = CardList.FromData(item);

                All.Add(cardList.Id, cardList);
            }

            InjectEssentials();
        }
    }
}
