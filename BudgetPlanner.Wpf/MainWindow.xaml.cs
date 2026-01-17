using BudgetPlanner.Core.Dtos;
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
            _viewModel = new();
            DataContext = _viewModel;
            Loaded += TransactionsView_Loaded;
        }

        private async void TransactionsView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            string amountString = AmountInput.Text;
            try
            {
                int amountInt = Convert.ToInt32(amountString);
                _viewModel.Transactions.Add(new TransactionDto() { Amount = amountInt });
                AmountInput.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteTransactionButton_Click(Object sender, RoutedEventArgs e)
        {
            _viewModel.Transactions.Remove(_viewModel.SelectedTransaction);
            _viewModel.SelectedTransaction = null;
        }
    }
}