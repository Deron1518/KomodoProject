
public class DevTeamRepo
{
    private readonly List<DevTeam> _devTeamDataBase = new List<DevTeam>();
    private int _count = 0;

    public bool AddDevTeamToDataBase(DevTeam devTeam)
    {
        if(devTeam != null)
        {
            _count++;
            DevTeam.ID = _count;
            _devTeamDataBase.Add(devTeam);
        }
    }

    public List<DevTeam> GetAllTeams()
    {
        return _devTeamDataBase;
    }

    public DevTeam GetTeamByID(int id)
    {
        foreach(DevTeam t in _devTeamDataBase)
        {
            if(t.ID == id)
            {
                return t;
            }
        }
        return null;
    }
}
