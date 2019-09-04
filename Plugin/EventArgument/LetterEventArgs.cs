using Plugin.Application.Enumeration;
using Plugin.Application.Model;
using System;
using System.Collections.Generic;

namespace Plugin.Application.EventArgument
{
    /// <summary>
    /// Class represents to get notified of the results of operations by events, such as Add, load, remove, and update
    /// </summary>
    public class LetterEventArgs : EventArgs
    {
        public IEnumerable<Letter> Letters { get; set; }
        public Letter SelectedLetter { get; set; }
        public OperationType OperationType { get; set; }
        public LetterEventArgs(IEnumerable<Letter> letters, Letter selectedLetter, OperationType operationType)
        {
            Letters = letters;
            SelectedLetter = selectedLetter;
            OperationType = operationType;
        }
    }
}
