using System.Text;
using Microsoft.EntityFrameworkCore;
using RetAnal.Core.Models;
using RetAnal.Core.Interfaces;
using RetAnal.Data;

namespace RetAnal.Core.Services;

public class OffersService : IOffersService
{
    private readonly PostgresContext _dbContext;
    private readonly ILoggerService _logger;

    public OffersService(PostgresContext postgres, ILoggerService logger)
    {
        _dbContext = postgres;
        _logger = logger;
    }

    public async Task<Table> GetAsync(string offerName, string[] parameters)
    {
        await _logger.InfoAsync($"Get(string offerName, string[] parameters): offerName = {offerName}, parameters = {parameters}");

        var sb = new StringBuilder();
        for (var i = 0; i < parameters.Length; i++)
        {
            if (i != parameters.Length - 1)
                sb.Append($@"'{parameters[i]}', ");
            else
                sb.Append($@"'{parameters[i]}'");
        }

        return offerName switch
        {
            "cross_selling_offer" => await GetCrossSellingOfferAsync(sb.ToString()),
            "personal_offers_by_average_check" => await GetPersonalOffersByAverageCheckAsync(sb.ToString()),
            "personal_offers_by_frequency_of_visits" => await GetPersonalOffersByFrequencyOfVisitsAsync(sb.ToString()),
            _ => new Table()
        };
    }

    private async Task<Table> GetCrossSellingOfferAsync(string parameters)
    {
        await _logger.InfoAsync($"GetCrossSellingOffer(string parameters): parameters = {parameters}");

        var columns = typeof(CrossSellingOfferResult)
            .GetProperties()
            .Select(x => x.Name);
        var rows = _dbContext.CrossSellingOffer
            .FromSqlRaw($"SELECT * FROM cross_selling_offer({parameters})")
            .Select(x => new[] { x.CustomerId.ToString(), x.SkuName, x.OfferDiscountDepth.ToString() });

        return new Table(columns.ToArray(), rows.ToArray());
    }

    private async Task<Table> GetPersonalOffersByAverageCheckAsync(string parameters)
    {
        await _logger.InfoAsync($"GetPersonalOffersByAverageCheck(string parameters): parameters = {parameters}");

        var columns = typeof(PersonalOffersByAverageCheckResult)
            .GetProperties()
            .Select(x => x.Name);
        var rows = _dbContext.PersonalOffersByAverageCheck
            .FromSqlRaw($"SELECT * FROM personal_offers_by_average_check({parameters})")
            .Select(x => new[]
            {
                x.CustomerId.ToString(),
                x.RequiredCheckMeasure.ToString("F"),
                x.GroupName,
                x.OfferDiscountDepth.ToString("F")
            });

        return new Table(columns.ToArray(), rows.ToArray());
    }

    private async Task<Table> GetPersonalOffersByFrequencyOfVisitsAsync(string parameters)
    {
        await _logger.InfoAsync($"GetPersonalOffersByFrequencyOfVisits(string parameters): parameters = {parameters}");

        var columns = typeof(PersonalOffersByFrequencyOfVisitsResult)
            .GetProperties()
            .Select(x => x.Name);
        var rows = _dbContext.PersonalOffersByFrequencyOfVisits
            .FromSqlRaw($"SELECT * FROM personal_offers_by_frequency_of_visits({parameters})")
            .Select(x => new[]
            {
                x.CustomerId.ToString(),
                x.StartDate.ToString("d"),
                x.EndDate.ToString("d"),
                x.RequiredTransactionsCount.ToString(),
                x.GroupName,
                x.OfferDiscountDepth.ToString("F")
            });

        return new Table(columns.ToArray(), rows.ToArray());
    }
}