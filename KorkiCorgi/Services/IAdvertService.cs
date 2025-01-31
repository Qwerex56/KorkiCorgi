using KorkiCorgi.DataTransferObjects;
using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

public interface IAdvertService {
    public Advert? GetAdvertById(int id);
    public Task<Advert?> GetAdvertByIdAsync(int id);
    public IEnumerable<Advert> GetAllAdverts();
    public Task<IEnumerable<Advert>> GetALlAdvertsAsync();

    public IEnumerable<Advert> GetAllUserAdverts(int userId);
    public Task<IEnumerable<Advert>> GetAllUserAdvertsAsync(int userId);
    public IEnumerable<Advert> GetAdvertsBasedOnSearch(SearchFilterDto searchFilterDto);
    public Task<IEnumerable<Advert>> GetAdvertsBasedOnSearchAsync(SearchFilterDto searchFilterDto);

    public bool DeleteAdvert(int id);
    public Task<bool> DeleteAdvertAsync(int id);

    public bool CreateAdvert(Advert advert);
    public Task<bool> CreateAdvertAsync(Advert advert);
    
    public bool UpdateAdvert(Advert advert);
    public Task<bool> UpdateAdvertAsync(Advert advert);
}