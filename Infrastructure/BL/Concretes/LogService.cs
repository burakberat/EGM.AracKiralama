using Infra.BL.Abstracts;
using Infra.DAL.Abstracts;
using Infra.Model.Entities;

namespace Infra.BL.Concretes
{
    public class LogService : ILogService
    {
        ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddLogAsync(LogTable log)
        {
            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();
        }
        public async Task AddErrorLogAsync(ErrorLogTable log)
        {
            await _logRepository.AddAsync(log);
            await _logRepository.SaveChangesAsync();
        }
    }
}
