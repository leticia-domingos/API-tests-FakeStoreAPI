using RestSharp;

namespace Clients;

public class FakeStoreAPIClient{
    protected Uri BaseAddress { get; } = new Uri("https://fakestoreapi.com/");

    protected RestClient GetRestClient()
    {
        var options = new RestClientOptions(BaseAddress)
        {
            ThrowOnAnyError = true,
            Timeout = TimeSpan.FromMilliseconds(10000)
        };
        
        var client = new RestClient(options);
        return client;
    }
}