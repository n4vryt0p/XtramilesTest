using System.Text.Json;

namespace XtramilesTest.WebAPI.Infrastucture
{
    public interface IJSONOpts
    {
        JsonSerializerOptions JOpts();
    }
}
