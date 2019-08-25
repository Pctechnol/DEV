using InsightConsulting.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsightConsulting.Tests
{
    [TestClass]
    public class UserTests
    {
        public InsightConsulting.EF.InsightConsultingDbContext InsightConsultingDbContext;
        
        public UserTests()
        {
            var options = new DbContextOptionsBuilder<InsightConsulting.EF.InsightConsultingDbContext>()
               .UseInMemoryDatabase("InsightConsultingDB:DefaultConnection")
               .Options;

            InsightConsultingDbContext = new InsightConsulting.EF.InsightConsultingDbContext(options);
        }

        [TestMethod]
        public void TestUserAdd()
        {
            var result = InsightConsultingDbContext.UsersQuery.ToListAsync();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUserById()
        {
            var result = InsightConsultingDbContext.Users.FirstAsync(p => p.Id == 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var result = InsightConsultingDbContext.Update(new Users
            {
                firstName = "Test",
                lastName = "Tester",
                age = 40,
                address = "123 Test Address",
                city = "Test City",
                country = "Test Country",
                dateOfBirth = new System.DateTime(1900, 01, 01),
                email = "test@email.com",
                identityNumber = 452452345,
                lineOne = "add line",
                lineTwo = "add line2",
                postalCode = 1234
            });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var getUserList = InsightConsultingDbContext.UsersQuery.ToListAsync();
            Assert.IsNotNull(getUserList);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var result = InsightConsultingDbContext.Remove(new Users
            {
                firstName = "Test",
                lastName = "Tester",
                age = 40,
                address = "123 Test Address",
                city = "Test City",
                country = "Test Country",
                dateOfBirth = new System.DateTime(1900, 01, 01),
                email = "test@email.com",
                identityNumber = 452352345,
                lineOne = "add line",
                lineTwo = "add line2",
                postalCode = 1234
            });
            Assert.IsNotNull(result);
        }
    }
}
