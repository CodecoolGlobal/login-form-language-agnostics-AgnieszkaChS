using System;
namespace LoginForm.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }

        public User()
        {
        }

        public User(int id, string name, string email, string pass)
        {
            Id = id;
            Name = name;
            Email = email;
            Pass = pass;
        }
    }
}
