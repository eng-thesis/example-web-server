using ExampleWebServer.Domain.Entities;

namespace ExampleWebServer.Data;

public static class Seed
{
   public static async Task SeedData(DataContext context)
   {
      if (!context.Books.Any())
      {
         var books = new List<Book>
         {
            new Book
            {
               Name = "The Myth of Sisyphus",
               Description = "A philosophical work discussing meaning of absurd in humans' life ",
               AuthorName = "Albert Camus",
               PageCount = 185
            },
            new Book
            {
               Name = "The Hobbit or There and Back Again",
               Description = "An adventure book",
               AuthorName = "J.R.R Tolkien",
               PageCount = 310
            }
         };
         await context.Books.AddRangeAsync(books);
         await context.SaveChangesAsync();
      }
   }
}