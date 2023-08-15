using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;

namespace BusinessLogic
{
    public class PlayerService
    {
        public static List<Player> Players { get; set; } = new();
        public static void InputPlayers(List<InputPlayerDto> dto)
        {
            dto.ForEach(d => Players.Add(new Player {
                Name=d.Name,
                Nickname=d.Nickname,
            }));
        }
    }
    public class InputPlayerDto
    {
        public required string Name { get; set; }
        public string? Nickname { get; set; }
    }
}
