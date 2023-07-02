using LogHub.Shared.Model;

namespace LogHub.Server.Data;

public class SeedData
{
    public static void Initialize(LogHubContext db)
    {
        var users = new User[]
        {
                new User()
                {
                    Name = "John",
                    Email = "john@gmail.com",
                    Role = "Researcher",
                    Organization = "UoS",
                    PersonalOrcid = "ABCD1234"
                },
                new User()
                {
                    Name = "Jack",
                    Email = "jack@outlook.com",
                    Role = "Administrator",
                    Organization = "The UK Government",
                    PersonalOrcid = "DCBA4321"
                }
        };
        db.Users.AddRange(users);
        db.SaveChanges();
    }
}
