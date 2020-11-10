using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public UserEnum Type { get; set; }

        [DataMember]
        public bool IsBlocked { get; set; }

        [DataMember]
        public bool PasswordRestriction { get; set; }
    }
}
