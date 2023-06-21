namespace ResearchHub
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
        public string Organization { get; set; }
        public string PersonalOrcid { get; set; }
    }

    public enum RoleType
    {
        Researcher,
        Administrator
    }
}
