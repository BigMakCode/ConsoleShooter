namespace ConsoleShooter.Models
{
    public class Weapon
    {
        public Weapon(string displayName, WeaponType weaponType, int damagePerHit)
        {
            if (damagePerHit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damagePerHit), "Damage must be more than zero");
            }
            DisplayName = displayName;
            WeaponType = weaponType;
            DamagePerHit = damagePerHit;
        }

        public string DisplayName { get; }
        public WeaponType WeaponType { get; }
        public int DamagePerHit { get; }

        public override string ToString()
        {
            return $"\"{DisplayName}\"\tType: {WeaponType}\tDamage: {DamagePerHit} per hit";
        }
    }
}