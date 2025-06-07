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

    }
}
