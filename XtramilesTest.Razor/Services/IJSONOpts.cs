using System.Text.Json;

namespace XtramilesTest.Razor.Services
{
    public interface IJSONOpts
    {
        JsonSerializerOptions JOpts();
    }
}
