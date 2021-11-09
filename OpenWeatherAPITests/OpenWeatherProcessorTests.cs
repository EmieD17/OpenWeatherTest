using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        [Fact]
        public async Task GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetOneCallAsync);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetCurrentWeatherAsync);
        }
    }
}
