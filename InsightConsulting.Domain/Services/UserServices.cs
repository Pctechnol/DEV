using InsightConsulting.Domain.Entities;
using System.Linq;

namespace InsightConsulting.Domain.Services
{
    /// <summary>
    /// User Services
    /// </summary>
    public static class UserServices
    {
        public static IQueryable<Users> GetAll(InsightConsultingDomain context)
        {
            return context.UsersRepository.FromSqlProc("dbo.GetAllUsers");
        }

        public static Users GetUser(InsightConsultingDomain context,int? id)
        {
            return context.UsersRepository.GetSingle(id);
        }

        public static Users UpdateUser(InsightConsultingDomain context,
                                                  Users user)
        {
            context.UsersRepository.Update(user);
            context.UsersRepository.Commit();
            return context.UsersRepository.GetSingle(user.Id);
        }

        public static Users AddUser(InsightConsultingDomain context,
                                                Users user)
        {
            context.UsersRepository.Add(user);
            context.UsersRepository.Commit();
            return context.UsersRepository.GetSingle(user.Id);
        }

        public static Users Delete(InsightConsultingDomain context,
                                                int id)
        {
            var user = context.UsersRepository.GetSingle(id);
            context.UsersRepository.Delete(user);
            context.UsersRepository.Commit();
            return user;
        }
    }
}
