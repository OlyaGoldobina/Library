using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfClasses
{
    public interface IRepository<T> 
    {   
        bool UpdateItem(T item, T item1);
        bool AddItem(T item);
        bool RemoveItem(T item);
        List<T> SelectItem();
    }
}
