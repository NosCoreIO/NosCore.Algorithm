//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ReputationService
{
    public interface IReputationService
    {
        byte GetLevelFromReputation(long reputation);
        (long, long) GetReputation(byte level);
    }
}