using System;
using SolidKata._2._Open_Closed;

namespace SolidKata._2
{
    public class User
    {
        private readonly IUserService _userService;
        private readonly UserTypeDirectory _userType;

        public User(IUserService userService, UserTypeDirectory userType)
        {
            _userService = userService;
            _userType = userType;
        }
        
        public void CreateUser()
        {
            try
            {
                if (_userType != UserTypeDirectory.Guest)
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