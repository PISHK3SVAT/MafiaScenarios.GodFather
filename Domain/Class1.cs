namespace Domain
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Nickname { get; set; }
        public RoleCard? Role { get; set; }
    }

    public class RoleCard
    {
        public required string Title { get; set; }
        public string? PicPath { get; set; }
        public string? Describtion { get; set; }
        public virtual Side Side { get; set; }
        public virtual SideRoles SideRole { get; set; }
        //public abstract void Action();
    }
    public class GodFatherRole : RoleCard
    {
        public GodFatherRole()
        {
            Title = "پدر خوانده";
            PicPath = RootPicPath.GetPicFrom("Mafia", "GodFather.jpg");
            Describtion = "او از یک بار شلیک شب لئون مصون است.یک جلیقه دارد.تعیین شلیک شب از طرف گروه به عهده پدرخوانده است و اگر از بازی خارج شود دیگر اعضا به جای او شلیک می کنند.پدرخوانده دارای توانایی حس ششم است و اگر در شب تصمیم بگیرد به جای شلیک از حس ششم استفاده کند باید نقش بازیکنی را درست حدس بزند و توسط گرداننده تائید شود.بازیکنی که پدرخوانده نقش او را درست حدس زده است سلاخی می شود یعنی اگر سپر داشته باشد یا دکتر او را سیو کرده باشد بازهم از بازی خارج می شود و آن شب توانایی وی اعمال نخواهد شد و پس از خروج از بازی توسط کنستانتین قابل احضار نمی باشد.استعلام پدرخوانده برای نوستراداموس شهروندی بوده ولی برای همشهری کین مافیایی و مثبت خواهد بود.";
            Side = Side.Mafia;
            SideRole = SideRoles.GodFather;
        }
        //public void Action(GodFatherActions action)
        //{
        //    //
        //}
    }
    public class DrWatson : RoleCard
    {
        private bool IsSaveSelf = false;
        public DrWatson()
        {
            Title = "دکتر واتسون";
            PicPath = RootPicPath.GetPicFrom("Citizen", "DrWatson.jpg");
            Describtion = "هرشب می تواند جان یک نفر چه عضو مافیا و چه عضو شهروندی را نجات دهد.جان خودش را یکبار می تواند در طول بازی نجات دهد ولی در نجات جان دیگران محدودیتی ندارد.";
            Side = Side.Citizen;
            SideRole = SideRoles.DrWatson;
        }
        public ActionResult Action(List<Player> players, int selectedPlayerId)
        {
            var selectedPlayer = players.FirstOrDefault(p => p.Id == selectedPlayerId);
            if (selectedPlayer is null)
                return new ActionResult(false, "این بازیکن وجود ندارد!");
            if (selectedPlayer.Role!.SideRole == SideRoles.DrWatson)
            {
                if (IsSaveSelf)
                    return new ActionResult(false, "دکتر فقط یکبار میتواند خودش را نجات دهد");
            }
            return new ActionResult(true, $"را نجات داد {selectedPlayer.Name}");
        }
    }
    public class Leon: RoleCard
    {
        private int ShotCount = 2;
        public Leon()
        {
            Title = "لئون";
            PicPath = RootPicPath.GetPicFrom("Citizen", "Leon.jpg");
            Describtion = "هرشبی که بخواهد می تواند به یکی از اعضای تیم مافیا شلیک کند.اما با شلیک اشتباه به شهروندان به مجازات خودش کشته می شود و دکتر نمی تواند او را نجات دهد.لئون یک جلیقه دارد که یکبار از تیر نجات پیدا می کند.حداکثر دو شلیک دارد.";
            Side = Side.Citizen;
            SideRole = SideRoles.Leon;
        }

        public ActionResult Action(List<Player> players,int selectedPlayerId)
        {
            if (ShotCount == 0)
                return new ActionResult(true, "لئون از 2 تیر خود استفاده کرده است");

            var selectedPlayer = players.FirstOrDefault(p => p.Id == selectedPlayerId);
            if (selectedPlayer is null)
                return new ActionResult(false, "این بازیکن وجود ندارد!");

            return new ActionResult(true, $"شلیک کرد {selectedPlayer.Name} به",selectedPlayerId);
        } 
    }
    public class Kane : RoleCard
    {
        bool CanInquiry = true;
        public Kane()
        {
            Title = "همشهری کین";
            PicPath = RootPicPath.GetPicFrom("Citizen", "Kane.jpg");
            Describtion = "شهروندی است که در یکی از شب ها به انتخاب خود به دعوت گرداننده یکی از بازیکنان را نشان می دهد.اگر یک مافیا را درست نشان کرده باشد صبح روز بعد گرداننده ساید مافیای نشان شده را در جمع افشا می کند.و همشهری کین شب بعد کشته می شود.دکتر توانایی نجات او را ندارد.اما اگر نشانش از ساید مافیا نبود گرداننده هیچ چیزی اعلام نخواهد کرد و همشهری کین در بازی خواهد ماند و استعلامش از بین خواهد رفت.اگر او یا نشانش کشته شوند عملیات شب وی اجرا نشده و از بین نمی رود و همچنان باقی می ماند.استعلام پدرخوانده برای همشهری کین مافیایی است.";
            Side = Side.Citizen;
            SideRole = SideRoles.Kane;
        }
        public ActionResult Action(List<Player> players,int selectedPlayerId)
        {
            if (!CanInquiry)
                return new ActionResult(true, "مهلت استعلام ایشان تمام شده است");

            var selectedPlayer = players.FirstOrDefault(p => p.Id == selectedPlayerId);
            if (selectedPlayer is null)
                return new ActionResult(false, "این بازیکن وجود ندارد!");

            return new ActionResult(true, $"{selectedPlayer.Name} را انتخاب کرد", selectedPlayerId);
        }
    }
    public class ActionResult
    {
        public ActionResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public ActionResult(bool isSuccess, string message, int selectedPlayerId)
        {
            IsSuccess = isSuccess;
            Message = message;
            SelectedPlayerId = selectedPlayerId;
        }

        public bool IsSuccess { get; set;}
        public string Message { get; set; }
        public int SelectedPlayerId { get; set; }
    }
    public enum GodFatherActions
    {
        SixthSense,
        Shoot,
        Buy
    }
    public enum Side
    {
        Citizen,
        Mafia,
        Independ
    }
    public enum SideRoles
    {
        GodFather,
        Matador,
        SaulGoodman,
        //
        Nostradamus,
        //
        DrWatson,
        Leon,
        Constantine,
        Kane,
        Simple
    }
    public static class RootPicPath
    {
        public static string GetPicFrom(string dir, string filename)
        {
            var curr = new DirectoryInfo(Environment.CurrentDirectory)!.Parent!.Parent!.Parent!;
            return Path.Combine(curr.FullName, "pics", dir, filename);
        }
    }
}