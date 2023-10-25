using Microsoft.AspNetCore.Mvc;
using System.Text;
using URLShortener.Data.Implementations;
using URLShortener.Entities;
using URLShortener.Models;

namespace URLShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly UrlRepository _urlRepository;

        public UrlShortenerController(UrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetUrlById(int id)
        {
            // Buscar la URL en la base de datos por su ID utilizando el repositorio
            var url = _urlRepository.GetUrlById(id);

            if (url == null)
            {
                return NotFound(); // Si no se encuentra la URL, devuelve un código 404 (Not Found)
            }

            // Devuelve la URL original en el cuerpo de la respuesta
            return Ok(url.LongUrl);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult CreateShortUrl([FromBody] UrlForCreationDto urlForCreation)
        {
            if (urlForCreation == null)
            {
                return BadRequest();
            }

            string shortUrl = GenerateShortUrl();

            // Crear una nueva entidad URL con la URL original y la URL corta
            Url urlEntity = new Url
            {
                LongUrl = urlForCreation.LongUrl,
                ShortUrl = shortUrl,
                CategoryId = urlForCreation.CategoryId
            };

            // Agregar la entidad URL a la base de datos
            _urlRepository.AddUrl(urlEntity);
            _urlRepository.SaveChanges();

            // Devolver una respuesta indicando que la URL corta se ha creado con éxito
            return Created($"api/url/{shortUrl}", urlEntity);
        }

        [HttpGet("redirectUrl/{shortUrl}")]
        public IActionResult RedirectShortUrl(string shortUrl)
        {
            // Buscar la URL original en la base de datos por la URL corta utilizando el repositorio
            Url url = _urlRepository.GetUrlByShortUrl(shortUrl);

            if (url == null)
            {
                return NotFound(); // Si no se encuentra la URL, devuelve un código 404 (Not Found)
            }
            _urlRepository.IncrementClickCounter(url.Id);
            // Realizar la redirección a la URL original
            return Redirect(url.LongUrl);
            
        }

        // Generador de URL corta
        private readonly string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string GenerateShortUrl()
        {
            Random random = new Random();
            StringBuilder ShortUrl = new StringBuilder();

            for (int i = 0; i < 6; i++)
            {
                int indice = random.Next(AllowedCharacters.Length);
                ShortUrl.Append(AllowedCharacters[indice]);
            }

            return ShortUrl.ToString();
        }
    }
}
