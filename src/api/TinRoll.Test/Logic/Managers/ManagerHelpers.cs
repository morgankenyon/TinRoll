using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Moq;
using TinRoll.Data.Entities;
using TinRoll.Data.Repositories.Interfaces;

namespace TinRoll.Test.Logic.Managers
{
    public static class ManagerHelpers
    {


        public static Mock<IBaseRepository<T>> MockRepoGetAsync<T>(IEnumerable<T> output) where T : BaseEntity
        {
            var mockRepo = new Mock<IBaseRepository<T>>();
            mockRepo.Setup(u => u.GetAsync(
                It.IsAny<Expression<Func<T, bool>>>(),
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                It.IsAny<string>()))
                .ReturnsAsync(output);
            return mockRepo;
        }

        public static void VerifyGetAsync<T>(Mock<IBaseRepository<T>> mockRepo, Times times) where T : BaseEntity
        {
            mockRepo.Verify(u => u.GetAsync(
                It.IsAny<Expression<Func<T, bool>>>(),
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                It.IsAny<string>()), times);
        }
    }
}
