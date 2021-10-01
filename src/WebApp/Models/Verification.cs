using System;

namespace WebApp.Models
{
    /// <summary>
    ///  Verification model used in email verifications
    /// </summary>
    public class Verification
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual User User { get; set; }

        public int? UserId { get; set; }
    }
}
