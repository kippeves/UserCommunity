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

        [JsonProperty("Position")]
        public string Position { get; set; }
        [JsonProperty("Department")]
        public string Department { get; set; }
        [JsonProperty("DarkSecret")]
        public string DarkSecret { get; set; }
        [JsonProperty("TimeAtWork")]
        public int TimeAtWork { get; set; }

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
