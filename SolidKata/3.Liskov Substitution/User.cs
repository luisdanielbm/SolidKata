using System;
using System.Security.Cryptography.X509Certificates;

namespace SolidKata._3.Liskov_Substitution
{
    public class User
    {
        protected readonly IUserService _userService;
        protected readonly string _name;

        public User(string name, IUserService userService)
        {
            _name = name;
            _userService = userService;
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
        public GuestUser(string name, IUserService userService) : base(name, userService)
        {
        }

        public override void CreateUser()
        {
            _userService.AddAsGuest();
        }
    }

    public class AdministratorUser : User
    {
        public AdministratorUser(string name, IUserService userService) : base(name, userService)
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
