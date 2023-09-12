using ConsoleShooter.Models;

namespace ConsoleShooter.Helpers
{
    public static class WeaponHelpers
    {
        public static IEnumerable<Weapon> CreateDefaultWeapons()
        {
            return new List<Weapon>()
            {
                new Weapon("Нож", WeaponType.Knife, 65),
                new Weapon("Тесак", WeaponType.Knife, 12),
                new Weapon("Водомёт", WeaponType.Rifle, 1),
                new Weapon("Автомат", WeaponType.Rifle, 5),
                new Weapon("Говномёт", WeaponType.Shotgun, 31),
                new Weapon("Пистолет", WeaponType.Pistol, 10)
            };
        }
    }
}