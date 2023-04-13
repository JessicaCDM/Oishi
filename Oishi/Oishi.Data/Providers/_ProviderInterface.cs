using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    internal interface IProvider<T>
    {
        public List<T> Get();
        public T? GetFirst(int id);
        public T Insert(T item);
        public T? Update(T item);
        public bool Delete(int id);
    }
}
