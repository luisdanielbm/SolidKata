namespace SolidKata._5.Dependency_Inversion
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
