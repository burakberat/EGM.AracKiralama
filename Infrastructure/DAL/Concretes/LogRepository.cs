using AutoMapper;
using Infra.DAL.Abstracts;
using Infra.DAL.Concretes;
using Infra.DAL.Context;

namespace INfra.DAL.Concretes
{
    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(LogDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
