using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

public interface IAdvertService {
    public Advert? GetAdvertById(int id);
    public Task<Advert?> GetAdvertByIdAsync(int id);

    public IEnumerable<Advert> GetAllUserAdverts(int userId);
    public Task<IEnumerable<Advert>> GetAllUserAdvertsAsync(int userId);

    public bool DeleteAdvert(int id);
    public Task<bool> DeleteAdvertAsync(int id);

    public bool UpdateAdvert(Advert advert);
    public Task<bool> UpdateAdvertAsync(Advert advert);
}