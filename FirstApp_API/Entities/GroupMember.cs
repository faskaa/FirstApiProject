namespace FirstApp_API.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
