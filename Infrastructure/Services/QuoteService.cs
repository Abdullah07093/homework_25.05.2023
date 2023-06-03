using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    private string connectionString =
        "Server=Localhost; port= 5432; database=quotedb; User Id= postgres; password= 12345";
public QuoteService()
{
    
}
    public QuoteDto AddQuote(QuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"insert into quotes (autor, quotetext, categoryid) values (@Autor, @Quotetext, @Categoryid) returning id";
            var id =conn.ExecuteScalar<int>(sql, quote);
            quote.Id = id;
            return quote;
        }
    }

    public QuoteDto UpdateQuote (QuoteDto quote)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"Update Quotes set author=@Author,QuoteText=@QuoteText,CategoruId=@Categoryid where id=@id";
            conn.Execute(sql, quote);
            return quote;
        }
    }

    public int Delete(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"Delete from Quotes where id = @id";
            var result=  conn.Execute(sql);
            return result;
        }
    }

       public List<QuoteDto> MostPopularAuthors(int a)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select author, count (author) as occurence from quotes group by author order by occurence desc limit @A";
            var result = conn.Query<QuoteDto>(sql, new { A = a });
            return result.ToList();
        }
    }

    public List<QuoteDto> MostPopularAuthors(object a)
    {
        throw new NotImplementedException();
    }
}