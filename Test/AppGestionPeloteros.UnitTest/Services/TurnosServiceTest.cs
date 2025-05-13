using Application.Helper;
using Application.Services.DTOs;
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;
using Application.Services.Implementation;
using Application.Services.Validators.Iterface;
using Dominio.Entities;
using Dominio.Interfaces;
using FluentAssertions;
using FluentValidation;
using MapsterMapper;
using Moq;
public class TurnoServiceTest
{
    private readonly Mock<IRepositoryManager> _mockRepoManager;
    private readonly Mock<ITurnosRepository> _mockTurnoRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IValidator<PagoCreationDto>> _mockPagoValidator;
    private readonly Mock<IValidator<ClienteCreationDto>> _mockClienteValidator;
    private readonly Mock<IValidator<TurnoCreationDto>> _mockTurnoValidator;
    private readonly Mock<IValidationService> _mockValidation;

    private readonly TurnoService _service;

    public TurnoServiceTest()
    {
        _mockRepoManager = new Mock<IRepositoryManager>();
        _mockTurnoRepo = new Mock<ITurnosRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockPagoValidator = new Mock<IValidator<PagoCreationDto>>();
        _mockClienteValidator = new Mock<IValidator<ClienteCreationDto>>();
        _mockTurnoValidator = new Mock<IValidator<TurnoCreationDto>>();
        _mockValidation = new Mock<IValidationService>();

        _mockRepoManager.Setup(r => r.Turno).Returns(_mockTurnoRepo.Object);

        _service = new TurnoService(
            _mockRepoManager.Object,
            _mockMapper.Object,
            _mockPagoValidator.Object,
            _mockClienteValidator.Object,
            _mockTurnoValidator.Object,
            _mockValidation.Object
        );
    }
    [Fact]
    public async Task CreateAsync_ShouldThrowException_WhenTurnoCreationIsNull()
    {
        // Arrange
        var turnoCompleto = new TurnoCompletoDto { Turnocreation = null };

        // Act
        Func<Task> act = async () => await _service.CreateAsync(turnoCompleto);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("Debe insertar los valores del turno y del pago");
    }

    [Fact]
    public async Task GetByWeek_ReturnsMappedTurnos()
    {
        // Arrange
        var inputDate = new DateOnly(2025, 5, 5);
        var startOfWeek = inputDate.GetStartOfTheWeek();

        var mockTurnos = new List<Turno>
        {
            new Turno { TurnoId = Guid.NewGuid(), Fecha = inputDate },
            new Turno { TurnoId = Guid.NewGuid(), Fecha = inputDate.AddDays(1) }
        };

        var mappedTurnos = new List<TurnoDto>
        {
            new TurnoDto { TurnoId = mockTurnos[0].TurnoId },
            new TurnoDto { TurnoId = mockTurnos[1].TurnoId }
        };

        _mockTurnoRepo.Setup(r => r.GetByWeek(startOfWeek))
                      .ReturnsAsync(mockTurnos);

        _mockMapper.Setup(m => m.Map<List<TurnoDto>>(mockTurnos))
                   .Returns(mappedTurnos);

        // Act
        var result = await _service.GetByWeek(inputDate);

        // Assert
        result.Should().HaveCount(2);
        result.First().TurnoId.Should().Be(mockTurnos[0].TurnoId);
    }
}