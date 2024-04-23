namespace FirstApp_API.Entities
{
    public class Member
    {

        public int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string  Role { get; set; }

        public List<GroupMember> GroupMember { get; set; }
    }
}
