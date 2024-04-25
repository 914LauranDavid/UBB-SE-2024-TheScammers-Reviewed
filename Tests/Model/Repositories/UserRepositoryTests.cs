using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISSLab.Model;
using ISSLab.Model.Repositories;
using Moq;

namespace Tests.Model.Repositories
{
    internal class UserRepositoryTests
    {
        public UserRepository userRepository;

        [SetUp]
        public void SetUp()
        {
            userRepository = new UserRepository();
        }

        [Test]
        public void FindAllUsers_NoUsers_ReturnsEmptyList()
        {
            Assert.That(userRepository.FindAllUsers(), Is.Empty);
        }

        [Test]
        public void FindAllUsers_AtLeastOneUser_ReturnsTheUsers()
        {
            User firstAddedUser = new User();
            User secondAddedUser = new User();
            userRepository.AddUser(firstAddedUser);
            userRepository.AddUser(secondAddedUser);

            Assert.That(userRepository.FindAllUsers(), Is.EquivalentTo(new List<User> { firstAddedUser, secondAddedUser }));
        }

        [Test]
        public void FindById_IdExists_TheUserIsReturned()
        {
            Guid userId = Guid.NewGuid();
            User addedUser = new User(userId, "", "", DateOnly.Parse("10.10.2020"), "", "", DateTime.Now, new List<Guid>(),
                new List<Guid>(), new List<SellingUserScore>(), )
        }
    }
}
