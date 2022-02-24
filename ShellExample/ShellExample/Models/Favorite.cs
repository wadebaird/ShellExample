using SQLite;

namespace ShellExample.Models;

public class Favorite : MonthDayYearEntity
{
    [Ignore]
    public Entity Entity { get; set; }

    public Favorite()
    { 
    }

    public Favorite(Entity entity)
    {
        Id = entity.Id;
        Entity = entity;
    }
}