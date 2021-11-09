using System.Collections.Generic;

namespace UserCommunity.Access
{
    public interface IDataAccess<T>
    {
        public IEnumerable<T> LoadAll();
        public T Update(T i);
        public T LoadById(int i);
        public void Save(T _object);
        public void Delete(T _object);
    }
}