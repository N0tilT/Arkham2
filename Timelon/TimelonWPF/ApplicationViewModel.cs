using System;
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
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private Card _selectedCard;

        private CardList _selectedList;
        private Manager _listManager;
        private ObservableCollection<CardList> _lists = new ObservableCollection<CardList>();

        private ObservableCollection<Card> _defaultCards = new ObservableCollection<Card>();
        private ObservableCollection<Card> _doneCards = new ObservableCollection<Card>();

        private ObservableCollection<Manager> _manager = new ObservableCollection<Manager>();

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Card rCard = obj as Card;
                        if (rCard != null)
                        {
                            DefaultCards.Remove(rCard);
                        }
                    },
                    (obj) => DefaultCards.Count > 0));
            }
        }

        private RelayCommand cardDoneCommand;

        public RelayCommand CardDoneCommand
        {
            get
            {
                return cardDoneCommand ??
                    (cardDoneCommand = new RelayCommand(obj =>
                    {
                        Card completed = obj as Card;
                        if (!completed.IsCompleted)
                        {
                            completed.IsCompleted = true;
                            SelectedList.Set(completed);

                            DefaultCards = new ObservableCollection<Card>(SelectedList.GetListDefault());
                            DoneCards = new ObservableCollection<Card>(SelectedList.GetListCompleted());
                        }
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
                        ListManager.SetList(newList);
                        Lists.Add(newList);
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
                        DefaultCards.Add(newCard);
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
                        SelectedList = new CardList(0, "searchResult", true, _listManager.SearchByContent(tmp.Text));
                    }));
            }
        }


        public ObservableCollection<CardList> Lists { get { return _lists; } set { _lists = value; } }
        public ObservableCollection<Card> DefaultCards 
        { 
            get 
            {
                return _defaultCards;
            } 
            set 
            {
                _defaultCards = value;
                OnPropertyChanged("DefaultCards");
            } 
        }

        public ObservableCollection<Card> DoneCards 
        { 
            get 
            {
                return _doneCards;
            } 
            set 
            {
                _doneCards = value;
                OnPropertyChanged("DoneCards");
            } 
        }
        public Manager ListManager { get { return _listManager; } set { _listManager = value; } }

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
                DefaultCards = new ObservableCollection<Card>(_selectedList.GetListDefault());
                DoneCards = new ObservableCollection<Card>(_selectedList.GetListCompleted());
                OnPropertyChanged("SelectedList");
            }
        }

        public ApplicationViewModel()
        {
            ListManager = Manager.Instance;

            SelectedList = ListManager.All[0];

            Lists = new ObservableCollection<CardList>(ListManager.All.Values);

            SelectedList.Set(Card.Make("Test1"));
            SelectedList.Set(Card.Make("Test2"));
            SelectedList.Set(Card.Make("Test3"));

            DefaultCards = new ObservableCollection<Card>(SelectedList.GetListDefault());
            DoneCards = new ObservableCollection<Card>(SelectedList.GetListCompleted());

        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
