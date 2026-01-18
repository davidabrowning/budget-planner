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

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (ToggleButton.Content.ToString().Contains("ON"))
                ToggleButton.Content = "Toggle: OFF";
            else
                ToggleButton.Content = "Toggle: ON";
        }

        private async void TransactionsView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}