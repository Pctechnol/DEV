using InsightConsulting.Domain.Entities;
using System.Linq;

namespace InsightConsulting.Domain.Interfaces
{
    /// <summary>
    /// Defines the contractual obligation for a Insight Consulting domain
    /// query provider.
    /// </summary>
    public interface IDomainQueryProvider
    {
        IQueryable<Users> UsersQuery { get; }
    }
}
