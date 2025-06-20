﻿
using Application.Services.DTOs.Cliente;
using Application.Services.DTOs.Pago;
using Application.Services.DTOs.Turno;
using Application.Services.Implementation;
using Application.Services.Validators.Iterface;
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

       
        var mockTurnoUpdateValidator = new Mock<IValidator<TurnoUpdateDto>>();

        _mockRepoManager.Setup(r => r.Turno).Returns(_mockTurnoRepo.Object);

        _service = new TurnoService(
            _mockRepoManager.Object,
            _mockMapper.Object,
            _mockPagoValidator.Object,
            _mockClienteValidator.Object,
            _mockTurnoValidator.Object,
            mockTurnoUpdateValidator.Object, 
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

}