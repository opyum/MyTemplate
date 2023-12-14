using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plantoufle.Repository
{

    // Définition du contexte de la base de données
    public class MyDbContext : IdentityDbContext<ConnectedUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FamilyMember>().HasKey(x => x.Id);

            modelBuilder.Entity<FamilyMember>()
                .HasOne(u => u.Family)
                .WithMany(f => f.Users)
                .HasForeignKey(u => u.FamilyId)
                .IsRequired(false);


            modelBuilder.Entity<FamilyMember>()
    .HasMany(u => u.TaskUsers)
    .WithOne(tu => tu.User)
    .HasForeignKey(tu => tu.IdUser)
    .IsRequired(false); // Ceci rend la relation facultative

            //modelBuilder.Entity<TaskUser>()
            //    .HasOne(u => u.User)
            //    .WithMany(tu => tu.TaskUsers)
            //    .IsRequired(false);

            modelBuilder.Entity<TaskUser>()
                .HasOne(u => u.Task)
                .WithMany(tu => tu.TaskUsers)
                .IsRequired(false);

        }

        public DbSet<FamilyMember> FamilyMember { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Mission> Tasks { get; set; }
        public DbSet<TaskUser> TaskUsers { get; set; }
        public DbSet<ConnectedUser> ConnectedUser { get; set; }

    }

    public class ConnectedUser : IdentityUser
    {

    }
    public class FamilyMember
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? FamilyId { get; set; } // Nullable int
        public Family Family { get; set; }
        public List<TaskUser> TaskUsers { get; set; }
    }

    public class Family
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdGroup { get; set; }

        public List<FamilyMember> Users { get; set; }
    }

    public class Mission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Done { get; set; }
        public int DeadlineType { get; set; }
        public DateTime DeadlineDate { get; set; }
        public List<TaskUser> TaskUsers { get; set; }
    }

    public class TaskUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdTask { get; set; }


        public FamilyMember User { get; set; }
        public Mission Task { get; set; }
    }


}
