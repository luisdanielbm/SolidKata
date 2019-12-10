using System;

namespace SolidKata._2
{
    public class User
    {
        protected readonly IUserService _userService;
        protected readonly UserTypeDirectory _userType;

        public User(IUserService userService, UserTypeDirectory userType)
        {
            _userService = userService;
            _userType = userType;
        }
        
        public virtual void CreateUser()
        {
            try
            {
                _userService.Add();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }

    public class GuestUser : User
    {
        public GuestUser(IUserService userService, UserTypeDirectory userType) : base(userService, userType)
        {
        }

        public override void CreateUser()
        {
            _userService.AddAsGuest();
        }
    }
}