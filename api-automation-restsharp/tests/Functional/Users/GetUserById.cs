using RestSharp;
using Routes;
using System.Net;
using Core.Base;
using FluentAssertions;
using System.Text.Json;
using Schemas;

namespace Tests.Functional.Users
{
    public class GetUserByIdTests : BaseTest
    {
        private RestResponse ExecuteGetUserByIdRequest(int userId)
        {
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.UsersById, Method.Get);
            request.AddUrlSegment("id", userId);

            return client.Execute(request);
        }
        private static User ? DeserializeUser(RestResponse response)
        {
            return JsonSerializer.Deserialize<User>(response.Content ?? string.Empty);
        }

        [Fact]
        public void GetUserById_QuandoRequisicaoForValida_DeveRetornarUsuario()
        {
            // Arrange
            var requestedId = 2;
            
            // Act
            var response = ExecuteGetUserByIdRequest(requestedId);

            // Assert
            var jsonUser = DeserializeUser(response);

            response.StatusCode.Should().Be(HttpStatusCode.OK); 

            jsonUser.Should().NotBeNull(); 
            jsonUser.Id.Should().Be(requestedId);
            jsonUser.Email.Should().NotBeNullOrWhiteSpace();
            jsonUser.Email.Should().MatchRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            jsonUser.Username.Should().NotBeNullOrWhiteSpace();
            jsonUser.Password.Should().NotBeNullOrWhiteSpace();
            jsonUser.Name.Should().NotBeNull();
            jsonUser.Phone.Should().NotBeNullOrWhiteSpace();
            jsonUser.Phone.Should().MatchRegex(@"^\d{1}-\d{3}-\d{3}-\d{4}$");
            jsonUser.Name.FirstName.Should().NotBeNullOrWhiteSpace();
            jsonUser.Name.LastName.Should().NotBeNullOrWhiteSpace();

        // TODO: Quebrar esses testes em outros Facts futuramente:
        // GetUsers_DeveRetornarStatus200
        // GetUsers_DeveRetornarListaNaoVazia
        // GetUsers_DeveRetornarUsuariosComIdsUnicos
        // GetUsers_DeveRetornarUsuariosComCamposObrigatorios
        }
    }
}

