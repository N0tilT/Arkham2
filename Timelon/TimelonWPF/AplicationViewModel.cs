using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using TimelonCl;
using TimelonCl.Data;
using TimelonWPF.Core;

namespace TimelonWPF
{
    public class AplicationViewModel : INotifyPropertyChanged
    {
        private Card _selectedCard;
        private CardList _selectedList;
        private Manager _listManager;
        ObservableCollection<CardList> lists = new ObservableCollection<CardList>();
        ObservableCollection<Card> cards = new ObservableCollection<Card>();

        private RelayCommand cardDoneCommand;

        public RelayCommand CardDoneCommand
        {
            get
            {
                return cardDoneCommand ??
                    (cardDoneCommand = new RelayCommand(obj =>
                    {
                        _selectedCard.IsCompleted = true;
                        SelectedCard = _selectedCard;
                    }));
            }
        }

        private RelayCommand addListCommand;

        public RelayCommand AddListCommand
        {
            get
            {
                return addListCommand ??
                    (addListCommand = new RelayCommand(obj =>
                    {
                        TextBox tmp = obj as TextBox;
                        CardList newList = CardList.Make(tmp.Text);
                        _listManager.SetList(newList);
                        lists.Add(newList);
                        SelectedList = newList;
                    }));
            }
        }

        private RelayCommand addCardCommand;

        public RelayCommand AddCardCommand
        {
            get
            {
                return addCardCommand ??
                    (addCardCommand = new RelayCommand(obj =>
                    {
                        TextBox tmp = obj as TextBox;
                        Card newCard = Card.Make(tmp.Text);
                        SelectedList.Set(newCard);
                        cards.Add(newCard);
                        SelectedCard = newCard;
                    }));
            }
        }

        private RelayCommand searchCardCommand;

        public RelayCommand SearchCardCommand
        {
            get
            {
                return searchCardCommand ??
                    (searchCardCommand = new RelayCommand(obj =>
                    {
                        TextBox tmp = obj as TextBox;
                        SelectedList = new CardList(0, "searchRuselt", true, _listManager.SearchByContent(tmp.Text));
                    }));
            }
        }


        public ObservableCollection<CardList> Lists { get { return lists; } set { lists = value; } }
        public ObservableCollection<Card> Cards { get { return cards; } set { cards = value; } }

        public Card SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                _selectedCard = value;
                OnPropertyChanged("SelectedCard");
            }
        }

        public CardList SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                cards.Clear();
                foreach (KeyValuePair<int, Card> item in SelectedList.All)
                    cards.Add(item.Value);
                OnPropertyChanged("SelectedList");
            }
        }

        public AplicationViewModel()
        {
            _listManager = Manager.Instance;

            _selectedList = _listManager.All[0];

            foreach (KeyValuePair<int, CardList> item in _listManager.All)
                lists.Add(item.Value);

            _selectedList.Set(Card.Make("Test1"));
            _selectedList.Set(Card.Make("Test2"));
            _selectedList.Set(Card.Make("Test3"));


            foreach (KeyValuePair<int, Card> item in SelectedList.All)
                cards.Add(item.Value);

        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
