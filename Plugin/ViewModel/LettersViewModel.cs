using Plugin.App.DataSource;
using Plugin.App.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using Plugin.App.EventArgument;

/// <summary>
/// ViewModel representation
/// </summary>
namespace Plugin.App.ViewModel
{
    /// <summary>
    /// Initializes a new instance of the LettersViewModel class.
    /// </summary>
    public class LettersViewModel : ViewModelBase
    {
        private readonly ILetterDataSource LetterDataSource;
        private Letter selectedEditedLetter;
        private bool CanSaveChanges;
        /// <summary>
        /// Load letter Command
        /// </summary>
        public RelayCommand LoadLettersCommand { get; }

        /// <summary>
        /// Save letter command
        /// </summary>
        public RelayCommand SaveLetterCommand { get; }

        /// <summary>
        /// Remove letter command
        /// </summary>
        public RelayCommand RemoveLetterCommand { get; }


        private ObservableCollection<Letter> letters;
        /// <summary>
        /// DataContext for Letters Source
        /// </summary>
        public ObservableCollection<Letter> Letters
        {
            get => letters;
            set
            {
                letters = value;
                RaisePropertyChanged("Letters");
            }
        }

        private Letter selectedLetter;
        /// <summary>
        /// DataContext of Selected Letter
        /// </summary>
        public Letter SelectedLetter
        {
            get => selectedLetter;
            set
            {
                selectedLetter = value;
                LetterDetailVM.Letter = selectedLetter;
                CanSaveChanges = false;
                RaisePropertyChanged("SelectedLetter");
            }
        }


        private LetterDetailViewModel letterDetailViewModel;
        /// <summary>
        /// DataContext of LetterDetailViewModel
        /// </summary>
        public LetterDetailViewModel LetterDetailVM
        {
            get => letterDetailViewModel;
            set
            {
                letterDetailViewModel = value;
                RaisePropertyChanged("LetterDetailVM");
            }
        }

        /// <summary>
        ///  Initializes a new instance of the LetterDetailViewModel class.
        /// </summary>
        /// <param name="LetterDataSource">ILetterDataSource</param>
        public LettersViewModel(ILetterDataSource LetterDataSource)
        {
            this.LetterDataSource = LetterDataSource;
            LetterDataSource.OperationCompleted += new EventHandler<LetterEventArgs>(LetterDataSource_OperationCompleted);
            LetterDetailVM = new LetterDetailViewModel();
            LetterDetailVM.OnEdit += LetterDetailVM_OnEdit;
            LoadLettersCommand = new RelayCommand(LoadLetters);
            RemoveLetterCommand = new RelayCommand(RemoveLetter);
            SaveLetterCommand = new RelayCommand(() => SaveLetter(), () => CanSaveChanges);
            CanSaveChanges = false;
        }

        /// <summary>
        /// Letter Operation Subscriber
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">LetterEventArgs</param>
        private void LetterDataSource_OperationCompleted(object sender, LetterEventArgs e)
        {
            Letters = new ObservableCollection<Letter>(e.Letters);
            if (e.OperationType == Enumeration.OperationType.Update)
            {
                SelectedLetter = e.SelectedLetter;
            }
        }

        /// <summary>
        /// Load list of Letters
        /// </summary>
        public void LoadLetters()
        {
            LetterDataSource.LoadLetters();
        }

        /// <summary>
        /// Save Letter Changes
        /// </summary>
        public void SaveLetter()
        {
            LetterDataSource.UpdateLetter(selectedEditedLetter);
        }

        /// <summary>
        /// Remove Letter
        /// </summary>
        public void RemoveLetter()
        {
            LetterDataSource.RemoveLetter(SelectedLetter);
        }

        /// <summary>
        /// Subscriber of event from Letter Detail View Model
        /// </summary>
        /// <param name="Letter">Letter</param>
        private void LetterDetailVM_OnEdit(Letter Letter)
        {
            if (SelectedLetter != null && Letter != null)
            {
                if (SelectedLetter.GetHashCode() != Letter.GetHashCode() && SelectedLetter.LetterID == Letter.LetterID)
                {
                    CanSaveChanges = true;
                    selectedEditedLetter = Letter;
                }
                else
                {
                    CanSaveChanges = false;
                }
            }
        }
    }
}
