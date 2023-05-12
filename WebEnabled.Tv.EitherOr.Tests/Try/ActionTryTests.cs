namespace WenEnabled.Tv.EitherOr.Tests.Try;

using Doubles;
using Shouldly;
using WebEnabled.Tv.EitherOr;
using WebEnabled.Tv.EitherOr.Void;

public class ActionTryTests
{
    [Fact]
    public void SuccessfulRunCanChainOnFinally()
    {
        var rightRef = new RightStub("Initial");
        
        var result = Try.Run(() => rightRef.Stringly = "Updated").Finally(() => rightRef.Stringly = "Finally");
        
        result.IsSuccessful().ShouldBeTrue();
        rightRef.Stringly.ShouldBe("Finally");
    }

    [Fact]
    public void FailedRunCanChainOnFinally()
    {
        var rightRef = new RightStub("Initial");
        var expected = new ApplicationException();

        var failure = Try.Run(() => rightRef.Throwly()).Finally(() => rightRef.Stringly = "Updated");

        failure.IsFailure().ShouldBeTrue();
        //Don't like this assertion, think of a better way
        failure.Exp.ShouldBeOfType(expected.GetType());
    }

    [Fact]
    public void SuccessfulRunShouldGiveRightToEither()
    {
        var rightRef = new RightStub("Initial");

        var either = Try.Run(() => rightRef.Stringly = "Updated").ToEither();
        
            rightRef.Stringly.ShouldBe("Updated");
        either.IsRight.ShouldBeTrue();
        either.Get().ShouldBeEquivalentTo(new Unit());
    }

    [Fact]
    public void FailedRunShouldGiveExceptionToEither()
    {
        var rightRef = new RightStub("Initial");

        var either = Try.Run(() => rightRef.Throwly()).ToEither();
        
        either.IsLeft.ShouldBeTrue();
        either.GetLeft().ShouldBeAssignableTo(typeof(ApplicationException));
    }
}