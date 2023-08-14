using Domain;

using Repository;

namespace BusinessLogic
{
    public class Game
    {
        public List<Player> Players { get; set; }
        private List<Role> Roles { get; set; }
        public Game()
        {
            Players = new PlayerRepos().Family1();
            Roles = new RoleRepos().All();
            RandomizeSetRoleToPlayer();
        }

        private void RandomizeSetRoleToPlayer()
        {
            List<Role> tmpRoles=new();
            Roles.ForEach(r => tmpRoles.Add(r));
            var simpleCitizen = Roles.FirstOrDefault(r => r.Title == "شهروند ساده");
            for (int i = 1; i <= 2; i++)
                tmpRoles.Add(simpleCitizen!);

            var randomIndex = new Random();
            for (int i=0;i<Players.Count;i++)
            {
                var player = Players[i];
                var roleIndex = randomIndex.Next(0, tmpRoles.Count);
                var role = tmpRoles[roleIndex];
                player.Role = role;
                tmpRoles.Remove(role);
            }
        }
    }
}
