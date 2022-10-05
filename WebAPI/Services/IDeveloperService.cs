using Core.Models;

namespace WebAPI.Services
{
    public interface IDeveloperService
    {
        public Task<Developer> AddDeveloper(Developer newdeveloper);
        public Task<Developer> UpdateDeveloper(Developer developer,int id);
    }
}
