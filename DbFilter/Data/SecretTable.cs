namespace DbFilter.Data;

public class SecretTable
{
    public int Id { get; set; }
    
    public int IdOwner { get; set; }
    
    public string SomeSecretKey { get; set; }
    
    public string AllowedUsers { get; set; }
}