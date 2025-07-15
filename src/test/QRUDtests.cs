using System;
using System.Threading.Tasks;
using Xunit;

namespace DutchGrit.Afas.Tests
{
    public class UpdateableProfitVATcode : IUpdateable<ProfitVATcode>
    {
        public ProfitVATcode Entity { get; }
        public IUpdateEntity[] Objects => Array.Empty<IUpdateEntity>();

        public UpdateableProfitVATcode(ProfitVATcode entity) => Entity = entity;
    }

    public class QRUDtests(ClientFixture fixture) : IClassFixture<ClientFixture>
    {
        private readonly IGeneralClient _client = fixture.Client ?? throw new ArgumentNullException(nameof(fixture.Client));

        [Fact]
        public async Task ShouldInsertAndRemoveVatCode()
        {
            // Arrange: ensure no existing records with VatPerc 99
            var records = await _client.Query<ProfitVATcode>()
                          .WhereEquals(x => x.VatPerc, "99")
                          .GetAsync();
            Assert.Empty(records);

            // Count existing records
            var before = (await _client.Query<ProfitVATcode>().GetAsync()).Length;

            // Prepare a new VAT code (ensure your connector requires BcCo and Code)
            var newVat = new ProfitVATcode
            {
                VatCode = "TEST99",
                VatPerc = 99,
                Description = "Test VAT Code",
            };
            var insertWrapper = new UpdateableProfitVATcode(newVat);

            // INSERT
            var insertResult = await _client.SaveAsync(insertWrapper);
            Assert.True(insertResult.IsSuccess, "Insert operation failed.");

            // Assert count went up by 1
            var afterInsert = (await _client.Query<ProfitVATcode>().GetAsync()).Length;
            Assert.Equal(before + 1, afterInsert);

            // DELETE — wrap the returned “Result” (which includes key fields) again
            var toDelete = insertResult.Result;
            var deleteWrapper = new UpdateableProfitVATcode(toDelete);
            var deleteResult = await _client.SaveAsync(deleteWrapper);
            Assert.True(deleteResult.IsSuccess, "Delete operation failed.");

            // Assert count is back to original
            var afterDelete = (await _client.Query<ProfitVATcode>().GetAsync()).Length;
            Assert.Equal(before, afterDelete);
        }
    }
}
