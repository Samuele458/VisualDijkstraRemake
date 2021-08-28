using WebApp.Models;

namespace WebApp.Data
{
    public interface IVerificationRepository
    {
        Verification CreateVerification(User user);
    }
}
