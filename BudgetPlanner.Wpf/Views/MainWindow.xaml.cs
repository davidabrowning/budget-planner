using BudgetPlanner.Core.Dtos;
using BudgetPlanner.Core.Enums;
using BudgetPlanner.Core.Interfaces;
using BudgetPlanner.Data.Repositories;
using BudgetPlanner.Services;
using BudgetPlanner.Wpf.ViewModels;
using System.Reflection;
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

namespace BudgetPlanner.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

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
            TransactionDto? newTransaction = GetNewTransaction();
            if (newTransaction == null)
                return;
            _viewModel.AddTransaction(newTransaction);
            NewAmount.Text = string.Empty;
        }

        private void EditTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionDto? selectedTransaction = GetClickedTransaction(sender);
            if (selectedTransaction == null)
                return;
            _viewModel.SetSelectedTransaction(selectedTransaction);
            AddEditTransactionTabGroup.SelectedItem = EditTab;
        }

        private void UpdateTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdateSelectedTransaction();
            AddEditTransactionTabGroup.SelectedItem = AddTab;
        }

        private void DeleteTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteSelectedTransaction();
        }

        private TransactionDto? GetClickedTransaction(object sender)
        {
            Button? button = sender as Button;
            TransactionDto? transaction = button?.DataContext as TransactionDto;
            return transaction;
        }

        private TransactionDto? GetNewTransaction()
        {
            string amountString = NewAmount.Text;
            string commentString = NewComment.Text;
            Category category = (Category)NewCategory.SelectedItem;
            Frequency frequency = (Frequency)NewFrequency.SelectedItem;
            string yearString = NewYear.Text;
            Month month = (Month)NewMonth.SelectedItem;
            try
            {
                int amountInt = Convert.ToInt32(amountString);
                int yearInt = Convert.ToInt32(yearString);
                TransactionDto newTransaction = new TransactionDto()
                {
                    Amount = amountInt,
                    Comment = commentString,
                    Category = category,
                    Frequency = frequency,
                    Year = yearInt,
                    Month = month
                };
                return newTransaction;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}