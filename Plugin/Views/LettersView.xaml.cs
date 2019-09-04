using Plugin.App.DataSource;
using Plugin.App.ViewModel;
using System.Windows;

namespace Plugin.App.Views
{
    /// <summary>
    /// Interaction logic for LettersView.xaml
    /// </summary>
    public partial class LettersView : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LettersView()
        {
            ILetterDataSource LetterDataSource = new MockLetterDataSource();
            LettersViewModel viewModel = new LettersViewModel(LetterDataSource);
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
