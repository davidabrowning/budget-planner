using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Data.Repositories;
using BudgetPlanner.Services;
using BudgetPlanner.Wpf.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetPlanner.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransactionsViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            TransactionRepository transactionRepository = new();
            TransactionService transactionService = new(transactionRepository);
            _viewModel = new(transactionService);
            DataContext = _viewModel;
            Loaded += TransactionsView_Loaded;
        }

        private async void TransactionsView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            string amountString = NewAmount.Text;
            string commentString = NewComment.Text;
            try
            {
                int amountInt = Convert.ToInt32(amountString);
                TransactionDto newTransaction = new TransactionDto()
                {
                    Amount = amountInt,
                    Comment = commentString
                };
                _viewModel.AddTransaction(newTransaction);
                NewAmount.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteTransactionButton_Click(Object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteSelectedTransaction();
        }
    }
}