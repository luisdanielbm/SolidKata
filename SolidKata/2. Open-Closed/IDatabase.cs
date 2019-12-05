namespace SolidKata._2._Open_Closed
{
    public interface IDatabase
    {
        void Add(User user);
        void AddAsGuest(User user);
    }
}