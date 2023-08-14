namespace Domain
{
    public class Player
    {
        public required string Name { get; set; }
        public string? Nickname { get; set; }
        public Role? Role { get; set; }
    }

    public class Role
    {
        public required string Title { get; set; }
        public string? PicPath { get; set; }
        public string? Describtion { get; set; }
        public Side Side { get; set; }
    }
    public enum Side
    {
        Citizen,
        Mafia,
        Independ
    }
}