using System;
using System.Linq;
using WebApp.Models;
using WebApp.Utils;

namespace WebApp.Data
{
    public class VerificationRepository : IVerificationRepository
    {
        private readonly UserContext _context;

        public VerificationRepository(UserContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public Verification CreateVerification(User user)
        {

            Verification verification = new Verification
            {
                Token = System.Web.HttpUtility.UrlEncode(StringUtils.RandomBase64String(128)),
                User = user,
                UserId = user.Id,
                CreatedOn = DateTime.UtcNow
            };

            _context
                .Verifications
                .Add(verification);

            _context.SaveChanges();

            return verification;

        }

        /// <inheritdoc/>
        public Verification ReadVerification(string token)
        {
            return _context
                        .Verifications
                        .FirstOrDefault(v => v.Token == token);
        }

        /// <inheritdoc/>
        public void DeleteVerification(string token)
        {
            Verification verification = ReadVerification(token);

            if (verification != default(Verification))
            {
                DeleteVerification(verification);
            }
            else
            {
                throw new VerificationNotFoundException();
            }
        }

        /// <inheritdoc/>
        public void DeleteVerification(Verification verification)
        {
            _context
                .Verifications
                .Remove(verification);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public Verification Verify(string token)
        {

            Verification verification = ReadVerification(token);

            if (verification != default(Verification))
            {

                if ((DateTime.UtcNow - verification.CreatedOn).TotalSeconds < 1800)
                {
                    DeleteVerification(verification);
                }
                else
                {
                    throw new VerificationTokenExpiredException();
                }
            }
            else
            {
                throw new VerificationNotFoundException();
            }

            return verification;
        }
    }

    public class VerificationNotFoundException : Exception
    {
        public VerificationNotFoundException(string message = "") : base(message) { }
    }

    public class VerificationTokenExpiredException : Exception
    {
        public VerificationTokenExpiredException(string message = "") : base(message) { }
    }
}
