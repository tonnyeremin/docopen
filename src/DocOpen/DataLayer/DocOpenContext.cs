using Microsoft.EntityFrameworkCore;

namespace DocOpen.Data
{
    public class DocOpenContext : DbContext
    {
        public DocOpenContext(DbContextOptions<DocOpenContext> options) : base(options){

        }

        public DbSet<Submission> Submissions{get; set;}
        public DbSet<Project> Projects{get; set;}
        public DbSet<ProjectItem> ProjectItems {get; set;}
        public DbSet<User> Users{get; set;}

    }
}