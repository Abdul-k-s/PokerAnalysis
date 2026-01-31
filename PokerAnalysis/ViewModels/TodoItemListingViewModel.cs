using PokerAnalysis.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PokerAnalysis.ViewModels
{
    public class TodoItemListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TodoItemViewModel> _todoItemViewModels;
        public IEnumerable<TodoItemViewModel> TodoItemViewModels => _todoItemViewModels;
        public ICommand CardReceivedCommand { get; }
        public ICommand PlayerReceivedCommand { get; }
        public ICommand RiverReceivedCommand { get; }
        public ICommand TodoItemRemovedCommand { get; }
        private TodoItemViewModel _removedTodoItemViewModel;

        public TodoItemViewModel RemovedTodoItemViewModel
        {
            get
            {
                return _removedTodoItemViewModel;
            }
            set
            {
                _removedTodoItemViewModel = value;
                OnPropertyChanged(nameof(RemovedTodoItemViewModel));
            }
        }

        private TodoItemViewModel _incomingTodoItem;
        public TodoItemViewModel IncomingTodoItemViewModel
        {
            get
            {
                return _incomingTodoItem;
            }
            set
            {
                _incomingTodoItem = value;
                OnPropertyChanged(nameof(IncomingTodoItemViewModel));
            }
        }

        public TodoItemListingViewModel()
        {

            _todoItemViewModels = new ObservableCollection<TodoItemViewModel>();
            CardReceivedCommand = new CardReceivedCommand(this);
            TodoItemRemovedCommand = new TodoItemRemovedCommand(this);
            PlayerReceivedCommand = new PlayerReceivedCommand(this);
            RiverReceivedCommand = new RiverReceivedCommand(this);

        }
        public void AddTodoItem(TodoItemViewModel item) 
        { 
            if(!_todoItemViewModels.Contains(item))
            {
                _todoItemViewModels.Add(item);
            }
        }
        public void RemoveTodoItem(TodoItemViewModel item) 
        {
            _todoItemViewModels.Remove(item);
            
        }
        public int Getlength () { return  _todoItemViewModels.Count; }
        
        
    }
}
