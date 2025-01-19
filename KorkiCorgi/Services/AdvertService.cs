using KorkiCorgi.Models;

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
        var adverts = _context.Adverts.Where(adverts => true);
        
        return adverts;
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