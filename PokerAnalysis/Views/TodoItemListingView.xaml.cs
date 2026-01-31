using PokerAnalysis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerAnalysis.Views
{
    /// <summary>
    /// Interaction logic for TodoItemListingView.xaml
    /// </summary>
    public partial class TodoItemListingView : UserControl
    {
        public TodoItemListingView()
        {
            InitializeComponent();
        }

        // Removes Cards from one CardCollection To Another
        public object RemovedTodoItem
        {
            get { return (object)GetValue(RemovedTodoItemProperty); }
            set { SetValue(RemovedTodoItemProperty, value); }
        }

        public static readonly DependencyProperty RemovedTodoItemProperty =
            DependencyProperty.Register("RemovedTodoItem", typeof(object), typeof(TodoItemListingView), 
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        // Disables CardCollection View once it reach it's maximun number of cards
        public bool Disable
        {
            get { return (bool)GetValue(DisableProperty); }
            set { SetValue(DisableProperty, value); }
        }

        public static readonly DependencyProperty DisableProperty =
            DependencyProperty.Register("Disable", typeof(bool), typeof(TodoItemListingView), new PropertyMetadata(true));




        // Remove Cards Command
        public ICommand TodoItemRemovedCommand
        {
            get { return (ICommand)GetValue(CardRemoveCommandProperty); }
            set { SetValue(CardRemoveCommandProperty, value); }
        }

        public static readonly DependencyProperty CardRemoveCommandProperty =
            DependencyProperty.Register("TodoItemRemovedCommand", typeof(ICommand), typeof(TodoItemListingView), new PropertyMetadata(null));


        // Recieves a card from to the droped CardCollection 
        public object IncomingTodoItem
        {
            get { return (object)GetValue(IncomingTodoItemProperty); }
            set { SetValue(IncomingTodoItemProperty, value); }
        }

        public static readonly DependencyProperty IncomingTodoItemProperty =
            DependencyProperty.Register("IncomingTodoItem", typeof(object), typeof(TodoItemListingView),
                new FrameworkPropertyMetadata(null,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        // Command to Recieve the cards
        public static readonly DependencyProperty CardDropCommandProperty =
            DependencyProperty.Register("CardDropCommand", typeof(ICommand), typeof(TodoItemListingView), new PropertyMetadata(null));
       
        public ICommand CardDropCommand
        {
            get { return (ICommand)GetValue(CardDropCommandProperty); }
            set { SetValue(CardDropCommandProperty, value); }
        }
        // Gets the CardCollection of the draged cards
        public object IntialCardCollection { get; set; }

        // selection the moving card
        private void Card_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed && sender is FrameworkElement frameworkelement)
            {
                IntialCardCollection = frameworkelement.DataContext;
                DragDropEffects dragDropResult =DragDrop.DoDragDrop(frameworkelement, new DataObject(DataFormats.Serializable,
                    frameworkelement.DataContext), DragDropEffects.Move);


                if (dragDropResult == DragDropEffects.None )
                {
                    IncomingTodoItem = IntialCardCollection;
                    CardDropCommand?.Execute(null);
                }
            }
        }

        // Dropping the selected card
        private void Card_Drop(object sender, DragEventArgs e)
        {
            if(CardDropCommand?.CanExecute(null) ?? false  ) 
            {
                Disable = true;
                IncomingTodoItem = e.Data.GetData(DataFormats.Serializable);
                CardDropCommand?.Execute(null);
            }
            else
            {

                Disable = false;
                IncomingTodoItem = e.Data.GetData(DataFormats.Serializable);
                CardDropCommand?.Execute(null);
            }
        }

        // Remove the card from the intial CardCollecton View
        private void Card_DragLeave(object sender, DragEventArgs e)
        {
                object item = e.Data.GetData(DataFormats.Serializable);
                RemoveTodoItem(item);
        }


        private void RemoveTodoItem(object TodoItem)
        {
            if (TodoItemRemovedCommand?.CanExecute(null) ?? false)
            {
                RemovedTodoItem = TodoItem;
                TodoItemRemovedCommand?.Execute(null);
            }
        }

    }
}
