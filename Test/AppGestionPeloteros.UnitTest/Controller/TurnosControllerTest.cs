using AppGestionPeloteros.Controllers;
using Application.Services.DTOs.Turno;
using Application.Services.Iterfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Test.AppGestionPeloteros.UnitTest.Controller
{
    public class TurnosControllerTest
    {
        private readonly Mock<ITurnoService> _Mockservice;
        private readonly TurnoController _controller;

        public TurnosControllerTest()
        {
            _Mockservice = new Mock<ITurnoService>();
            _controller = new TurnoController(_Mockservice.Object);
        }

        [Fact]
        public async Task GetTurnosByWeek_ReturnsOkResult()
        {
            // Arrange
            var weekOk1 = new DateOnly(2025, 5, 2);
            var weekOk2 = new DateOnly(2025, 5, 3);

            var turnos = new List<TurnoDto>
            {
                new TurnoDto { TurnoId = Guid.NewGuid(), Fecha = weekOk1 },
                new TurnoDto { TurnoId = Guid.NewGuid(), Fecha = weekOk2 }
            };

            _Mockservice.Setup(s => s.GetByWeek(weekOk1)).ReturnsAsync(turnos);

            // Act

            var result = await _controller.GetTurnosByWeek(weekOk1);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<TurnoDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }
    }
}
