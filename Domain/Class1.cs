namespace Domain
{
    public class Person
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Family { get; set; }
        public string? Nickname { get; set; }
    }
    public class Player : Person
    {
        public required Card Card { get; set; }
    }

    public class Card
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