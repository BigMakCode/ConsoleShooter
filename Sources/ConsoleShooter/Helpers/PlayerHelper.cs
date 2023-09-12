using ConsoleShooter.Extensions;
using ConsoleShooter.Models;

namespace ConsoleShooter.Helpers
{
    public class PlayerHelper
    {
        public static IEnumerable<Player> CreateAIPlayers(int botCount)
        {
            if (botCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(botCount), "Bot player count must be more than zero.");
            }
            var allWeapons = WeaponHelpers.CreateDefaultWeapons();
            string[] botNames = { "Cockeredo", "Shark", "Shifter", "Ququhai", "Gocha", "Sasha", "R1Debile", "Muhammed", "Alexandro" };
            List<Player> result = new();
            for (int i = 0; i < botCount; i++)
            {
                var player = new Player(botNames.RandomElement(), allWeapons.RandomElement());
                result.Add(player);
            }
            return result;
        }
    }
}