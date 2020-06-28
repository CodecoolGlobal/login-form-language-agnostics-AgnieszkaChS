using System;
using LoginForm.Models;

namespace LoginForm.DAO
{
    public interface IUser
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
        bool IsEmailRegistered(string email);
    }
}
