using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface ICRUD
    {
        Task<T> Create<T>(T objectForDb) where T : class;

        Task<T> Read<T>(int entityId) where T : class;

        Task<List<T>> ReadAll<T>() where T : class;

        Task<T> Update<T>(T objectToUpdate, int entityId) where T : class;

        Task<bool> Delete<T>(int entityId) where T : class;
    }
}
