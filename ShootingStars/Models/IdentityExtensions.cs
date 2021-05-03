using System.Security.Claims;
using System.Security.Principal;

namespace ShootingStars.Models
{
    public static class IdentityExtensions
    {
        public static string GetStudentEmail(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("StudentEmail");
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}