namespace WebEnabled.Tv.EitherOr;

public class Failure : Try
{
    public Failure(Exception? exception)
    {
        Exp = exception;
    }

    public override bool IsSuccessful() => false;

    public override bool IsFailure() => true;
}