using ExampleWebServer.Domain.Entities;
using ExampleWebServer.DTO;
using ExampleWebServer.Specifications;

namespace ExampleWebServer.Mappers;

public static class BookMapper
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Description = book.Description,
            PageCount = book.PageCount,
            AuthorName = book.AuthorName,
        };
    }

    public static Book ToEntity(this CreateBookDto dto)
    {
        return new Book
        {
            Name = dto.Name,
            Description = dto.Description,
            PageCount = dto.PageCount,
            AuthorName = dto.AuthorName
        };
    }

    public static Book ToEntity(this UpdateBookDto dto, Guid id)
    {
        return new Book
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            PageCount = dto.PageCount,
            AuthorName = dto.AuthorName
        };
    }

    public static Pagination<Book> ToPagination(this IEnumerable<Book> books, PaginationParams paginationParams,int count)
    {
        return new Pagination<Book>
        {
            Count = count,
            PageIndex = paginationParams.PageIndex,
            PageSize = paginationParams.PageSize,
            Data = books.ToList(),
            
        };
    }
}