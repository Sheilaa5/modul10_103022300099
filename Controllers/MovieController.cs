using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300099.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public class Movie
        {
            public String Title { get; set; }
            public String Description { get; set; }
            public String Director { get; set; }
            public List<String> Stars { get; set; }

            public Movie(string Title, String Description, String Director, List<String> Stars)
            {
                this.Title = Title;
                this.Description = Description;
                this.Director = Director;
                this.Stars = Stars;
            }
           
           
        }
        public static List<Movie> movieList = new List<Movie>()
            {
                new Movie ("The Shawshank Redemption", "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ,"Frank Darabont", new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"} ),
                new Movie ("Schindler's List", "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Steven Spielberg", new List<string>{"Liam Neeson", "Ralp Fienes", " Ben Kingsley " }),
                new Movie ("The Godfather Part II", "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.", "Francis Ford Coppola", new List<string>{"Al Pacino", "Robert de Niro"})
            };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movieList;
        }
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            movieList.Add(value);
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            movieList.RemoveAt(id);
        }
    }
}
