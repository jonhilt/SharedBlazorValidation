using System.Threading;
using System.Threading.Tasks;

namespace SharedValidationExample.Shared.Account
{
    public interface IValidateEmail
    {
        Task<bool> CheckIfUnique(string email, CancellationToken cancellationToken);
    }
}