using DogList.Domain.Core.Results;

namespace DogList.Domain.Dogs;

public static class DogErrors
{
    public static readonly Error InvalidName = Error.Validation(
        "Dog.InvalidName", "Name length mus be greater than 0 and contain only letters.");

    public static readonly Error InvalidColor = Error.Validation(
        "Dog.InvalidColor", "Color name length must be equal to or greater than 3 and contain only letters.");

    public static readonly Error InvalidTailLength = Error.Validation(
        "Dog.InvalidTailLength", "TailLength must be greater than 0.");

    public static readonly Error InvalidWeight = Error.Validation(
        "Dog.InvalidWeight", "Weight must be greater than 0.");

    public static readonly Error AlreadyExists = Error.Conflict(
        "Dog.AlreadyExists", "Dog with the same name already exists.");

    public static readonly Error AddError = Error.Internal(
        "Dog.AddError", "An error occurred while adding the dog.");
}