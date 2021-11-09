using System;
using System.Collections.Generic;
using UserCommunity.Data;
using UserCommunity.DTO;

namespace UserCommunity.Access
{
    public class DataAccess_JSON : IDataAccess<UserDTO>
    {
        private readonly IDataSource<UserDTO> _DataSource;

        public DataAccess_JSON(IDataSource<UserDTO> DataSource)
        {
            _DataSource = DataSource;
        }

        public void Delete(UserDTO _object)
        {
            _DataSource.Delete(_object);
        }

        public IEnumerable<UserDTO> LoadAll()
        {
            return _DataSource.LoadAll();
        }

        public UserDTO LoadById(int i)
        {
            return _DataSource.LoadById(i);
        }

        public void Save(UserDTO _object)
        {
            _DataSource.Save(_object);
        }

        public UserDTO Update(UserDTO obj)
        {
            return _DataSource.Update(obj);
        }
    }
}
