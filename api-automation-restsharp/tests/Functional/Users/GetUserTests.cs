using System.Net;
using System.Text.Json;
using Core.Base;
using Routes;
using Schemas;
using RestSharp;
using FluentAssertions;

namespace Tests.Functional.Users
{
    public class GetUserTests : BaseTest
    {
        [Fact]
        public void GetUsers_Deve_Retornar_Usuarios()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); 

            // Act
            var response = client.Execute(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK); 
            
            var jsonUser = JsonSerializer.Deserialize<List<User>>(response.Content ?? string.Empty); 
            jsonUser.Should().NotBeNull(); 

            foreach(var user in jsonUser)
            {
                user.Id.Should().BeGreaterThan(0);
                user.Email.Should().NotBeNullOrWhiteSpace();
                user.Username.Should().NotBeNullOrWhiteSpace();
                user.Password.Should().NotBeNullOrWhiteSpace();
                user.Name.Should().NotBeNull();
                user.Name.FirstName.Should().NotBeNullOrWhiteSpace();
                user.Name.LastName.Should().NotBeNullOrWhiteSpace();
                user.Phone.Should().NotBeNullOrWhiteSpace();
            };
        }
    }
}