namespace ExampleWebServer.Specifications;

public class Pagination<T> where T : class
{
    public IReadOnlyCollection<T> Data { get; set; }
    public int Count { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }

}