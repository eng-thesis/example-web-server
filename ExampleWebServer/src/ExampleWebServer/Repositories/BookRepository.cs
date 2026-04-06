using ExampleWebServer.Data;
using ExampleWebServer.Domain.Entities;
using ExampleWebServer.Domain.Repositories;
using ExampleWebServer.Mappers;
using ExampleWebServer.Specifications;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebServer.Repositories;

public class BookRepository(DataContext context) : IBookRepository
{
    public async Task<Pagination<Book>> GetPagination(PaginationParams paginationParams)
    {
        var count = context.Books.Count();
        var books = await context.Books
            .Skip(paginationParams.PageSize * (paginationParams.PageIndex-1) )
            .Take(paginationParams.PageSize)
            .ToListAsync();
            return books.ToPagination(paginationParams,count);
    }

    public async Task<Book?> GetById(Guid id)
    {
        return await context.Books.FirstOrDefaultAsync(book => book.Id == id);
    }

    public async Task<Book> Create(Book book)
    {
        var result = await context.Books.AddAsync(book);
        return result.Entity;
    }

    public async Task<bool> Update(Book book)
    {
        context.Books.Update(book);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var book = await GetById(id);
        if (book == null)
        {
            return false;
        }
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
}