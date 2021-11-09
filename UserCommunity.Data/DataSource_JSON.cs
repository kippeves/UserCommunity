using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UserCommunity.DTO;

namespace UserCommunity.Data
{
    public class DataSource_JSON: IDataSource<UserDTO>
    {
        readonly string path = @"C:\Users\pelle\Source\Repos\UserCommunity1\UserCommunity.Data\files\users.json";


        public bool Delete(UserDTO _object)
        {
            if (null != LoadById(_object.ID))
            {
                UserDTO NewUser = _object;
                List<UserDTO> users = LoadAll().ToList();
                users.RemoveAll(OldUser => OldUser.ID == NewUser.ID);
                users.Sort();
                File.WriteAllText(path, JsonConvert.SerializeObject(users));
                return true;
            }
            else return false;
        }

        public IEnumerable<UserDTO> LoadAll()
        { 
            return JsonConvert.DeserializeObject<List<UserDTO>>(File.ReadAllText(path));
        }

        public UserDTO LoadById(int i)
        {
            return JsonConvert.DeserializeObject<List<UserDTO>>(File.ReadAllText(path)).Find(u => u.ID == i);
        }

        public void Save(UserDTO _object)
        {
            UserDTO NewUser = _object;
            List<UserDTO> users = LoadAll().ToList();
            int currentId = (users.Last().ID + 1);
            NewUser.ID = currentId;
            users.Add(NewUser);
            users.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(users));
        }

        public UserDTO Update(UserDTO _object)
        {
            UserDTO NewUser = _object;
            List<UserDTO> users = LoadAll().ToList();
            users.RemoveAll(OldUser => OldUser.ID == NewUser.ID);
            users.Add(NewUser);
            users.Sort();
            File.WriteAllText(path, JsonConvert.SerializeObject(users));
            return NewUser;
        }

       
    }
}
