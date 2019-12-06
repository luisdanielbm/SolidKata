using System;

namespace SolidKata._2._Open_Closed
{
    public class User
    {
        private readonly IUserService _userService;
        private readonly string Name;

        public User(string name, IUserService userService)
        {
            Name = name;
            _userService = userService;
        }
        
        public void CreateUser()
        {
            try
            {
                if (Name != "X")
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