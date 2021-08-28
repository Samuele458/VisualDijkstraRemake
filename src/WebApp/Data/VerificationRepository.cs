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

        public Verification ReadVerification(string token)
        {
            return _context
                        .Verifications
                        .FirstOrDefault(v => v.Token == token);
        }

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

        public void DeleteVerification(Verification verification)
        {
            _context
                .Verifications
                .Remove(verification);
            _context.SaveChanges();
        }

        public Verification Verify(string token)
        {

            Verification verification = ReadVerification(token);

            if (verification != default(Verification))
            {

                if ((DateTime.UtcNow - verification.CreatedOn).TotalSeconds < 900)
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
