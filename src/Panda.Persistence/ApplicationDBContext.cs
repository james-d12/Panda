using Microsoft.EntityFrameworkCore;
using Panda.Core.Modules.Employees.Domain;

namespace Panda.Persistence;

public sealed class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string solutionRoot = GetSolutionRootDirectory();
        string dbPath = Path.Combine(solutionRoot, "db", "Panda.db");
        optionsBuilder.UseSqlite("Data Source=" + dbPath);
    }

    private static string GetSolutionRootDirectory()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        DirectoryInfo? directoryInfo = new(currentDirectory);

        while (directoryInfo.Parent != null)
        {
            if (directoryInfo.GetFiles("*.sln").Length > 0)
            {
                return directoryInfo.FullName;
            }

            directoryInfo = directoryInfo.Parent;
        }

        throw new DirectoryNotFoundException("Solution root directory not found.");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}