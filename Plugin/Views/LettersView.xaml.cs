using Plugin.Application.DataSource;
using Plugin.Application.ViewModel;
using System.Windows;

namespace Plugin.Application.Views
{
    /// <summary>
    /// Interaction logic for LettersView.xaml
    /// </summary>
    public partial class LettersView : Window
    {
        public LettersView()
        {
            ILetterDataSource LetterDataSource = new MockLetterDataSource();
            LettersViewModel viewModel = new LettersViewModel(LetterDataSource);
            InitializeComponent();
            DataContext = viewModel;

        }
    }
}
