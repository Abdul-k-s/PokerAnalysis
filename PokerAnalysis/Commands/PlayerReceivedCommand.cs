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
    public class PlayerReceivedCommand : CommandBase
    {
        private readonly TodoItemListingViewModel _todoItemListingViewModel;


        public PlayerReceivedCommand(TodoItemListingViewModel todoItemListingView)
        {
            _todoItemListingViewModel = todoItemListingView;
        }

        public override void Execute(object? parameter)
        {
            _todoItemListingViewModel.AddTodoItem(_todoItemListingViewModel.IncomingTodoItemViewModel);

        }

        public override bool CanExecute(object? parameter)
        {
            return _todoItemListingViewModel.Getlength() < 1 && base.CanExecute(parameter);
        }

    }
}
