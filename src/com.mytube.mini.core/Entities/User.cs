using System;
using com.mytube.mini.core.Contracts;

namespace com.mytube.mini.core.Entities
{
    public class User : IEntity, IEntityCreatable
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool Create()
        {
            Password = Password.CreateHash();
            return true;
        }
    }
}
