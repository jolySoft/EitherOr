namespace WenEnabled.Tv.EitherOr.Tests.Either;

using Shouldly;
using WebEnabled.Tv.EitherOr;
using WebEnabled.Tv.EitherOr.Void;

public class EitherFilterTests
{
    [Fact]
    public void RightShouldFilter()
    {
        var either = Either<int, string>.Right("Right");
        var expectedSomething = Unitable<Either<int, string>>.Some(either);
        var expectedNothing = Unitable<Either<int, string>>.Unit();

        either.Filter(s => s.Equals("Right")).ShouldBeEquivalentTo(expectedSomething);
        either.Filter(s => s.Equals("Computer says NO")).ShouldBeEquivalentTo(expectedNothing);
    }

    [Fact]
    public void LeftShouldFilter()
    {
        var either = Either<int, string>.Left(1);
        var expectedSomething = Unitable<Either<int, string>>.Some(Either<int, string>.Right("Right"));
        
        either.Filter(s => s.Equals("Right")).ShouldBeEquivalentTo(expectedSomething);
        either.Filter(s => s.Equals("Computer says NO")).ShouldBeEquivalentTo(expectedSomething);
    }

    [Fact]
    public void RightShouldFilterOrElse()
    {
        var either = Either<int, string>.Right("61");

        either.FilterOrElse(s => s.Equals("61"), Convert.ToInt32).ShouldBeEquivalentTo(either);
        either.FilterOrElse(s => s.Equals("Computer Says No"), Convert.ToInt32).GetLeft().ShouldBe(61);
    }

    [Fact]
    public void LeftShouldFilterOrElse()
    {
        var either = Either<int, string>.Left(61);
        
        either.FilterOrElse(s => s.Equals("61"), Convert.ToInt32).ShouldBeEquivalentTo(either);
        either.FilterOrElse(s => s.Equals("Brian"), Convert.ToInt32).ShouldBeEquivalentTo(either);
    }
}