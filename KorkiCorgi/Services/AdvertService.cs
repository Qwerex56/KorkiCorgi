using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

public class AdvertService : IAdvertService {
    private readonly CorgiDbContext _context;

    public AdvertService(CorgiDbContext context) {
        _context = context ?? throw new ArgumentNullException();
    }
    
    public Advert? GetAdvertById(int id) {
        if (_context.Adverts.Find(id) is not { } advert) {
            return null;
        }

        return advert;
    }

    public async Task<Advert?> GetAdvertByIdAsync(int id) {
        if (await _context.Adverts.FindAsync(id) is not { } advert) {
            return null;
        }

        return advert;
    }

    public IEnumerable<Advert> GetAllUserAdverts(int userId) {
        var adverts = _context.Adverts.Where(advert => advert.UserId == userId);

        return adverts;
    }

    public async Task<IEnumerable<Advert>> GetAllUserAdvertsAsync(int userId) {
        throw new NotImplementedException();
    }

    public bool DeleteAdvert(int id) {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAdvertAsync(int id) {
        throw new NotImplementedException();
    }

    public bool UpdateAdvert(Advert advert) {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAdvertAsync(Advert advert) {
        throw new NotImplementedException();
    }
}