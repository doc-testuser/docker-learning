using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Integration
{
    public class IntegrationTests
    {
        private readonly TestContext _context;

        public IntegrationTests()
        {
            _context = new TestContext();
        }

        [Fact]
        public async Task PostData_ReturnsOkResponse()
        {
            // Act
            string json = "testuser";
            var jsonObj = JsonConvert.SerializeObject(json);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            var response = await _context.Client.PostAsync("/api/User", content);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOkResponse()
        {
            // Act
            var response = await _context.Client.GetAsync("/api/User");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsAListOfOwners()
        {
            // Act
            var response = await _context.Client.GetAsync("/api/User");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<object>(responseString);

            // Assert
            Assert.NotNull(values);
        }
    }
}
