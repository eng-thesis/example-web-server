using ExampleWebServer.Domain.Entities;
using ExampleWebServer.Specifications;

namespace ExampleWebServer.Domain.Repositories;

public interface IBookRepository
{
    Task<Pagination<Book>> GetPagination(PaginationParams paginationParams);
    Task<Book?> GetById(Guid id);
    Task<Book> Create(Book book);
    Task<bool> Update(Book book);
    Task<bool> Delete(Guid id);
}