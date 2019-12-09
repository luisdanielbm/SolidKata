﻿using System;

namespace SolidKata._1.Single_Responsibility
{
    public class UserRepository
    {
        private readonly  IDatabase _database;

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        public void CreateUser(User user)
        {
            try
            {
                if (user.GetUserType() == UserTypeDirectory.Guest)
                {
                    throw new Exception();
                }

                _database.Add(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}