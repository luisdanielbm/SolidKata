using System;

namespace SolidKata._5.Dependency_Inversion
{
    public class UserRepository
    {
        private readonly IDatabase _database;

        private readonly Logger _logger = new Logger();

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        public void CreateUser(User user)
        {
            try
            {
                _database.Add(user);
                _logger.Success("");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                throw new Exception(ex.ToString());
            }
        }
    }
}
