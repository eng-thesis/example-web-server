namespace ExampleWebServer.DTO;

public class BookDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public string AuthorName { get; set; } 
}
public class CreateBookDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public string AuthorName { get; set; }
}
public class UpdateBookDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public string AuthorName { get; set; }
}
