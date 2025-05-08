using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class AddService
    {
        private readonly AppDbContext _context;

        public AddService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ad>> GetAllAsync()
        {
            return await _context.Ads.ToListAsync();
        }

        public async Task<Ad?> GetByIdAsync(int id)
        {
            return await _context.Ads.FindAsync(id);
        }

        public async Task AddAsync(Ad ad)
        {
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ad ad)
        {
            _context.Entry(ad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad != null)
            {
                _context.Ads.Remove(ad);
                await _context.SaveChangesAsync();
            }
        }
    }
}
