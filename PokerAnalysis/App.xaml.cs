using PokerAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PokerAnalysis.ViewModels;
using System.Collections.ObjectModel;

namespace PokerAnalysis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //  Creating a Deck Of cards
            TodoItemListingViewModel Deck = new TodoItemListingViewModel();
            char[] Suit = { '♣','♠' , '♦', '♥' };
            string[] Value = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (char s in Suit)
            {
                foreach (string v in Value)
                {
                    Deck.AddTodoItem(new TodoItemViewModel($"{s}{v}"));
                }
            }

            //Createing card colection for each player and the river
            TodoItemListingViewModel River = new TodoItemListingViewModel();
            TodoItemListingViewModel Player1 = new TodoItemListingViewModel();
            TodoItemListingViewModel Player2 = new TodoItemListingViewModel();
            TodoItemListingViewModel Player3 = new TodoItemListingViewModel();
            TodoItemListingViewModel Player4 = new TodoItemListingViewModel();
            TodoItemListingViewModel Player5 = new TodoItemListingViewModel();
            TodoItemListingViewModel Player6 = new TodoItemListingViewModel();

            ObservableCollection<TodoItemListingViewModel> Players = new ObservableCollection<TodoItemListingViewModel>() { Player1,
            Player2,Player3,Player4,Player5,Player6};
            
            TodoViewModel todoViewModel = new TodoViewModel(Deck, River,Players);
            MainWindow = new MainWindow()
            {
                DataContext = todoViewModel
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
