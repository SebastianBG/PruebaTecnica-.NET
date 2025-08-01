using Microsoft.AspNetCore.Mvc;
using CatGiphyApp.Data;
using CatGiphyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CatGiphyApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class CatGiphyController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _http;
        private const string GiphyApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";

        public CatGiphyController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _http = httpClientFactory.CreateClient();
        }

        /// Obtiene un dato aleatorio desde la API Cat Fact
        [HttpGet("fact")]
        public async Task<IActionResult> GetCatFact()
        {
            var response = await _http.GetFromJsonAsync<CatFactResponse>("https://catfact.ninja/fact");
            if (response == null || string.IsNullOrWhiteSpace(response.Fact))
                return NotFound("No se pudo obtener un cat fact.");
            return Ok(response.Fact);
        }

        /// Busca un gif en Giphy usando las primeras 3 palabras de un fact y almacena el historial
        [HttpGet("gif")]
        public async Task<IActionResult> GetGif([FromQuery] string fact)
        {
            if (string.IsNullOrWhiteSpace(fact))
                return BadRequest("Fact is required.");

            string query = string.Join(' ', fact.Split(' ').Take(3));

            // Gif Aleaotorio, para que siempre muestre un Gif diferente
            var random = new Random();
            int offset = random.Next(0, 20);
            string giphyUrl = $"https://api.giphy.com/v1/gifs/search?api_key={GiphyApiKey}&q={Uri.EscapeDataString(query)}&limit=1&offset={offset}&rating=g";

            var giphyResult = await _http.GetFromJsonAsync<GiphyResponse>(giphyUrl);
            string gifUrl = giphyResult?.Data?.FirstOrDefault()?.Images?.Original?.Url ?? "";

            var history = new SearchHistory
            {
                SearchDate = DateTime.UtcNow,
                CatFact = fact,       
                QueryWords = query,    
                GifUrl = gifUrl
            };

            _context.SearchHistories.Add(history);
            await _context.SaveChangesAsync();

            return Ok(new { gifUrl });

        }

        /// Obtiene el historial de búsquedas realizadas
        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var result = await _context.SearchHistories
                .OrderByDescending(h => h.SearchDate)
                .ToListAsync();
            return Ok(result);
        }
    }

    // Helpers para deserializar
    public class CatFactResponse
    {
        public string Fact { get; set; }
    }
    public class GiphyResponse
    {
        public List<GiphyData> Data { get; set; }
    }
    public class GiphyData
    {
        public GiphyImages Images { get; set; }
    }
    public class GiphyImages
    {
        public GiphyOriginal Original { get; set; }
    }
    public class GiphyOriginal
    {
        public string Url { get; set; }
    }
}
