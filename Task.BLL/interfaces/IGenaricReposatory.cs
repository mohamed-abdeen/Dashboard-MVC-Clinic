﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.BLL.interfaces
{
    public interface IGenaricReposatory<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<int> Add(T item);
        Task<int> Update(T item);

        Task<int> Delete(T item);
    }
}
