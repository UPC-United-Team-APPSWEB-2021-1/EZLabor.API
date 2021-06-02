using NUnit.Framework;
using Moq;
using FluentAssertions;
using System.Threading.Tasks;
using System.Collections.Generic;
using EZLabor.API.SocialMedia.Domain.Model;
using EZLabor.API.SocialMedia.Services;
using EZLabor.API.SocialMedia.Domain.Services.Communications;
using EZLabor.API.SocialMedia.Domain.Persistence.Respositories;
using EZLabor.API.Domain.Persistence.Repositories;

namespace EZLabor.API.Test
{
    public class CommentServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoCommentsReturnsEmptyCollection()
        {
            //Arrange
            var mockCommentRepository = GetDefaultICommentRepositoryInstance();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var commentId = 200;
            mockCommentRepository.Setup(r => r.FindById(employerId))
                .Returns(Task.FromResult<Comment>(null));

            var service = new CommentService(mockCommentRepository.Object, mockUnitOfWork.Object);
            //Act
            CommentResponse result = await service.GetByIdAsync(commentId);
            var message = result.Message;

            //Assert
            message.Should().Be("Comment not found");
        }

        private Mock<ICommentRepository> GetDefaultICommentRepositoryInstance()
        {
            return new Mock<ICommentRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}