using Plugin.Application.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Plugin.Application.ViewModel
{
    /// <summary>
    /// Initializes a new instance of the LetterDetailViewModel class.
    /// </summary>
    public class LetterDetailViewModel : ViewModelBase
    {
        /// <summary>
        /// Delegate Letter Detail Edited
        /// </summary>
        /// <param name="Letter"></param>
        public delegate void Edited(Letter Letter);

        /// <summary>
        /// On Edit Event
        /// </summary>
        public Edited OnEdit { get; set; }

        /// <summary>
        /// Edited Command
        /// </summary>
        public RelayCommand<Letter> EditedCommand { get; }


        private Letter letter;
        /// <summary>
        /// Represents DataContext of Letter object
        /// </summary>
        public Letter Letter
        {
            get => letter;
            set
            {
                letter = value;
                RaisePropertyChanged("Letter");
            }
        }

        /// <summary>
        /// Initializes a new instance of the LetterDetailViewModel class.
        /// </summary>
        public LetterDetailViewModel()
        {
            EditedCommand = new RelayCommand<Letter>(Updated);
        }

        /// <summary>
        /// Notify the subscriber
        /// </summary>
        /// <param name="letter"></param>
        public void Updated(Letter letter)
        {
            OnEdit?.Invoke(letter);
        }
    }
}
