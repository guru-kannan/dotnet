namespace CustomerEntities;
public class Customer
{
    public Customer() {}
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Id { get; set; }

    public Customer(string FirstName, string LastName, string Email, string Password, int Id)
    {
        FirstName = FirstName;
        LastName = LastName;
        Email = Email;
        Password = Password;
        Id = Id;
    }
    public override string ToString()
    {
        return $"FirstName: {FirstName}, LastName: {LastName}, Email: {Email}";
    }
}