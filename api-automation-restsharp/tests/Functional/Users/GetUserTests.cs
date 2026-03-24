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
        private RestResponse ExecuteGetUserRequest()
        {
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get);

            return client.Execute(request);
        }
        private static List<User> ? DeserializeUser(RestResponse response)
        {
            return JsonSerializer.Deserialize<List<User>>(response.Content ?? string.Empty);
        }

        [Fact]
        public void GetUser_QuandoRequisicaoForValida_DeveRetornarListaDeUsuarios()
        {
            // Arrange


            // Act
            var response = ExecuteGetUserRequest();

            // Assert
            var jsonUsers = DeserializeUser(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK); 

            jsonUsers.Should().NotBeNull(); 
            jsonUsers.Should().NotBeEmpty();
            jsonUsers.Select(user => user.Id).Should().OnlyHaveUniqueItems();

           foreach(var user in jsonUsers)
            {
                user.Id.Should().BeGreaterThan(0);
                user.Email.Should().NotBeNullOrWhiteSpace();
                user.Username.Should().NotBeNullOrWhiteSpace();
                user.Password.Should().NotBeNullOrWhiteSpace();
                user.Name.Should().NotBeNull();
                user.Phone.Should().NotBeNullOrWhiteSpace();
            }; 
        }
    }
}