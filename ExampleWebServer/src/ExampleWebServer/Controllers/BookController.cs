using ExampleWebServer.DTO;
using ExampleWebServer.Services;
using ExampleWebServer.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebServer.Controllers;

[ApiController]
[Route("api/books")]
public class BookController:ControllerBase
{
    private BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<BookDto>>> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var result = await _bookService.GetPagination(paginationParams);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetById([FromRoute] Guid id)
    {
        var result = await _bookService.GetById(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> Create([FromBody] CreateBookDto dto)
    {
        var result = await _bookService.Create(dto);
        return Ok(result);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<BookDto>> Update([FromBody] UpdateBookDto dto,[FromRoute] Guid id)
    {
        var result = await _bookService.Update(dto,id);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        var isDeleted = await _bookService.Delete(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}