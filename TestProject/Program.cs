using ForsyteIT.CosmosAPI;

namespace TestProject
{
    internal static class Program
    {
        static async Task Main()
        {
            await InitializeData.InitializeDbApiAsync();
            await InitializeData.InitializeServiceBusApiAsync();
            await InitializeData.InitializeGraphResourcesAsync();
            await InitializeData.InitializeB2CAsync();
            await InitializeData.InitializeServiceBusApiAsync();
            await InitializeData.InitializeGInsyteConnectionApiAsync();

            Console.ReadLine();
        }
    }
}