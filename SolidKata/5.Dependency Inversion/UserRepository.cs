using System;

namespace SolidKata._5.Dependency_Inversion
{
    public class UserRepository
    {
        private readonly IDatabase _database;
        private readonly ILogger _logger;

        public UserRepository(IDatabase database, ILogger logger)
        {
            _database = database;
            _logger = logger;
        }

        public void CreateUser(User user)
        {
            try
            {
                _database.Add(user);
                _logger.Success("");
            }
            catch (Exception)
            {
                _logger.Error("");
            }
        }
    }
}
