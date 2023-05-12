namespace WenEnabled.Tv.EitherOr.Tests.Try;

using Doubles;
using Shouldly;
using WebEnabled.Tv.EitherOr;

public class FunctionTryTests
{
    [Fact]
    public void SuccessfulTryReturnsFuncResult()
    {
        var expected = new RightStub("Initial");
        
        var success = Try<RightStub>.Of(() => new RightStub("Initial"));

        success.Result.Stringly.ShouldBe("Initial");
    }
}