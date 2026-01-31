using PokerAnalysis.ViewModels;
using PokerAnalysis.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokerAnalysis.Commands
{
    public class CardReceivedCommand : CommandBase
    {

        private readonly TodoItemListingViewModel _todoItemListingViewModel;
        

        public CardReceivedCommand(TodoItemListingViewModel todoItemListingView)
        {
            _todoItemListingViewModel = todoItemListingView;
        }

        public override void Execute(object? parameter)
        {
            _todoItemListingViewModel.AddTodoItem(_todoItemListingViewModel.IncomingTodoItemViewModel);
        }

    }
}

