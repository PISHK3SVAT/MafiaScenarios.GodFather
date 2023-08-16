namespace Domain
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public RoleCard? Role { get; set; }
    }
}