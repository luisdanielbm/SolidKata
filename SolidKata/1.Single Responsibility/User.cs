namespace SolidKata._1.Single_Responsibility
{
    public class User
    {
        private string Name;

        public User(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }
    }
}