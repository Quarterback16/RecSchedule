using Xunit;
using Xunit.Abstractions;

namespace RecSchedule.Tests

{
    public class ActivityMatrixTests : BaseTests
    {
        private readonly ActivityMatrix _sut;

        public ActivityMatrixTests
            (ITestOutputHelper output) : base(output)
        {
            _sut = new ActivityMatrix(
                new CasualMaster(),
                new HardCoreMaster());
        }

        [Fact]
        public void Matrix_Contains_3_Casual()
        {
            Assert.True(
                condition: _sut.CasualMaster.Activities.Count == 3,
                userMessage: $"Casual count is {_sut.CasualMaster.Activities.Count}");
        }

        [Fact]
        public void Matrix_Contains_6_HardCore()
        {
            Assert.True(
                condition: _sut.HardcoreMaster.Activities.Count == 6,
                userMessage: $"Hardcore count is {_sut.HardcoreMaster.Activities.Count}");
        }

        [Fact]
        public void Matrix_Generates_SwikiTable()
        {
            var result = _sut.Generate();
            Assert.NotNull(result);
            output.WriteLine(result);
        }
    }

}
