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
                new SaulGoodman(),
                new Matador(),
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

            var randomIndex = new Random();
            for (int i = 0; i < Players.Count; i++)
            {
                var player = Players[i];
                var roleIndex = randomIndex.Next(0, roles.Count);
                var role = roles[roleIndex];
                player.Role = role;
                roles.Remove(role);
            }
        }
    }
}
