using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; } // Имя пользователя

        [DataMember]
        public string Password { get; set; } // Пароль в захэшированном виде

        [DataMember]
        public UserEnum Type { get; set; } // Статус пользователя (админ или обычный)

        [DataMember]
        public bool IsBlocked { get; set; } // Статус блокировки

        [DataMember]
        public bool PasswordRestriction { get; set; } // Ограничения на пароль
    }
}
