using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserCommunity.DTO
{
    public class UserDTO : IComparable<UserDTO>
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string SurName { get; set; }
        [JsonProperty("Email")]
        [MinLength(6)]
        public string Email { get; set; }

        public int CompareTo(UserDTO other)
        {
            if (this.ID > other.ID)
                return 1;
            if (this.ID < other.ID)
                return -1;
            else
                return 0;
        }
    }
}
