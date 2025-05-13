
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HorariosDisponiblesRespository : BaseRepository<HorariosDisponibilidad>, IHorariosDisponibilidadRepository
    {
        public HorariosDisponiblesRespository(PeloterosDbContext context)
            : base(context)
        {
        }

        public async Task<bool> HorarioEstaDisponible(string DiadeSemana ,TimeOnly horaInicio , TimeOnly horaFinal )
        {
            var disponible = await _context.HorariosDisponibilidads
                .AsNoTracking()
                .Where(t => t.HoraApertura <= horaInicio && t.HoraCierre >= horaFinal )
                .FirstOrDefaultAsync(x => x.DiaSemana == DiadeSemana);

            if (disponible != null)
                return true;

            return false;
        }
    }
    
}
