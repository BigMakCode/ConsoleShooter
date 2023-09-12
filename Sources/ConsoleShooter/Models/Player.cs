namespace ConsoleShooter.Models
{
    public class Player
    {
        public string PlayerName { get; }
        public Weapon Weapon { get; }
        public int Health { get; private set; }
        public bool IsAlive => Health > 0;

        private const int defaultHealth = 100;

        public Player(string playerName, Weapon weapon)
        {
            PlayerName = playerName;
            Weapon = weapon;
            Health = defaultHealth;
        }

        public bool Hit(int healthPoints)
        {
            if (Health <= 0)
            {
                return false;
            }
            Health -= healthPoints;
            if (Health < 0)
            {
                Health = 0;
            }
            return true;
        }

        public override string ToString()
        {
            return $"👤 {PlayerName}\t❤️ {Health}\t🔫 {Weapon}";
        }
    }
}