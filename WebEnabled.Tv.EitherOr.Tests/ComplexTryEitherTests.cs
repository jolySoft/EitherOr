namespace WenEnabled.Tv.EitherOr.Tests;

using Doubles;
using Shouldly;
using WebEnabled.Tv.EitherOr;

public class ComplexTryEitherTests
{
    private delegate RightStub Worker(string initialiser, int answerToEverything, Type typeInQuestion);

    private Worker worker;

    public ComplexTryEitherTests()
    {
        worker = (initialiser, answerToEverything, typeInQuestion) =>
        {
            var stub = new RightStub(initialiser);
            stub.Stringly = $"The answer to everything is {answerToEverything}";
            if (typeInQuestion != stub.GetType()) throw new InvalidOperationException("You're not my type, sorry");
            return stub;
        };
    }

    [Fact]
    public void ShouldMapCorrectlyAfterSuccessfulTry()
    {
        var result = Try<RightStub>.Of(new object[] { "Initial", 42, typeof(RightStub) }, worker)
            .ToEither()
            .Map(rs => rs.Stringly)
            .MapLeft(e => e.Message);
        
        result.IsRight.ShouldBeTrue();
        result.Get().ShouldBe("The answer to everything is 42");
    }

    [Fact]
    public void ShouldMapLeftAfterFailure()
    {
        var result = Try<RightStub>.Of(new object[] { "Initial", 42, typeof(double) }, worker)
            .ToEither()
            .Map(rs => rs.Stringly)
            .MapLeft(e => e.InnerException.Message);
        
        result.IsLeft.ShouldBeTrue();
        result.GetLeft().ShouldBe("You're not my type, sorry");
    }
}