
public class DeveloperRepo
{
    private readonly List<DeveloperData> _developerDataBase = new List<DeveloperData>();
    private int _count; 

    public bool AddDeveloperToDataBase(DeveloperData developerData)
    {
        if(developer != null )
        {
        _count++;
        developer.ID = _count;
        _developerDataBase.Add(developer);
        return true; 
        }
        else
        {
            return false;
        }
    }
    public List<DeveloperData> GetAllDevelopers()
    {
        return _developerDataBase;
    }

    public DeveloperData GetDeveloperById(int id)
    {
        foreach(DeveloperData d in _developerDataBase)
        {
            if(d.ID == id)
            {
                return d;
            }
        }
        return null;
    }

    public bool UpdateDeveloperData (int id, developer newDeveloperdata)
    {
        var oldDeveloperData = GetDeveloperById(d.ID);
        if(oldDeveloperData != null)
        {
            oldDeveloperData.FirstName = newDeveloperData.FirstName;
            oldDeveloperData.LastName = newDeveloperData.LastName;
            oldDeveloperData.ID = newDeveloperData.ID;
            oldDeveloperData.PluralsightAccess = newDeveloperData.PluralsightAccess;
        }
    }

    public bool RemoveDeveloperDataFromDataBase(int id)
    {
        var developer = GetDeveloperById(id);

        if(developer != null)
        {
            _developerDataBase.Remove(developer);
            return true;
        }
        else
        {
            return false;
        }
    }



}
