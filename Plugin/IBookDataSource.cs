using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDrivenMVVM
{
    public interface IBookDataSource
    {
        void LoadBooks();
        void RemoveBook(int bookID);
        event EventHandler<BooksLoadedEventArgs> LoadBooksCompleted;
        event EventHandler<OperationEventArgs> RemoveBookCompleted;
    }

 
}
