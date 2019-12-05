using System;

namespace SolidKata._2._Open_Closed
{
    public class UserRepository
    {
        private readonly IDatabase _database;

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        public void CreateUser(User user)
        {
            try
            {
                if (user.GetName() != "X")
                {
                    _database.Add(user);
                }
                else
                {
                    _database.AddAsGuest(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
