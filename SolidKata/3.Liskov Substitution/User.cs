using System;

namespace SolidKata._3.Liskov_Substitution
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

    public class AdministratorUser : User
    {
        public AdministratorUser(IUserService userService, UserTypeDirectory userType) : base(userService, userType)
        {
        }

        public void CreateAdministratorUser()
        {
            ValidateIsAdministrator();
            base.CreateUser();
        }
        
        private void ValidateIsAdministrator()
        {
            // some validation here
        }
    }
}
