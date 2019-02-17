using System.Threading.Tasks;

namespace SecretSanta.Domain.Services
{
    public interface IPairingService
    {
        Task<bool> GeneratePairings(int groupId);
    }
}