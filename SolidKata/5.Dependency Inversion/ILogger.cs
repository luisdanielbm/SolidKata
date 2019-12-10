namespace SolidKata._5.Dependency_Inversion
{
    public interface ILogger
    {
        void Error(string errorMessage);
        void Success(string successMessage);
    }
}