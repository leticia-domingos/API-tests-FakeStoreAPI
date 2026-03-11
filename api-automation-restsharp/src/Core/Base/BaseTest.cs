using Clients;

namespace Core.Base;

public class BaseTest : ReqResClient
{
    protected readonly ReqResClient reqResClient;

    public BaseTest()
    {
        reqResClient = new ReqResClient();
    }
}


