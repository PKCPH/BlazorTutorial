
using BlazorTutorialConsole.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorTutorialConsole.DataModel;

public  class DatabaseContext : DbContext
{
    //fortæller hvilken database vi bruger
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("" +
            "Data Source=DESKTOP-QN9UC1C\\SQLEXPRESS;" +
            "Initial Catalog=EF2;" +
            "Integrated Security=True;" +
            "MultipleActiveResultSets=True");
    }

    //this is our table in virtually form
    public DbSet<Horse> Horse { get; set; } //our horse table.....
}
