using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace BusinessLogic
{
    public class GameService
    {
        public List<Player> Players { get; set; }
        public GameService(List<Player> players)
        {
            Players = players;
        }

        public void RandomizeSetRoleToPlayer()
        {
            var roles = new List<RoleCard>()
            {
                //mafia
                new GodFatherRole(),
                //citizen
                new DrWatson(),
                new Leon(),
                new Kane(),
                new Constantine(),
                new SimpleCitizen(),
                new SimpleCitizen(),
                new SimpleCitizen(),
                //independ
                new Nostradamus()
            };
        }
    }
}
