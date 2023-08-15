using Domain;

using Repository;

namespace BusinessLogic
{
    //Roles property must be delete and default the CTOR should get Players from its parameter
    public class Game
    {
        public List<Player> Players { get; set; }
        public readonly int ChallengeTimeLength = 30;
        public readonly int IntroductionDayTimeLength = 30;
        public readonly int SpeakDayTimeLenght = 40;
        public readonly int DefenceTimeLenght = 40;
        public bool IsChallengeAllow { get; private set; }

        private Player SpeakStarter;
        private List<RoleCard> Roles { get; set; }
        public Game()
        {
            Players = new PlayerRepos().Family1();
            Roles = new RoleRepos().All();
            RandomizeSetRoleToPlayer();
        }
        public void IntroductionDay(Player starter)
        {
            SpeakStarter = Players.FirstOrDefault(p => p.Name == starter.Name)!;
            IsChallengeAllow = false;
        }
        public void IntroductionNight()
        {

        }
        public void GamePlay()
        {
            string winner = "";
            do
            {
                var mafiaCount = Players.Where(p => p.Role!.Side == Side.Mafia).Count();
                var citizenCount = Players.Where(p => p.Role!.Side == Side.Citizen).Count();
                if (mafiaCount == citizenCount)
                {
                    winner = "mafia";
                    break;
                }
                if (mafiaCount == 0)
                {
                    winner = "citizen";
                    break;
                }
            } while (true);
            Console.WriteLine(winner);
        }

        private void RandomizeSetRoleToPlayer()
        {
            List<RoleCard> tmpRoles=new();
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
