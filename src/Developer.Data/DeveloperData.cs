

public class DeveloperData
{
    public DeveloperData (string firstName, string lastName, bool pluralsightAccess)
    {
        FirstName = firstName;
        LastName = lastName;
        ID = id;
        PluralsightAccess = pluralsightAccess;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public bool PluralsightAccess { get; set; }
}
