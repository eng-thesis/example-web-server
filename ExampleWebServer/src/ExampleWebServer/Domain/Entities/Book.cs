namespace ExampleWebServer.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PageCount { get; set; }
    public string AuthorName { get; set; }
}