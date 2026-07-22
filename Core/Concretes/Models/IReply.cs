namespace Core.Concretes.Models
{
    public class Reply(bool isSuccess, IEnumerable<string>? errors = null)
    {
        public bool IsSuccess => isSuccess;
        public IEnumerable<string>? Errors => errors;

        public static Reply Success() => new(true);

        public static Reply Fail(IEnumerable<string> errors) => new(false, errors);
        public static Reply Fail(string error) => new(false, [error]);
        public static Reply Fail() => new(false);

    }
}
