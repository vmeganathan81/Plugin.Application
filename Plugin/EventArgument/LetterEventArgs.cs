using Plugin.App.Enumeration;
using Plugin.App.Model;
using System;
using System.Collections.Generic;

/// <summary>
/// EventArgs of Letter Operations
/// </summary>
namespace Plugin.App.EventArgument
{
    /// <summary>
    /// Class represents to get notified of the results of operations by events, such as Add, load, remove, and update
    /// </summary>
    public class LetterEventArgs : EventArgs
    {
        /// <summary>
        /// Letters
        /// </summary>
        public IEnumerable<Letter> Letters { get; set; }

        /// <summary>
        /// Selected Letter
        /// </summary>
        public Letter SelectedLetter { get; set; }

        /// <summary>
        /// Operation Type
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Letter Event Arguments
        /// </summary>
        /// <param name="letters">IEnumerable</param>
        /// <param name="selectedLetter">Letter</param>
        /// <param name="operationType">OperationType</param>
        public LetterEventArgs(IEnumerable<Letter> letters, Letter selectedLetter, OperationType operationType)
        {
            Letters = letters;
            SelectedLetter = selectedLetter;
            OperationType = operationType;
        }
    }
}
