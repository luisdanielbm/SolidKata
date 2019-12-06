using System;

namespace SolidKata._2._Open_Closed
{
    public class User
    {
        private readonly IUserRepository _userRepository;
        private readonly string Name;

        public User(string name, IUserRepository userRepository)
        {
            Name = name;
            _userRepository = userRepository;
        }
        
        public void CreateUser()
        {
            try
            {
                if (Name != "X")
                {
                    _userRepository.Add();
                }
                else
                {
                    _userRepository.AddAsGuest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}