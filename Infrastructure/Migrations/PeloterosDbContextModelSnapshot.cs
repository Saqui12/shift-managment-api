﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PeloterosDbContext))]
    partial class PeloterosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entities.Bloqueo", b =>
                {
                    b.Property<Guid>("BloqueoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Motivo")
                        .HasColumnType("text");

                    b.Property<Guid>("RecursoId")
                        .HasColumnType("uuid");

                    b.HasKey("BloqueoId");

                    b.HasIndex("RecursoId");

                    b.ToTable("Bloqueos");
                });

            modelBuilder.Entity("Dominio.Entities.Cliente", b =>
                {
                    b.Property<Guid>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool?>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("FechaRegistro")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = new Guid("04bc1990-5e8d-4237-a9e4-8e5b8ba56237"),
                            Activo = true,
                            Apellido = "Pérez",
                            Email = "juanperez@gmail.com",
                            FechaRegistro = new DateOnly(2025, 5, 10),
                            Nombre = "Juan",
                            Telefono = "123456789"
                        },
                        new
                        {
                            ClienteId = new Guid("07bc1770-5e8d-4237-a9e4-8e6b8ba56237"),
                            Activo = true,
                            Apellido = "Gómez",
                            Email = "maria@gmail.com",
                            FechaRegistro = new DateOnly(2025, 5, 1),
                            Nombre = "María",
                            Telefono = "987654321"
                        },
                        new
                        {
                            ClienteId = new Guid("04bc1990-5e8d-4237-a9e4-6e6b8ba76237"),
                            Activo = true,
                            Apellido = "López",
                            Email = "pedro@gmail.com",
                            FechaRegistro = new DateOnly(2025, 5, 3),
                            Nombre = "Pedro",
                            Telefono = "456789123"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.HorariosDisponibilidad", b =>
                {
                    b.Property<Guid>("HorariosDisponibilidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DiaSemana")
                        .HasColumnType("text");

                    b.Property<TimeOnly>("HoraApertura")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("HoraCierre")
                        .HasColumnType("time without time zone");

                    b.Property<Guid>("RecursoId")
                        .HasColumnType("uuid");

                    b.HasKey("HorariosDisponibilidadId");

                    b.HasIndex("RecursoId");

                    b.ToTable("HorariosDisponibilidads");

                    b.HasData(
                        new
                        {
                            HorariosDisponibilidadId = new Guid("07bc1990-5e8d-4237-a9e4-4e6b5ba36537"),
                            DiaSemana = "Monday",
                            HoraApertura = new TimeOnly(8, 0, 0),
                            HoraCierre = new TimeOnly(20, 0, 0),
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537")
                        },
                        new
                        {
                            HorariosDisponibilidadId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56739"),
                            DiaSemana = "Tuesday",
                            HoraApertura = new TimeOnly(8, 0, 0),
                            HoraCierre = new TimeOnly(20, 0, 0),
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537")
                        },
                        new
                        {
                            HorariosDisponibilidadId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba51237"),
                            DiaSemana = "Wednesday",
                            HoraApertura = new TimeOnly(8, 0, 0),
                            HoraCierre = new TimeOnly(20, 0, 0),
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537")
                        },
                        new
                        {
                            HorariosDisponibilidadId = new Guid("07bc1990-5e8d-5237-a3e4-8e6b8ba56537"),
                            DiaSemana = "Thursday",
                            HoraApertura = new TimeOnly(8, 0, 0),
                            HoraCierre = new TimeOnly(20, 0, 0),
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537")
                        },
                        new
                        {
                            HorariosDisponibilidadId = new Guid("03bc1990-5e8d-4237-a9e4-2e6b8ba56537"),
                            DiaSemana = "Friday",
                            HoraApertura = new TimeOnly(8, 0, 0),
                            HoraCierre = new TimeOnly(20, 0, 0),
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537")
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "07bc1990-5e8d-4237-a9e4-8e6b8ba56237",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "892bd384-4698-42a8-90e0-2a359e6af3bd",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FullName = "Admin1234!",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAiIJOcSduEzjc8bubbyi0gF/7rAz4yYE1sLol2XzqD3Jd/VsmhserCkL44tZExtcA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e2b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "078a1ad8e-302a-4e75-a156-f997bb40d131",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "462bd384-4698-42a8-90e0-2a359e6af3bd",
                            Email = "employee@gmail.com",
                            EmailConfirmed = false,
                            FullName = "Employee1234!",
                            LockoutEnabled = false,
                            NormalizedEmail = "EMPLOYEE@GMAIL.COM",
                            NormalizedUserName = "EMPLOYEE@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEPhdcQnNXI8EKVZakKNmRPedmr+sBV1yxeBAeSOAqEvtujsYAgMTQ7Sq2/aZ36mqQg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e0b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                            TwoFactorEnabled = false,
                            UserName = "employee@gmail.com"
                        },
                        new
                        {
                            Id = "079a1rd8e-302a-4e75-a156-f997bb40d131",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "162bd384-4698-42a8-90e0-2a359e6af3bd",
                            Email = "user@gmail.com",
                            EmailConfirmed = false,
                            FullName = "User1234!",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@GMAIL.COM",
                            NormalizedUserName = "USER@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEN6erUfNGTWPzpDB0rcvN8mAsr+Oed4PWckqlJPCRUNizdj58HRYN8B9HF9Xc3rSiQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e7b5ce7a-c6a1-4c1c-8f9e-2f9212ee73bc",
                            TwoFactorEnabled = false,
                            UserName = "user@gmail.com"
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("Dominio.Entities.Pago", b =>
                {
                    b.Property<Guid>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaPago")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Monto")
                        .HasColumnType("numeric");

                    b.Property<string>("TransaccionId")
                        .HasColumnType("text");

                    b.Property<Guid>("TurnoId")
                        .HasColumnType("uuid");

                    b.HasKey("PagoId");

                    b.HasIndex("TurnoId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Dominio.Entities.Recurso", b =>
                {
                    b.Property<Guid>("RecursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<int?>("Capacidad")
                        .HasColumnType("integer");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PrecioHora")
                        .HasColumnType("numeric");

                    b.HasKey("RecursoId");

                    b.ToTable("Recursos");

                    b.HasData(
                        new
                        {
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba56537"),
                            Activo = true,
                            Capacidad = 80,
                            Descripcion = "Descripcion del recurso 1",
                            Nombre = "Jungla",
                            PrecioHora = 8000m
                        },
                        new
                        {
                            RecursoId = new Guid("07bc1990-5e8d-4237-a9e4-8e6b8ba88237"),
                            Activo = true,
                            Capacidad = 60,
                            Descripcion = "Descripcion del recurso 2",
                            Nombre = "Jump",
                            PrecioHora = 10000m
                        });
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Property<Guid>("TurnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time without time zone");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("Notas")
                        .HasColumnType("text");

                    b.Property<Guid>("RecursoId")
                        .HasColumnType("uuid");

                    b.HasKey("TurnoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("RecursoId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "07bc1340-5e8d-4237-a9e4-8e6b8ba56237",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "078a1ad8e-302a-4e75-a156-f997bb40d131",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = "596fd05b-7d8c-4c8d-aef1-c50dae89977a",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "07bc1990-5e8d-4237-a9e4-8e6b8ba56237",
                            RoleId = "07bc1340-5e8d-4237-a9e4-8e6b8ba56237"
                        },
                        new
                        {
                            UserId = "078a1ad8e-302a-4e75-a156-f997bb40d131",
                            RoleId = "078a1ad8e-302a-4e75-a156-f997bb40d131"
                        },
                        new
                        {
                            UserId = "079a1rd8e-302a-4e75-a156-f997bb40d131",
                            RoleId = "596fd05b-7d8c-4c8d-aef1-c50dae89977a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Bloqueo", b =>
                {
                    b.HasOne("Dominio.Entities.Recurso", "Recurso")
                        .WithMany("Bloqueos")
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("Dominio.Entities.HorariosDisponibilidad", b =>
                {
                    b.HasOne("Dominio.Entities.Recurso", "Recurso")
                        .WithMany("HorariosDisponibilidad")
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("Dominio.Entities.Pago", b =>
                {
                    b.HasOne("Dominio.Entities.Turno", "Turno")
                        .WithMany("Pagos")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.HasOne("Dominio.Entities.Cliente", "Cliente")
                        .WithMany("Turnos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Recurso", "Recurso")
                        .WithMany("Turnos")
                        .HasForeignKey("RecursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dominio.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dominio.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dominio.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entities.Cliente", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Dominio.Entities.Recurso", b =>
                {
                    b.Navigation("Bloqueos");

                    b.Navigation("HorariosDisponibilidad");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Dominio.Entities.Turno", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
