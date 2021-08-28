using WebApp.Models;

namespace WebApp.Data
{
    public interface IVerificationRepository
    {
        Verification CreateVerification(User user);

        Verification ReadVerification(string token);

        void Verify(string token);
    }
}
