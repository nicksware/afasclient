using System.Threading.Tasks;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace DutchGrit.Afas.Tests
{
    public class MetaTests : IClassFixture<ClientFixture>
    {

        public static string ConnectorID = "Profit_VAT_code";

        ClientFixture fixture;
        public MetaTests(ClientFixture fixture) { this.fixture = fixture; }

        [Fact]
        public async Task SessionInfoAsync()
        {
            await this.fixture.Client.GetSessionInfoAsync();
        }

        [Fact]
        public async Task VersionAsync()
        {
            await this.fixture.Client.GetVersionAsync();
        }

        [Fact]
        public async Task GetMetaDataGetConAsync()
        {
            await this.fixture.Client.GetMetaDataGetConAsync(ConnectorID);
        }

        [Fact]
        public async Task GetQueryAsync()
        {
            await this.fixture.Client.Query<ProfitVATcode>().Take(1).GetAsync();
        }
    }
}
