namespace WebEnabled.Tv.EitherOr;

using Void;

public abstract class Try : ITry
{
    public abstract bool IsSuccessful();
    public abstract bool IsFailure();
    public Exception? Exp { get; protected init; }

    public static ITry Run(Action action)
    {
        try
        {
            action.Invoke();
            return new Success();
        }
        catch (Exception? e)
        {
            return new Failure(e);
        }
    }

    public ITry Finally(Action action)
    {
        try
        {
            action.Invoke();
            return this;
        }
        catch (Exception? e)
        {
            return new Failure(e);
        }
    }

    public Either<Exception, Unit> ToEither()
    {
        return IsSuccessful() ? Either<Exception, Unit>.Right(new Unit()) : Either<Exception, Unit>.Left(Exp ?? throw new InvalidOperationException());
    }
}