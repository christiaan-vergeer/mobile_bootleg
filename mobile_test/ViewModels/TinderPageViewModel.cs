using mobile_test.Core;
using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace mobile_test.ViewModels
{
    public class TinderPageViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

        private uint _threshold;

        public TinderPageViewModel()
        {
            InitializeProfiles();

            Threshold = (uint)(App.ScreenWidth / 3);

            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Command<DraggingCardEventArgs>(OnDraggingCommand);

            ClearItemsCommand = new Command(OnClearItemsCommand);
            AddItemsCommand = new Command(OnAddItemsCommand);
        }

        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                RaisePropertyChanged();
            }
        }

        public uint Threshold
        {
            get => _threshold;
            set
            {
                _threshold = value;
                RaisePropertyChanged();
            }
        }

        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }

        private void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
        }

        private void OnDraggingCommand(DraggingCardEventArgs eventArgs)
        {
            switch (eventArgs.Position)
            {
                case DraggingCardPosition.Start:
                    return;

                case DraggingCardPosition.UnderThreshold:
                    break;

                case DraggingCardPosition.OverThreschold:
                    break;

                case DraggingCardPosition.FinishedUnderThreshold:
                    return;

                case DraggingCardPosition.FinishedOverThreshold:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnClearItemsCommand()
        {
            People.Clear();
        }

        private void OnAddItemsCommand()
        {
        }

        private void InitializeProfiles()
        {
            new Person { Id = Guid.NewGuid().ToString(), Age = 18, FirstName = "Belle", LastName = "Bell", Bio = "Ik hou van bellen.", gender = Gender.Female, prefference = Prefference.Female };
            new Person { Id = Guid.NewGuid().ToString(), Age = 19, FirstName = "Dum", LastName = "Dumber", Bio = "Ik Ben niet zo slim.", gender = Gender.Male, prefference = Prefference.Female };
            new Person { Id = Guid.NewGuid().ToString(), Age = 21, FirstName = "Ambie", LastName = "Bambie", Bio = "Boe!", gender = Gender.Female, prefference = Prefference.Male };
            new Person { Id = Guid.NewGuid().ToString(), Age = 41, FirstName = "Midlife", LastName = "Crisis", Bio = "Ik heb een veels te dure sport auto.", gender = Gender.Male, prefference = Prefference.Female };
            new Person { Id = Guid.NewGuid().ToString(), Age = 26, FirstName = "Bier", LastName = "Brouwer", Bio = "Ik houdt van bier.", gender = Gender.Male, prefference = Prefference.Female };
            new Person { Id = Guid.NewGuid().ToString(), Age = 31, FirstName = "Bob", LastName = "Bouwer", Bio = "Ik bouw shit.", gender = Gender.Male, prefference = Prefference.Male };
            new Person { Id = Guid.NewGuid().ToString(), Age = 62, FirstName = "Jan", LastName = "Jansen", Bio = "ik ben Jan.", gender = Gender.Neutral, prefference = Prefference.Neutral };
        }
    }
}
