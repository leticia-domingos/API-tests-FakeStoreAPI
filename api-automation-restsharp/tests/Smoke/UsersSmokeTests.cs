using RestSharp;
using Routes;
using Core.Base;
using System.Net;
using FluentAssertions;


namespace Tests.Smoke
{
    public class UsersSmokeTests : BaseTest
    {
        [Fact]
        public void GetUser_Deve_Retornar_Sucesso()
        {
            // Arrange
            var client = GetRestClient();
            var request = new RestRequest(Endpoints.Users, Method.Get); // O header x-api-key já é adicionado no GetRestClient do BaseTest


            // Act
            var response = client.Execute(request);

            // Assert
            response.IsSuccessful.Should().BeTrue($"A API não está online. Status: {response.StatusCode}"); //IsSuccessful é uma propriedade do RestResponse que indica se a resposta foi bem-sucedida (status code 200-299)
            response.StatusCode.Should().Be(HttpStatusCode.OK); // Verifica se o status code é 200 OK
            response.Content.Should().NotBeNull(); // Verifica se o conteúdo da resposta não é nulo
            response.ContentType.Should().Contain("application/json"); // Verifica se o tipo de conteúdo é JSON
        }

    }
}
