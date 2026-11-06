//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpecialistPointService
{
    /// <summary>
    /// The stats a specialist card's stat levels add while the character is transformed
    /// </summary>
    /// <param name="Damage">Added to the minimum and maximum damage, melee and ranged</param>
    /// <param name="HitRate">Added to the melee and ranged hit rate</param>
    /// <param name="CriticalChance">Added to the critical hit chance, in percent</param>
    /// <param name="CriticalRate">Added to the critical damage, in percent</param>
    /// <param name="Defence">Added to the melee, ranged and magic defence</param>
    /// <param name="MagicDefence">Added to the magic defence only</param>
    /// <param name="Dodge">Added to the melee and ranged dodge</param>
    /// <param name="CriticalDodge">Lowers the chance of taking a critical hit, in percent</param>
    /// <param name="DamageReduction">Lowers the melee, ranged and magic damage taken, in percent</param>
    /// <param name="Resistance">Added to the fire, water, light and shadow resistances</param>
    /// <param name="ElementRate">Added to the specialist element rate</param>
    /// <param name="Hp">Added to the maximum HP</param>
    /// <param name="Mp">Added to the maximum MP</param>
    /// <param name="HpMpPercent">Raises the maximum HP and MP by this percentage</param>
    public readonly record struct SpecialistPointBonus(
        int Damage = 0,
        int HitRate = 0,
        int CriticalChance = 0,
        int CriticalRate = 0,
        int Defence = 0,
        int MagicDefence = 0,
        int Dodge = 0,
        int CriticalDodge = 0,
        int DamageReduction = 0,
        int Resistance = 0,
        int ElementRate = 0,
        int Hp = 0,
        int Mp = 0,
        int HpMpPercent = 0)
    {
        /// <summary>
        /// Adds two bonuses together
        /// </summary>
        public static SpecialistPointBonus operator +(SpecialistPointBonus a, SpecialistPointBonus b) => new(
            a.Damage + b.Damage,
            a.HitRate + b.HitRate,
            a.CriticalChance + b.CriticalChance,
            a.CriticalRate + b.CriticalRate,
            a.Defence + b.Defence,
            a.MagicDefence + b.MagicDefence,
            a.Dodge + b.Dodge,
            a.CriticalDodge + b.CriticalDodge,
            a.DamageReduction + b.DamageReduction,
            a.Resistance + b.Resistance,
            a.ElementRate + b.ElementRate,
            a.Hp + b.Hp,
            a.Mp + b.Mp,
            a.HpMpPercent + b.HpMpPercent);
    }
}
