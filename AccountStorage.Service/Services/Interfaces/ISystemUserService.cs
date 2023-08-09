using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface ISystemUserService
    {
        SystemUser? GetSystemUserById(string id);
        Task<SystemUser?> GetSystemUserByIdAsync(string id);
    }
}
