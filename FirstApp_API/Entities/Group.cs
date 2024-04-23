namespace FirstApp_API.Entities
{
    public class Group : BaseEntity 
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;       
       
        public string Profession { get; set; } = null!;

        public List<GroupMember> GroupMember { get; set; }


    }
}
