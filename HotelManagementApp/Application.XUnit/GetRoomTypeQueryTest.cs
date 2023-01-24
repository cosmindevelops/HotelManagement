using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RoomTypes.DTO;
using Application.RoomTypes.Queries.GetAllRoomTypes;
using Application.RoomTypes.Queries.GetRoomTypeById;
using AutoMapper;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.XUnit
{
    public class GetRoomTypeQueryTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        public GetRoomTypeQueryTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_GetAllRoomTypesQuery_Expected_Result()
        {
            // Arrange
            var roomTypes = new List<RoomType>
        {
            new RoomType { Id = 1, Title = "Single", Description = "Single room", Price = 50 },
            new RoomType { Id = 2, Title = "Double", Description = "Double room", Price = 70 }
        };
            var expectedResult = new List<RoomTypeGetDTO>
        {
            new RoomTypeGetDTO { Id = 1, Title = "Single", Description = "Single room", Price = 50 },
            new RoomTypeGetDTO { Id = 2, Title = "Double", Description = "Double room", Price = 70 }
        };
            _mockUnitOfWork.Setup(x => x.RoomTypeRepository.GetAllRoomTypesAsync()).ReturnsAsync(roomTypes);
            _mockMapper.Setup(x => x.Map<IEnumerable<RoomTypeGetDTO>>(It.IsAny<IEnumerable<RoomType>>())).Returns(expectedResult);

            var query = new GetAllRoomTypesQuery();
            var queryHandler = new GetAllRoomTypesQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public async Task Handle_GetAllRoomTypesQuery_RoomTypeNotFound_Throws_RoomTypeNotFoundException()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.RoomTypeRepository.GetAllRoomTypesAsync()).ReturnsAsync((List<RoomType>)null);

            // Act
            var query = new GetAllRoomTypesQuery();
            var queryHandler = new GetAllRoomTypesQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            Func<Task> action = async () => await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<RoomTypeNotFoundException>(action);

        }
        
        [Fact]
        public async void Handle_GetRoomTypeByIdQuery_Returns_Expected_Result()
        {
            // Arrange
            var roomType = new RoomType { Id = 1, Title = "Single", Description = "Single room", Price = 50 };
            var expectedResult = new RoomTypeGetDTO { Id = 1, Title = "Single", Description = "Single room", Price = 50 };
                 
            _mockUnitOfWork.Setup(x => x.RoomTypeRepository.GetRoomTypeByIdAsync(1)).ReturnsAsync(roomType);
            _mockMapper.Setup(x => x.Map<RoomTypeGetDTO>(It.IsAny<RoomType>())).Returns(expectedResult);

            var query = new GetRoomTypeByIdQuery(1);
            var queryHandler = new GetRoomTypeByIdQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);


            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void Handle_GetRoomTypeByIdQuery_RoomTypeNotFound_Throws_RoomTypeNotFoundException()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.RoomTypeRepository.GetRoomTypeByIdAsync(1)).ReturnsAsync((RoomType)null);
            var queryHandler = new GetRoomTypeByIdQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            var query = new GetRoomTypeByIdQuery(1);

            // Act & Assert
            await Assert.ThrowsAsync<RoomTypeNotFoundException>(() => queryHandler.Handle(query, CancellationToken.None));
        }

    }
}
