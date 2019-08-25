using InsightConsulting.Domain.Entities;
using InsightConsulting.Domain.Interfaces;

namespace InsightConsulting.Domain
{
    /// <summary>
    /// Represents the Insight Consulting domain context. 
    /// The domain context provides the relevant entry points to the underlying Insight Consulting services.
    /// </summary>
    public sealed class InsightConsultingDomain
    {
        private readonly IRepository<Users> _usersRepository;

        public InsightConsultingDomain(IRepository<Users> userRepository)
        {
            _usersRepository = userRepository;
        }

        /// <summary>
        /// Provides access to the underlying person repository.
        /// </summary>
        public IRepository<Users> UsersRepository => _usersRepository;

    }
}
