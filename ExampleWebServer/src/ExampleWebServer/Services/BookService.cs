using ExampleWebServer.Domain.Repositories;
using ExampleWebServer.DTO;
using ExampleWebServer.Mappers;
using ExampleWebServer.Specifications;

namespace ExampleWebServer.Services;

public class BookService
{
    private IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }


    public async Task<Pagination<BookDto>> GetPagination(PaginationParams paginationParams)
    {
        
        var result = await _bookRepository.GetPagination(paginationParams);
        return new Pagination<BookDto>
        {
            PageIndex = paginationParams.PageIndex,
            PageSize = paginationParams.PageSize,
            Count = result.Count,
            Data = result.Data.Select(book => book.ToDto()).ToList()
        };
    }

    public async Task<BookDto?> GetById(Guid id)
    {
        var result = await _bookRepository.GetById(id);
        return result?.ToDto();
    }

    public async Task<BookDto> Create(CreateBookDto dto)
    {
        var result = await _bookRepository.Create(dto.ToEntity());
        return result.ToDto();
    }

    public async Task<BookDto?> Update(UpdateBookDto dto, Guid id)
    {
        var book = await _bookRepository.GetById(id);
        if (book == null)
        {
            return null;
        }
        var result = await _bookRepository.Update(dto.ToEntity(id));
        return result ? book.ToDto() : null;
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _bookRepository.Delete(id);
    }
}