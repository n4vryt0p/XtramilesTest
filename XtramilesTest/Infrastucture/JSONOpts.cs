using System.Text.Json;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public class JSONOpts : IJSONOpts
    {
        // set this up how you need to!
        private readonly JsonSerializerOptions jOpts = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };

        public JsonSerializerOptions JOpts() => jOpts;
    }
}
