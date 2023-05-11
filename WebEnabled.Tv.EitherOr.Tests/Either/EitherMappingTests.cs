using Shouldly;
using WenEnabled.Tv.EitherOr.Tests.Doubles;

namespace WenEnabled.Tv.EitherOr.Tests.Either;

using WebEnabled.Tv.EitherOr;

public class EitherMappingTests
{
    private Either<int, string>? _either;

    [Fact]
    public void RightShouldBiMap()
    {
        _either = Either<int, string>.Right("1");
        var expected = Either<LeftStub, RightStub>.Right(new RightStub("11"));

        var rightResult = _either.BiMap(i => new LeftStub(i + 1), s => new RightStub(s + "1"));
        
        rightResult.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void LeftShouldBiMap()
    {
        _either = Either<int, string>.Left(1);
        var expected = Either<LeftStub, RightStub>.Left( new LeftStub(2));
        
        var leftResult = _either.BiMap(i => new LeftStub(i + 1), s => new RightStub(s + "1"));
        
        leftResult.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void RightShouldMapResult()
    {
        _either = Either<int, string>.Right("a");
        var expected = Either<int, RightStub>.Right(new RightStub("A"));

        var rightResult = _either.Map(s => new RightStub(s.ToUpper()));
        
        rightResult.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void LeftShouldMapToLeft()
    {
        _either = Either<int, string>.Left(1);
        var expected = Either<int, RightStub>.Left(1);

        var left = _either.Map(s => new RightStub(s.ToUpper()));
        
        left.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void LeftShouldMapLeftToResult()
    {
        _either = Either<int, string>.Left(1);
        var expected = Either<LeftStub, string>.Left(new LeftStub(2));

        var left = _either.MapLeft(i => new LeftStub(i + 1));
        
        left.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void RightShouldMapLeftToRight()
    {
        _either = Either<int, string>.Right("a");
        var expected = Either<int, string>.Right("a");

        var right = _either.MapLeft(i => i + 1);
        
        right.ShouldBeEquivalentTo(expected);
    }
}