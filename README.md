# Welcome to EitherOr

This code base was inspired by [vavr](https://github.com/vavr-io/vavr) as it's intention is as a framework playground for you and me. Please feel free to fork and have a play with the either and try patterns, they're quite melon twisting. However it's not production battle hardened but the good news is that [Language Ext](https://github.com/louthy/language-ext) is so if you're looking for something to **really use** then head over there and get yourself involved.

## Pattern Basics

OK let me start with an opinion, exception flow control in dotnet is a bad idea, especially for validation errors.  However there are points in any running application where exception occur and they need handling, i.e. an external service is down or resources have become exhausted.  You generally don't want to return these to the external caller.  Therefore we litter the code with `try catch` blocks.  This is where the Either or Try patterns can help.  The Either is a right hand side biased generic pattern where the right hand side is a successful result and the left hand side is a failure.  In the Try pattern, which a specialism of Either, the left is a an exception and the right is the successful result that you would have normally have returned. The definitions would look something like this:

`Either<failure, success>` `Try<success>`

Notice that `Try` doesn't have a left hand side generic type, this is because it hides the `try catch` block for you so the left is always an exception.  If you would like further reading on the pattern head over to [ThoughtWorks](https://www.thoughtworks.com/en-gb/insights/blog/either-data-type-alternative-throwing-exceptions) for an in depth explanation.

## Web API Example

So how would you consume this pattern . . .

```csharp
[HttpPost]
public IActionResult Post(CustomerDto dto) {
    return Try<Customer>.Of(new object[] { dto }, (dto) =>
        {
            var customer = Customer.FromDto(dto);
            _customerDomainService.Save(customer);
        }).ToEither()
          .Map(c => OK(c.Id))
          .MapLeft(e => StatusCode(StatusCodes.Status500InternalServerError, "Oops, something went wrong");
```

## TODO

- Extend Either to support async
- Extend Try to support async
- Add reducer to Either

