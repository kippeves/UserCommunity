using System.Collections.Generic;

namespace UserCommunity.Data
{
    public interface IDataSource<T>
    {
        public IEnumerable<T> LoadAll();
        public T Update(T _object);
        public T LoadById(int i);
        public void Save(T _object);
        public bool Delete(T _object);
    }
}