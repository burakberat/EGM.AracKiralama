using AutoMapper;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.DAL.Context;
using Infra.DAL.Concretes;

namespace EGM.AracKiralama.DAL.Concretes
{
    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(LogDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
