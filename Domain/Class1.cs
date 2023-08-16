namespace Domain
{

    public class RoleCard
    {
        public string Title { get; set; }=string.Empty;
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
    public class SaulGoodman : RoleCard
    {
        public SaulGoodman()
        {
            Title = "ساول گودمن";
            PicPath = RootPicPath.GetPicFrom("Mafia", "SaulGoodman.jpg");
            Describtion = "";
            Side=Side.Mafia;
            SideRole = SideRoles.SaulGoodman;
        }
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
                else
                    IsSaveSelf = true;
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

            ShotCount--;
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

            CanInquiry = false;
            return new ActionResult(true, $"{selectedPlayer.Name} را انتخاب کرد", selectedPlayerId);
        }
    }
    public class Constantine: RoleCard
    {
        private bool CanMakeAlive=true;
        public Constantine()
        {
            Title = "کنستانتین";
            PicPath = RootPicPath.GetPicFrom("Citizen", "Constantine.jpg");
            Describtion = "گرداننده کنستانتین را بیدار می کند تا او به انتخاب خود و تنها یک بار یک نفر از بازیکنان اخراجی اعم از مافیا شهروند و یا مستقل را به بازی برگرداند.غیر از نقش های افشا شده.توانایی های بازیکن احضار شده ادامه پیدا می کند و از بین نمی رود و از نو نمی شود.";
            Side= Side.Citizen;
            SideRole= SideRoles.Constantine;
        }
        public ActionResult Action(List<Player> players, int selectedPlayerId)
        {
            if (!CanMakeAlive)
                return new ActionResult(true, "مهلت استفاده از این قابلیت تمام شده است");

            var selectedPlayer = players.FirstOrDefault(p => p.Id == selectedPlayerId);
            if (selectedPlayer is null)
                return new ActionResult(false, "این بازیکن وجود ندارد!");

            CanMakeAlive = false;
            return new ActionResult(true, $"{selectedPlayer.Name} را برای زنده کردن انتخاب کرد", selectedPlayerId);
        }
    }
    public class SimpleCitizen:RoleCard
    {
        public SimpleCitizen()
        {
            Title = "شهروند ساده";
            PicPath = RootPicPath.GetPicFrom("Citizen", "Simple.jpg");
            Describtion = "نقش شهروند ساده کمک به هم تیمی های خود در تشخیص مافیا به درستی است و رای دادن با زرنگی به اعضای مافیاست. او در شب نقش خاصی را ایفا نمی کند و بیشتر به روند بازی و تیم شهروندی در پیروز شدن است.\r\n\r\nشهروند ساده میبایست سعی کند در روز مافیا ها را با دقت شناسایی کند و به آن ها رای دهد و در شب عمل خاصی را انجام نمی دهد";
            Side = Side.Citizen;
            SideRole = SideRoles.Simple;
        }

    }
    public class Nostradamus : RoleCard
    {
        public Nostradamus()
        {
            Title = "نوستراداموس";
            PicPath = RootPicPath.GetPicFrom("Independ", "Nostradamus.jpg");
            Describtion = "در شب معارفه گرداننده او را بیدار می کند.نوستراداموس به انتخاب خود سه بازیکن را به گرداننده نشان می دهد.سپس گرداننده به او تعداد مافیا های موجود در میان این سه را اعلام می کند و پیش بینی او مبنی بر پیروزی یکی از دو ساید را از او می پرسد.نوستراداموس پیش بینی می کند شهروندان برنده خواهند شد یا مافیا ها.از این پس او برای برنده شدن سایدی که انتخاب کرده است تلاش می کند.بدون آنکه دیگر افراد بدانند وی به چه سایدی پیوسته است.اگر ساید مورد انتخابش برنده شد او نیز برنده است و اگر ساید مورد انتخابش بازنده شد او نیز بازنده خواهد شد.شلیک هیچ یک از دو ساید بر او موثر نخواهد بود و در شب کشته نخواهد شد.مگر با حس ششم پدرخوانده اما در روز با رای گیری از بازی خارج خواهد شد.استعلام پدرخوانده برای وی شهروندی خواهد بود.";
            Side = Side.Independ;
            SideRole = SideRoles.Nostradamus;
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