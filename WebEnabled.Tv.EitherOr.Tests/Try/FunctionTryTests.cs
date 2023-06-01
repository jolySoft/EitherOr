namespace WenEnabled.Tv.EitherOr.Tests.Try;

using Doubles;
using Shouldly;
using WebEnabled.Tv.EitherOr;

public class FunctionTryTests
{
    [Fact]
    public void SuccessfulTryCanChainOnFinally()
    {
        var final = new RightStub("Junk");
        
        var success = Try<RightStub>.Of(() => new RightStub("Initial")).Finally(() => final.Stringly = "Finally");

        success.Result.Stringly.ShouldBe("Initial");
        final.Stringly.ShouldBe("Finally");
    }

    [Fact]
    public void FailedTryCanChainOnFinally()
    {
        var dbConn = new RightStub("DB Connection Open!!!");

        var failure = Try<RightStub>.Of(() => new RightStub("Bang").Throwly())
            .Finally(() => dbConn.Stringly = "Close the DB");
        
        failure.IsFailure().ShouldBeTrue();
        failure.Exp.ShouldBeOfType(typeof(ApplicationException));
        dbConn.Stringly.ShouldBe("Close the DB");
    }

    [Fact]
    public void SuccessfulTryShouldGiveRightToEither()
    {
        var success = Try<RightStub>.Of(() => new RightStub("Initial")).ToEither();
        
        success.IsRight.ShouldBeTrue();
        success.Get().Stringly.ShouldBe("Initial");
    }

    [Fact]
    public void FailedTryShouldGiveLeftToEither()
    {
        var failed = Try<RightStub>.Of(() => new RightStub("Initial").Throwly()).ToEither();
        
        failed.IsLeft.ShouldBeTrue();
        failed.GetLeft().ShouldBeAssignableTo(typeof(ApplicationException));
    }
    
    [Fact]
    public void SuccessfulTryFunctionalVariantCanChainOnFinally()
    {
        var final = new RightStub("Junk");
        
        var success = Try<RightStub>.Of(new object[]{"Initial"}, (string s) => new RightStub(s)).Finally(() => final.Stringly = "Finally");
        
        success.Result.Stringly.ShouldBe("Initial");
        final.Stringly.ShouldBe("Finally");
    }
    
    [Fact]
    public void SuccessfulTryFunctionalVariant2CanChainOnFinally()
    {
        var final = new RightStub("Junk");
        
        var success = Try<RightStub>.Of(new object[]{"Initial", 1}, (string s, int i) =>
        {
            var stub = new RightStub(s);
            stub.Stringly += i;
            return stub;
        }).Finally(() => final.Stringly = "Finally");
        
        success.Result.Stringly.ShouldBe("Initial1");
        final.Stringly.ShouldBe("Finally");
    }
}