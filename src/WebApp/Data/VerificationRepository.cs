using System;
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
    }
}
