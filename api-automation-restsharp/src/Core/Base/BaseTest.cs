using Clients;

namespace Core.Base;

public class BaseTest : FakeStoreAPIClient
{
    protected readonly FakeStoreAPIClient fakeStoreAPIClient;

    public BaseTest()
    {
        fakeStoreAPIClient = new FakeStoreAPIClient();
    }
}


