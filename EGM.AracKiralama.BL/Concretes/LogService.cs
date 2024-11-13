using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Entities;

namespace EGM.AracKiralama.BL.Concretes
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
    }
}
