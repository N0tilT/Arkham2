using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TimelonCl;
using TimelonWPF.Core;

namespace TimelonWPF.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Card _selectedCard;
        private CardList _selectedList;
        private CardListManager _listManager;

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {

                        Card card = Card.Make(obj.ToString());
                        _selectedList.Set(card);
                        _selectedCard = card;
                    }));
            }
        }

        public ObservableCollection<CardList> Lists { get; set; }
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set
            {
                _selectedCard = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            _listManager = CardListManager.Instance;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}

