using Dominio.Entities;
using Dominio.Models.Parameters;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;

namespace Test.AppGestionPeloteros.IntegrationTest.Controller
{
    public class TurnosControllerTest : IClassFixture<TurnosWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly TurnosWebApplicationFactory<Program> _factory;
        public TurnosControllerTest(TurnosWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task GetAll_WhenallTurnosReturned_ReturnsOk()
        {
            // Arrange
            var url = "/api/Turno";
            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<IEnumerable<Turno>>(responseString);
            var count = turnos?.Count();
            
            Assert.NotEmpty(turnos!);
            Assert.Equal(2, count);
        }
        [Fact]
        public async Task GetAll_WhenTurnosLessThanDate_ReturnsOk()
        {
           
            // Arrange
            var date =new DateOnly(2025, 4, 20);
            var param = new TurnosParameters
            {
                FechaHasta = date,
            };
            var url = QueryHelpers.AddQueryString("/api/Turno",nameof(param.FechaHasta), $"{param.FechaHasta.ToString("yyyy-MM-dd")}");
            
            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<IEnumerable<Turno>>(responseString);
            var count = turnos?.Count();

            Assert.NotEmpty(turnos!);
            Assert.Equal(1, count);
        }
        [Fact]
        public async Task GetAll_WhenTurnosLessThanHoraInicio_ReturnsOk()
        {
            //'https://localhost:44334/api/Turno?HoraInicio=12%3A00%3A00' 
            // Arrange
            var hora = new TimeOnly(12,0);
            var param = new TurnosParameters
            {
                HoraInicio = hora,
            };

            var url = QueryHelpers.AddQueryString("/api/Turno", nameof(param.HoraInicio), $"{param.HoraInicio.ToString("hh:mm:ss")}");

            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<IEnumerable<Turno>>(responseString);
            var count = turnos?.Count();

            Assert.NotEmpty(turnos!);
            Assert.Equal(1, count);
        }
        [Fact]
        public async Task GetAll_WhenTurnosEstadoisCompletado_ReturnsOk()
        {
            
            // Arrange
            var estado = "completado";
            var param = new TurnosParameters
            {
                Estado = estado,
            };

            var url = QueryHelpers.AddQueryString("/api/Turno", nameof(param.Estado), $"{param.Estado}");

            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<IEnumerable<Turno>>(responseString);
            var count = turnos?.Count();

            Assert.NotEmpty(turnos!);
            Assert.Equal(1, count);
        }
        [Fact]
        public async Task GetTurnoById_ExistingId_ReturnsTurno()
        {   

            //Arrange
            var Id = new Guid("08bc1990-5e8d-4237-a9e4-8e6b8ba56937");
            // Act
           
            var response = await _client.GetAsync($"/api/Turno/{Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<Turno>(responseString);

            Assert.NotNull(turnos);
            Assert.Equal(Id, turnos.TurnoId);
            
        }

        [Fact]
        public async Task GetTurnoById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"/api/Turno/{nonExistingId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task GetByWeek_WhenThereIsOneTurnoInWeek_ReturnsOk()
        {
            //https://localhost:44334/api/Turno/week
            // Arrange
            var week = "2025-05-06";
            var url = $"/api/Turno/week?={week}";
            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var turnos = JsonConvert.DeserializeObject<IEnumerable<Turno>>(responseString);
            var count = turnos?.Count();
            Assert.NotEmpty(turnos!);
            Assert.Equal(1, count);
        }
    }

}
