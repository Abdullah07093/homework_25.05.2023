using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QouteController : ControllerBase{
private QuoteService _quoteservice;
public QouteController()
{
_quoteservice=new QuoteService();
}
 [HttpGet("Qouters")]
 public List<QuoteDto>GetQoute(){
        return _quoteservice.MostPopularAuthors( );
    }


}