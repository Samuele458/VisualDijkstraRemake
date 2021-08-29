using WebApp.Models;

namespace WebApp.Data
{
    /// <summary>
    ///  Verification repository interface
    /// </summary>
    public interface IVerificationRepository
    {
        /// <summary>
        ///  Creates new verification
        /// </summary>
        /// <param name="user">User to be verified</param>
        /// <returns>Verification object</returns>
        Verification CreateVerification(User user);

        /// <summary>
        ///  Reads an existing verification
        /// </summary>
        /// <param name="token">Verification token string to find</param>
        /// <returns>Verification object</returns>
        Verification ReadVerification(string token);


        /// <summary>
        ///  Verifies the token. If it is valid, Verification will be deleted
        /// </summary>
        /// <param name="token">Verification token string to be verified</param>
        /// <returns>Verification object</returns>
        Verification Verify(string token);

        /// <summary>
        ///  Deletes verification.
        /// </summary>
        /// <param name="token">Token of verification to be deleted</param>
        void DeleteVerification(string token);

        /// <summary>
        ///  Deletes verification
        /// </summary>
        /// <param name="verification">Verification object to be deleted</param>
        void DeleteVerification(Verification verification);
    }
}
