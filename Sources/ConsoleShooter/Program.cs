using ConsoleShooter.Models;
using ConsoleShooter.Helpers;
using ConsoleShooter.Extensions;

namespace ConsoleShooter
{
    internal class Program
    {
        static void Main()
        {
            int botCount = ConsoleHelpers.ReadPositiveNumber("Enter AI players count");
            IEnumerable<Player> bots = PlayerHelper.CreateAIPlayers(botCount);
            string playerName = ConsoleHelpers.ReadNonEmptyString("Enter your name") + " (you)";
            IEnumerable<Weapon> allWeapons = WeaponHelpers.CreateDefaultWeapons();
            Weapon weapon = ConsoleHelpers.SelectObject(allWeapons);
            Player user = new(playerName, weapon);
            StartGame(user, bots.Append(user));
        }

        private static void StartGame(Player user, IEnumerable<Player> allPlayers)
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("Player list:");
            foreach (Player player in allPlayers)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine();

            Console.CursorVisible = false;
            var pos = Console.GetCursorPosition();
            for (int i = 10; i > 0; i--)
            {
                Console.SetCursorPosition(pos.Left, pos.Top);
                Console.WriteLine("Game starts with seconds: {0} ...   ", i);
                Thread.Sleep(1000);
            }

            RunShooter(user, allPlayers);
        }

        private static void RunShooter(Player user, IEnumerable<Player> allPlayers)
        {
            const int roundDelay = 3_000;
            int roundCounter = 1;
            var alivePlayers = allPlayers.Where(x => x.IsAlive);
            while (alivePlayers.Count() >= 2)
            {
                Console.WriteLine("================================================");
                Thread.Sleep(roundDelay);
                Console.WriteLine("🎲 Round: {0}", roundCounter++);
                alivePlayers = allPlayers.Where(x => x.IsAlive);
                var attacker = alivePlayers.RandomElement();
                var victim = alivePlayers.RandomElement();
                if (attacker == victim)
                {
                    Console.WriteLine("👊 Attacker: {0}", attacker);
                    Console.WriteLine("🛡 Victim: {0}", victim);
                    Console.WriteLine("👔 Tie! There is the same player. Skipping for the next round.");
                    continue;
                }
                int hits = Random.Shared.Next(0, (int)attacker.Weapon.WeaponType);
                int burst = attacker.Weapon.DamagePerHit * hits;
                victim.Hit(burst);
                Console.WriteLine("👊 Attacker: {0}", attacker);
                Console.WriteLine("🛡 Victim: {0}", victim);
                string victimStatus = victim.IsAlive ? "ALIVE" : "DEAD";
                Console.WriteLine("Attacked for {0} HP (hits: {1}), victim is {2}, remains players: {3}", burst, hits, victimStatus, alivePlayers.Count());
                if (!user.IsAlive)
                {
                    Console.WriteLine("☠️ You are dead. Game is over.");
                    return;
                }
            }
            Console.WriteLine("================================================");
            Console.WriteLine("🏆 You are win");
        }
    }
}