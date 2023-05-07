using DataTable.BLL.Services;
using DataTable.DAL.Repositories.Interfaces;
using Moq;

namespace DataTable.Test
{
    public class BaseServiceTest
    {
        public BaseServiceTest()
        {
            userRepository = new Mock<IUserRepository>();
            userService = new Mock<IUserService>();
        }

        public Mock<IUserRepository> userRepository { get; set; }
        public Mock<IUserService> userService { get; set; }
    }
}