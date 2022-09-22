using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Models;

namespace Services.Services
{
    public class QuotesServices
    {

        private string _connectionString;
        public QuotesServices()
        {
            _connectionString = "Server = 127.0.0.1; Port = 5432; Database = QuoteDB; User Id = postgres; Password = 11111;";
        }
      
        public async Task<List<CategorytoQuoteDtos>>GetCategorytoQuote()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"SELECT q.id,q.quotetext,q.author,c.categoryname FROM Category as c INNER JOIN quote as q ON q.categoryid = c.id; ";
                var response = await connection.QueryAsync<CategorytoQuoteDtos>(sql);
                return response.ToList();
            }
        }
        
        public async Task<int> AddQuotes(Quotes quote)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"INSERT INTO quotes(author , quotestext ,categoryId ) VALUES ('{quote.Author}','{quote.QuotesText}' , '{quote.CategoryId}') ";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        
        public async Task<int> UpdateQuote(Quotes quote)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"UPDATE  quotes SET author = '{quote.Author}', quotesText = '{quote.QuotesText}' WHERE id = '{quote.Id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<int> DeleteQuote(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                string sql = $"DELETE FROM quotes WHERE id = '{id}'";
                var response = await connection.ExecuteAsync(sql);
                return response;
            }
        }
        public async Task<List<Quotes>> GetQuotes()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Quotes";
                var list = await connection.QueryAsync<Quotes>(sql);
                return list.ToList();
            }
        }

        public async Task<List<Quotes>> GetQuoteById(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM Quotes JOIN category ON Quotes.categoryid = category.id where Quotes.categoryid = {id};";
                var list = await connection.QueryAsync<Quotes>(sql);
                return list.ToList();
            }
        }
        public async Task<Quotes> GetQuoteRandom()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                var sql = $"select * from Quotes order by random() limit 1 ;";
                var list = await connection.QuerySingleAsync<Quotes>(sql);
                return list;
            }
        }

    }
}