using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Services;

public class AdvertService : IAdvertService {
    private readonly CorgiDbContext _context;

    public AdvertService(CorgiDbContext context) {
        _context = context ?? throw new ArgumentNullException();
    }
    
    public Advert? GetAdvertById(int id) {
        return _context.Adverts.Find(id);
    }

    public async Task<Advert?> GetAdvertByIdAsync(int id) {
        return await _context.Adverts.FindAsync(id);
    }

    public IEnumerable<Advert> GetAllAdverts() {
        return _context.Adverts.AsNoTracking();
    }

    public async Task<IEnumerable<Advert>> GetALlAdvertsAsync() {
        throw new NotImplementedException();
    }

    public IEnumerable<Advert> GetAllUserAdverts(int userId) {
        var adverts = _context.Adverts.Where(advert => advert.UserId == userId);

        return adverts;
    }

    public async Task<IEnumerable<Advert>> GetAllUserAdvertsAsync(int userId) {
        throw new NotImplementedException();
    }

    public IEnumerable<Advert> GetAdvertsBasedOnSearch(SearchFilterDto searchFilterDto) {
        var result = _context.Adverts.AsNoTracking();

        if (searchFilterDto.Title is not null) {
            result = result.Where(ad => ad.Title.Contains(searchFilterDto.Title));
        }

        if (searchFilterDto.City is not null) {
            Console.WriteLine("Not implemented");
            // result = result.Where(ad => ad.)
        }

        if (searchFilterDto.IsOnline is not null) {
            Console.WriteLine("Not ideal");
            // result = result.Where(ad => ad.IsOnline == searchFilterDto.IsOnline);
        }

        if (searchFilterDto.CostMin is not null) {
            result = result.Where(ad => ad.Cost >= searchFilterDto.CostMin);
        }

        if (searchFilterDto.CostMax is not null) {
            result = result.Where(ad => ad.Cost <= searchFilterDto.CostMax);
        }

        return result;
    }

    public Task<IEnumerable<Advert>> GetAdvertsBasedOnSearchAsync(SearchFilterDto searchFilterDto) {
        throw new NotImplementedException();
    }

    public bool DeleteAdvert(int id) {
        var advert = _context.Adverts.FirstOrDefault(adv => adv.Id == id);

        if (advert is null) {
            return false;
        }

        _context.Adverts.Remove(advert);
        _context.SaveChanges();

        return true;
    }

    public async Task<bool> DeleteAdvertAsync(int id) {
        throw new NotImplementedException();
    }

    public bool CreateAdvert(Advert advert) {
        if (_context.Adverts.Find(advert.Id) is { } found) {
            return false;
        }

        _context.Adverts.Add(advert);
        _context.SaveChanges();

        return true;
    }

    public Task<bool> CreateAdvertAsync(Advert advert) {
        throw new NotImplementedException();
    }

    public bool UpdateAdvert(Advert advert) {
        if (_context.Adverts.Find(advert.Id) is not { } found) {
            return false;
        }

        _context.Adverts.Update(advert);
        _context.SaveChanges();

        return true;
    }

    public async Task<bool> UpdateAdvertAsync(Advert advert) {
        throw new NotImplementedException();
    }
}