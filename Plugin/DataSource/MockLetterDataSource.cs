using Plugin.Application.DataSource;
using Plugin.Application.Enumeration;
using Plugin.Application.EventArgument;
using Plugin.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Application.DataSource
{
    /// <summary>
    /// Represents Mock data source of letters
    /// </summary>
    public class MockLetterDataSource : ILetterDataSource
    {
        private readonly List<Letter> letters = new List<Letter>();

        /// <summary>
        /// Initializes a new instance of the MockLetterDataSource class.
        /// </summary>
        public MockLetterDataSource()
        {
            letters.Add(
                new Letter
                {
                    LetterID = 1,
                    Name = "Patient Demographics",
                    RemoteFileName = $"{Guid.NewGuid()}.docx",
                    Category = "General"
                });
            letters.Add(
               new Letter
               {
                   LetterID = 2,
                   Name = "Worker Compensation",
                   RemoteFileName = $"{Guid.NewGuid()}.docx",
                   Category = "General"
               });
            letters.Add(
               new Letter
               {
                   LetterID = 3,
                   Name = "Super Bill",
                   RemoteFileName = $"{Guid.NewGuid()}.docx",
                   Category = "General"
               });
        }

        #region ILetterDataSource Members

        /// <summary>
        /// Load Letters
        /// </summary>
        public void LoadLetters()
        {
            OperationCompleted?.Invoke(this, new LetterEventArgs(letters, null, OperationType.Read));
        }

        /// <summary>
        /// Add new Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        public void AddLetter(Letter letter)
        {
            letters.Add(letter);
            OperationCompleted?.Invoke(this, new LetterEventArgs(null,null,OperationType.Read));
        }

        /// <summary>
        /// Update Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        public void UpdateLetter(Letter letter)
        {
            Letter letterToUpdate = letters.Where(i => i.LetterID == letter.LetterID).First();
            int index = letters.IndexOf(letterToUpdate);
            if (index != -1)
            {
                letters[index] = letter;
            }
            OperationCompleted?.Invoke(this, new LetterEventArgs(letters, letter, OperationType.Update));
        }

        /// <summary>
        /// Remove Letter
        /// </summary>
        /// <param name="letter">Letter</param>
        public void RemoveLetter(Letter letter)
        {
            Letter letterToRemove = letters.Single(b => b.LetterID == letter.LetterID);
            letters.Remove(letterToRemove);
            OperationCompleted?.Invoke(this, new LetterEventArgs(letters, null, OperationType.Delete));
        }

        /// <summary>
        /// Notifies operation complete event
        /// </summary>
        public event EventHandler<LetterEventArgs> OperationCompleted;
        #endregion
    }
}

