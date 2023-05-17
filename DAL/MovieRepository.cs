using System.Data.SQLite;
using System.Reflection;
using Dapper;
using Entities;

namespace DAL;

public class MovieRepository
{
    public IEnumerable<Movie> GetPage(int page)
    {
        Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        var connection = new SQLiteConnection("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/movies.sqlite");
        return connection.Query<Movie>(
            "SELECT m.original_title AS title, d.name AS director FROM movies m LEFT JOIN directors d ON m.director_id = d.id ORDER BY m.original_title LIMIT 10 OFFSET " + (page-1) * 10);
    }
}