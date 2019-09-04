using Plugin.App.EventArgument;
using Plugin.App.Model;
using System;

/// <summary>
/// Data Source Implementation of Letter
/// </summary>
namespace Plugin.App.DataSource
{
    /// <summary>
    /// Interface that specifies how the View Model will interact with the Model
    /// </summary>
    public interface ILetterDataSource
    {
        /// <summary>
        /// Load Letters
        /// </summary>
        void LoadLetters();

        /// <summary>
        /// Add Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        void AddLetter(Letter letter);

        /// <summary>
        /// Remove Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        void RemoveLetter(Letter letter);

        /// <summary>
        /// Update Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        void UpdateLetter(Letter letter);

        /// <summary>
        /// Event Argument of Operation for Letter
        /// </summary>
        event EventHandler<LetterEventArgs> OperationCompleted;
    }
}
