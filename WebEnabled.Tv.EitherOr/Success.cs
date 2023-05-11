namespace WebEnabled.Tv.EitherOr;

using Void;

public class Success : Try
{
    public override bool IsSuccessful() => true;
    public override bool IsFailure() => false;
}   