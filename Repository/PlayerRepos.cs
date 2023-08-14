using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace Repository
{
    public class PlayerRepos
    {
        public List<Player> Family1()
        {
            return new List<Player>
            {
                new Player
                {
                    Name="محمد جواد",
                },
                new Player
                {
                    Name="رقیه",
                },
                new Player
                {
                    Name="آسیه",
                },
                new Player
                {
                    Name="معصومه",
                },
                new Player
                {
                    Name="مرضیه",
                },
                new Player
                {
                    Name="مهسا",
                },
                new Player
                {
                    Name="مریم",
                },
                new Player
                {
                    Name="زینب",
                },
                new Player
                {
                    Name="لیلا",
                },
                new Player
                {
                    Name="ریحانه",
                },
                new Player
                {
                    Name="مهیا",
                },
            };
        }
    }
}
