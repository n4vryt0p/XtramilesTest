using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using XtramilesTest.Razor.Services;

namespace XtramilesTest.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IJSONOpts _iJsonOpts;
        private readonly IHttpClientFactory _httpClientFactory;
        public SelectList Countrieses { get; set; }

        public IndexModel(IHttpClientFactory httpClientFactory, IJSONOpts iJsonOpts)
        {
            _httpClientFactory = httpClientFactory;
            _iJsonOpts = iJsonOpts;
        }

        //[BindProperty]
        //public IEnumerable<Countries> Countrieses { get; set; }

        public async Task OnGetAsync()
        {
            Countrieses = new SelectList(await PopulateCountriesAsync().ConfigureAwait(false), "Abbreviation", "Country");
        }

        private async Task<IEnumerable<Countries>> PopulateCountriesAsync()
        {
            using var client = _httpClientFactory.CreateClient("api");
            var options = await client.GetStreamAsync("Country").ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<IEnumerable<Countries>>(options, _iJsonOpts.JOpts()).ConfigureAwait(false);
        }

        public class Countries
        {
            [BindProperty]
            public string Country { get; set; }
            [BindProperty]
            public string Abbreviation { get; set; }
        }
    }
}
