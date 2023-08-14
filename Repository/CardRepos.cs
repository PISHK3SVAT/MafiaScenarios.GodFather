﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace Repository
{
    public class CardRepos
    {
        public List<Card> MafiaCards()
        {
            return new List<Card>
            {
                new Card
                {
                    Title = "پدر خوانده",
                    Side= Side.Mafia,
                    Describtion= "او از یک بار شلیک شب لئون مصون است.یک جلیقه دارد.تعیین شلیک شب از طرف گروه به عهده پدرخوانده است و اگر از بازی خارج شود دیگر اعضا به جای او شلیک می کنند.پدرخوانده دارای توانایی حس ششم است و اگر در شب تصمیم بگیرد به جای شلیک از حس ششم استفاده کند باید نقش بازیکنی را درست حدس بزند و توسط گرداننده تائید شود.بازیکنی که پدرخوانده نقش او را درست حدس زده است سلاخی می شود یعنی اگر سپر داشته باشد یا دکتر او را سیو کرده باشد بازهم از بازی خارج می شود و آن شب توانایی وی اعمال نخواهد شد و پس از خروج از بازی توسط کنستانتین قابل احضار نمی باشد.استعلام پدرخوانده برای نوستراداموس شهروندی بوده ولی برای همشهری کین مافیایی و مثبت خواهد بود.",
                },
                new Card
                {
                    Title = "ماتادور",
                    Side = Side.Mafia,
                    Describtion= "شب ها با تیم مافیا بیدار می شود و هر شب از توانایی خود استفاده می کند.در شب هر بازیکنی را نشان دهد توانایی شب او را آن شب از وی خواهد گرفت و فرد نشان شده اگر بیدار شود با ضربدر گرداننده مواجه می شود اما فردا مجدد می تواند از توانایی اش استفاده کند.ماتادور دو شب متوالی نمی تواند یک بازیکن را نشان کند.",
                },
                new Card
                {
                    Title = "ساول گودمن",
                    Side = Side.Mafia,
                    Describtion = "اگر فردی از گروه مافیا خارج شود ساول می تواند جای شلیک شب معامله و خریداری انجام دهد.ساول گودمن فقط یکبار می تواند یکی از شهروندان ساده را به یک مافیای ساده تبدیل کند.با علامت او همان شب گرداننده آن فرد را از نقش جدیدش یعنی مافیای ساده مطلع می کند و وی را بیدار می کند تا هم تیمی های خود را بشناسد.اگر ساول گودمن شهروند غیرساده یا نوستراداموس را انتخاب کند با ضربدر گرداننده مواجه شده و گرداننده نشانش را بیدار نمی کند.توانمندی ساول و شلیک آن شب مافیا نیز از بین می رود.",
                }
            };
        }
        public Card Independ()
        {
            return new Card
            {
                Title = "نوستراداموس",
                Side = Side.Independ,
                Describtion = "در شب معارفه گرداننده او را بیدار می کند.نوستراداموس به انتخاب خود سه بازیکن را به گرداننده نشان می دهد.سپس گرداننده به او تعداد مافیا های موجود در میان این سه را اعلام می کند و پیش بینی او مبنی بر پیروزی یکی از دو ساید را از او می پرسد.نوستراداموس پیش بینی می کند شهروندان برنده خواهند شد یا مافیا ها.از این پس او برای برنده شدن سایدی که انتخاب کرده است تلاش می کند.بدون آنکه دیگر افراد بدانند وی به چه سایدی پیوسته است.اگر ساید مورد انتخابش برنده شد او نیز برنده است و اگر ساید مورد انتخابش بازنده شد او نیز بازنده خواهد شد.شلیک هیچ یک از دو ساید بر او موثر نخواهد بود و در شب کشته نخواهد شد.مگر با حس ششم پدرخوانده اما در روز با رای گیری از بازی خارج خواهد شد.استعلام پدرخوانده برای وی شهروندی خواهد بود.",
            };
        }
        public List<Card> Citizens()
        {
            return new List<Card>
            {
                new Card
                {
                    Title="",
                    Side=Side.Citizen,
                    Describtion=""
                }
            };
        }
        public List<Card> All()
        {
            List<Card> result = new();
            result.AddRange(MafiaCards());
            result.Add(Independ());
            return result;
        }
    }
}
