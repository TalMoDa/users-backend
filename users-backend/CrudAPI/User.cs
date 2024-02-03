namespace CrudAPI
{
    // A user class that contains information about the user to use in the dbContext and more.
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
