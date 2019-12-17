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
        void UpdateItem(T item, T item1);
        void AddItem(T item);
        void RemoveItem(T item);
        DbSet SelectItem();
    }
}
