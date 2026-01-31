using PokerAnalysis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerAnalysis.Commands
{
    internal class TodoItemRemovedCommand : CommandBase
    {
        private readonly TodoItemListingViewModel _todoItemListingViewModel;

        public TodoItemRemovedCommand(TodoItemListingViewModel todoItemListingViewModel)
        {
            _todoItemListingViewModel = todoItemListingViewModel;
        }

        public override void Execute(object? parameter)
        {
            _todoItemListingViewModel.RemoveTodoItem(_todoItemListingViewModel.RemovedTodoItemViewModel);
        }

    }
}
