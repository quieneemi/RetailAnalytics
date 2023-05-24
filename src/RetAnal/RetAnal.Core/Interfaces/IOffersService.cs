using RetAnal.Core.Models;

namespace RetAnal.Core.Interfaces;

public interface IOffersService
{
    Task<Table> GetAsync(string offerName, string[] parameters);
}