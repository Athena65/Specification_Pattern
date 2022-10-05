using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly DataContext _context;

        public DeveloperService(DataContext context)
        {
            _context = context;
        }
        public async Task<Developer> AddDeveloper(Developer newdeveloper)
        {
          
            await _context.Developers.AddAsync(newdeveloper);
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Addresses ON;");
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Developers ON;");
            await _context.SaveChangesAsync();
            return newdeveloper;    
        }

        public async Task<Developer> UpdateDeveloper(Developer developer, int id)
        {
            var updatedDeveloper= await _context.Developers.Where(x => x.Id == id).FirstOrDefaultAsync();
            developer.Name = updatedDeveloper.Name;
            developer.Email = updatedDeveloper.Email;
            developer.Address=updatedDeveloper.Address;
            developer.YearsOfExperience = updatedDeveloper.YearsOfExperience;
            developer.EstimatedIncome = updatedDeveloper.EstimatedIncome;

            await _context.SaveChangesAsync();
            return updatedDeveloper;
        }
    }
}
