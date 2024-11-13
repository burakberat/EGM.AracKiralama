using EGM.AracKiralama.Model.Entities;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface ILogService
    {
        Task AddLogAsync(LogTable log);
    }
}
