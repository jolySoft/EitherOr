namespace WebEnabled.Tv.EitherOr;

using Void;

public class Failure<TResult> : Failure, ITry<TResult>
{
    public Failure(Exception? exp) : base(exp) {}
    
    // public bool IsSuccessful() => base.IsSuccessful();
    //
    // public bool IsFailure() => base.IsSuccessful();

    // public Either<Exception, Unit> ToEither()
    // {
    //     throw new NotImplementedException();
    // }

    public TResult Result => throw new NotImplementedException("This is a failure");
    
    Either<Exception, TResult> ITry<TResult>.ToEither()
    {
        throw new NotImplementedException();
    }
}

public class Failure : ITry
{
    public Failure(Exception? exp)
    {
        Exp = exp;
    }

    public bool IsSuccessful() => false;

    public bool IsFailure() => true;
    
    public Exception? Exp { get; }
    
    public Either<Exception, Unit> ToEither()
    {
        return Either<Exception, Unit>.Left(Exp);
    }
}