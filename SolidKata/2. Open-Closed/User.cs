using System;
using SolidKata._2._Open_Closed;

namespace SolidKata._2
{
    public class User
    {
        private readonly IUserService _userService;
        private readonly string _name;

        public User(string name, IUserService userService)
        {
            _name = name;
            _userService = userService;
        }
        
        public void CreateUser()
        {
            try
            {
                if (_name != "X")
                {
                    _userService.Add();
                }
                else
                {
                    _userService.AddAsGuest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}