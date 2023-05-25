namespace WebEnabled.Tv.EitherOr;

using Void;

public interface ITry<TResult>
{
    bool IsSuccessful();

    bool IsFailure();
    
    Exception? Exp { get; }
    
    TResult Result { get; }

    //ITry<TResult> Of(Func<TResult> func);

    new ITry<TResult> Finally(Action action)
    {
        try
        {
            action.Invoke();
            return this;
        }
        catch (Exception? e)
        {
            return new Failure<TResult>(e);
        }
    }
    
    new Either<Exception, TResult> ToEither();
}
