using System.Net;
using System.Runtime.Intrinsics.Arm;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Domain.Models;
[ApiController]
[Route("[controller]")]
public class QuoteController: ControllerBase
{

    private QuotesServices _contactService;

    public QuoteController()
    {
        _contactService = new QuotesServices();
    }
    [HttpPost("AddQuotes")]
    public async Task<int> AddQuote(Quotes quote)
    {
        return await _contactService.AddQuotes(quote);
    }
    [HttpPut("Update")]
    public async Task<int> UpdateQuote(Quotes quote)
    {
        return await _contactService.UpdateQuote(quote);
    }
    [HttpDelete("Delete")]
    public async Task<int> DeleteQuote(int id)
    {
        return await _contactService.DeleteQuote(id);
    }
    [HttpGet("GetAll")]
    public async Task<List<Quotes>> GetQuotes()
    {
        return await _contactService.GetQuotes();
    }
     [HttpGet("GetQuotewithCategory")]
     public async Task<List<CategorytoQuoteDtos>> GetCategorytoQuotes()
     {
        return await _contactService.GetCategorytoQuote();
     }
    
    [HttpGet("GetById")]
    public async Task<List<Quotes>> GetQuoteById(int id)
    {
        return await _contactService.GetQuoteById(id);
    }
    [HttpGet("random")]
    public async Task<Quotes> GetQuoteRandom()
    {
        return await _contactService.GetQuoteRandom();
    }
} 