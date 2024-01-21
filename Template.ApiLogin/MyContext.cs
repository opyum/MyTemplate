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
            modelBuilder.Entity<Sample>().HasKey(x => x.Id);

    //        modelBuilder.Entity<Sample>()
    //            .HasOne(u => u.Family)
    //            .WithMany(f => f.Users)
    //            .HasForeignKey(u => u.FamilyId)
    //            .IsRequired(false);


    //        modelBuilder.Entity<Sample>()
    //.HasMany(u => u.TaskUsers)
    //.WithOne(tu => tu.User)
    //.HasForeignKey(tu => tu.IdUser)
    //.IsRequired(false); // Ceci rend la relation facultative

    //        //modelBuilder.Entity<TaskUser>()
    //        //    .HasOne(u => u.User)
    //        //    .WithMany(tu => tu.TaskUsers)
    //        //    .IsRequired(false);

    //        modelBuilder.Entity<TaskUser>()
    //            .HasOne(u => u.Task)
    //            .WithMany(tu => tu.TaskUsers)
    //            .IsRequired(false);

        }

        public DbSet<Sample> Sample { get; set; }

        public DbSet<ConnectedUser> ConnectedUser { get; set; }

    }

    public class ConnectedUser : IdentityUser
    {

    }
    public class Sample
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }

}
