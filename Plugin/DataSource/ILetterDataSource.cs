using Plugin.Application.EventArgument;
using Plugin.Application.Model;
using System;

namespace Plugin.Application.DataSource
{
    /// <summary>
    /// Interface that specifies how the View Model will interact with the Model
    /// </summary>
    public interface ILetterDataSource
    {
        void LoadLetters();
        void AddLetter(Letter letter);
        void RemoveLetter(Letter letter);
        void UpdateLetter(Letter letter);

        event EventHandler<LetterEventArgs> OperationCompleted;
    }
}
