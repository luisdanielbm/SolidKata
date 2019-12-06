using System;

namespace SolidKata._5.Dependency_Inversion
{
    public class Logger
    {
        public void Error(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void Success(string successMessage)
        {
            Console.WriteLine(successMessage);
        }
    }
}