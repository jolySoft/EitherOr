using Shouldly;
using WebEnabled.Tv.EitherOr;

namespace WenEnabled.Tv.NVar.Tests;

public class EitherTests
{
    private Either<LeftStub, RightStub>? _either;
    private RightStub _rightValue;
    private LeftStub _leftValue;

    public EitherTests()
    {
        _rightValue = new RightStub();
        _leftValue = new LeftStub();
    }

    [Fact]
    public void RightShouldGet()
    {
        _either = new Right<LeftStub, RightStub>(_rightValue);
        
        var right = _either.Get();
        
        right.ShouldBeEquivalentTo(_rightValue);
    }

    [Fact]
    public void RightShouldThrowOnGetLeft()
    {
        _either = new Right<LeftStub, RightStub>(_rightValue);

        Assert.Throws<NotImplementedException>(() => _either.GetLeft());
    }

    [Fact]
    public void LeftShouldGetLeft()
    {
        _either = new Left<LeftStub, RightStub>(_leftValue);

        var left = _either.GetLeft();
        
        left.ShouldBeEquivalentTo(left);
    }

    [Fact]
    public void LeftShouldThrowGet()
    {
        _either = new Left<LeftStub, RightStub>(_leftValue);
        
        Assert.Throws<NotImplementedException>(() => _either.Get());
    }
}