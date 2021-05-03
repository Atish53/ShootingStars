using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;



namespace ShootingStars.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string StudentEmail { get; set; }

        public string StudentName { get; set; }

        public string StudentPhoneNumber { get; set; }

        public List<StudentQuiz> StudentQuizzes { get; set; }

        public List<Chat> Chats { get; set; }

        public List<Query> Queries { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("StudentEmail", StudentEmail));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {            
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<StudentQuiz> StudentQuizzes { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<SubjectMaterial> SubjectMaterials { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ShootingStars.Models.TeacherReview> TeacherReviews { get; set; }
    }
}