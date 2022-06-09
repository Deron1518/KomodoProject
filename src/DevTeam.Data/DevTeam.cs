
public class DevTeam
{
    public DevTeam(){}
    public DevTeam(string name)
    {
        Name = name;
    }
    public DevTeam(string name, List<DeveloperData> developers)
    {
        Name = name;
        Developers = developers;
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public List<DeveloperData> Developers { get; set; } = new List<DeveloperData>();
}
