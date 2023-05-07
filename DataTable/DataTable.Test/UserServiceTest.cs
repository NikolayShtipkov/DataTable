using DataTable.BLL.Services;
using DataTable.DAL.Entities;
using DataTable.DAL.Enums;
using Moq;
using Xunit;

namespace DataTable.Test
{
    public class UserServiceTest : BaseServiceTest
    {
        [Fact]
        public async Task CreateUserAsync_SuccessfullyCreatesWithValidInput()
        {
            var sut = new UserService(userRepository.Object);

            await sut.CreateUserAsync(new User());

            userRepository.Verify(mock => mock.InsertAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task EditUserAsync_SuccessfullyEditsWithValidInput()
        {
            var sut = new UserService(userRepository.Object);

            var user = new User();
            userRepository.Setup(ur => ur.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            await sut.EditUserAsync(new User(), new Guid());

            userRepository.Verify(mock => mock.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task EditUserAsync_ThrowsException()
        {
            var sut = new UserService(userRepository.Object);

            await Assert.ThrowsAsync<Exception>(async () => await sut.EditUserAsync(new User(), new Guid()));
        }

        [Fact]
        public async Task DeleteUserAsync_SuccessfullyDeletesWithValidInput()
        {
            var sut = new UserService(userRepository.Object);

            var user = new User();
            userRepository.Setup(ur => ur.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            await sut.DeleteUserAsync(new Guid());

            userRepository.Verify(mock => mock.Delete(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ThrowsException()
        {
            var sut = new UserService(userRepository.Object);

            await Assert.ThrowsAsync<Exception>(async () => await sut.DeleteUserAsync(new Guid()));
        }

        [Fact]
        public async Task GetUserByIdAsync_SuccessfullyReturnsUser()
        {
            var sut = new UserService(userRepository.Object);

            var user = new User();
            userRepository.Setup(ur => ur.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

            var result = await sut.GetUserByIdAsync(new Guid());

            Assert.Equal(result, user);
        }

        [Fact]
        public async Task GetUserByIdAsync_ThrowsException()
        {
            var sut = new UserService(userRepository.Object);

            await Assert.ThrowsAsync<Exception>(async () => await sut.GetUserByIdAsync(new Guid()));
        }

        [Fact]
        public async Task GetAllUsersAsync_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            var users = new List<User>();
            userRepository.Setup(ur => ur.GetAllAsync()).ReturnsAsync(users);

            var result = await sut.GetAllUsersAsync();
            Assert.Equal(result, users);
        }

        [Fact]
        public void GetUsersSortedByName_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            IQueryable<User> users = Enumerable.Empty<User>().AsQueryable();
            userRepository.Setup(ur => ur.GetUsersSortedByName()).Returns(users);

            var result = sut.GetUsersSortedByName();
            Assert.Equal(result, users);
        }

        [Fact]
        public void GetUsersSortedByEmail_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            IQueryable<User> users = Enumerable.Empty<User>().AsQueryable();
            userRepository.Setup(ur => ur.GetUsersSortedByEmail()).Returns(users);

            var result = sut.GetUsersSortedByEmail();
            Assert.Equal(result, users);
        }

        [Fact]
        public void GetUsersFilteredByParameter_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            IQueryable<User> users = Enumerable.Empty<User>().AsQueryable();
            userRepository.Setup(ur => ur.GetUsersFilteredByParameter(It.IsAny<string>())).Returns(users);

            var result = sut.GetUsersFilteredByParameter("Test");
            Assert.Equal(result, users);
        }

        [Fact]
        public void GetUsersFilteredByRole_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            IQueryable<User> users = Enumerable.Empty<User>().AsQueryable();
            userRepository.Setup(ur => ur.GetUsersFilteredByRole(It.IsAny<Role>())).Returns(users);

            var result = sut.GetUsersFilteredByRole(0);
            Assert.Equal(result, users);
        }

        [Fact]
        public void GetUsersFilteredByStatus_SuccessfullyReturnsCollection()
        {
            var sut = new UserService(userRepository.Object);

            IQueryable<User> users = Enumerable.Empty<User>().AsQueryable();
            userRepository.Setup(ur => ur.GetUsersFilteredByStatus(It.IsAny<bool>())).Returns(users);

            var result = sut.GetUsersFilteredByStatus(0);
            Assert.Equal(result, users);
        }
    }
}
