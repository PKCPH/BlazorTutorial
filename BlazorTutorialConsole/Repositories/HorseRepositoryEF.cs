using BlazorTutorialConsole.DataModel;
using BlazorTutorialConsole.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorTutorialConsole.Repositories;
/// <summary>
/// Entity Framework
/// 1) install packages
/// microsoft.entifyframeworkcore.sqlserver
/// microsoft.entifyframeworkcore.tools
/// microsoft.entifyframeworkcore
/// 2) create class context: DbContext
/// 2.1) DbSet<ModelName>
/// 2.1) ex: DbSet<Horse> horse //DML på en database server
/// 2.2) connection string to database etc...
/// 2.3) remember to build
/// 
/// 3) Define all classes and then add-migration name in console
/// 3.1) update-database in console
/// 4) class => metode => ex: readHorse(int Id) , her skal der være context i denne class
/// 5) we talk about 3 ways to use EF:
///     cod first (all models defined and then migrate)
///     database first (sql script => then generate all classes in c#)
///     design (drag and drop) forget it, i dont want to speak about it.
/// </summary>
public class HorseRepositoryEF
{
    DatabaseContext context;

    public HorseRepositoryEF(DatabaseContext context)
    {
        //this refers to context outside of the constructor
        this.context = context;
    }

    public Horse readHorse(int id)
    {
        // I want to querry on the id to the databse
        // should I return?
        //var horse = context.TableName.LinqMethod(lambda)
        //1) query
        //2) Linq expression
        //3) execute the query, .ToList(),.ToArray(), foreach
        var horse = context.Horse.Where(h => h.Id == id).FirstOrDefault();
        var horse1 = context.Horse.Where(h => h.Id == id); // 1 eller flere (men er generics og skal lave om til et object
        Horse horse2 = context.Horse.FirstOrDefault(h => h.Id == id); // kun den første

        ////lambda explained
        //foreach (var item in context.Horse.ToList())
        //{
        //    if(item.Id = id)
        //}

        return horse2;
    }

    public List<Horse> readAllHorses()
    {
        //getting all element from horse
        return context.Horse.ToList();
    }
}
