namespace SolidKata._4.Interface_Segregation
{
    public interface IUserReadOperations
    {
        string GetAdministrator();
    }

    public interface IUserCreateOperations
    {
        void Add();
        void AddAsGuest();
    }
}
