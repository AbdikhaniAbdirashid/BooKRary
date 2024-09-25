using book_loan.modals;

namespace book_loan.Data
{
    public class SeedingData
    { 

        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope()) 
            
             {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDBContext>();
                if (!dbContext.Books.Any())
                {
                    dbContext.AddRange(new Book

                    {
                        BookName = "Harry Potter and the philosophers stone",
                        ImageCoverURL = "https://www.amazon.se/-/en/J-K-Rowling/dp/1408855658",
                        Author = "J.K Rowling",
                        Available = true,
                        DateAdded = DateTime.Now.AddDays(-10),


                    },
                    new Book
                    {
                        BookName = "The hobbit - An unexpected journey",
                        ImageCoverURL = "https://www.amazon.com/Hobbit-Unexpected-Sir-Ian-McKellen/dp/B00BWJ6JO4",
                        Author = "J.R.R Tolkien",
                        Available = false,
                        DateAdded = DateTime.Now

                    }, 

                    new Book
                    {
                        BookName = "Pippi Långstrump",
                        ImageCoverURL = "https://www.amazon.se/Boken-Pippi-L%C3%A5ngstrump-Astrid-Lindgren/dp/9129696372",
                        Author = "Astrid Lindgren",
                        Available = true,
                        DateAdded = DateTime.Now.AddDays(-30),

                    }
                   

                    
                    );
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
