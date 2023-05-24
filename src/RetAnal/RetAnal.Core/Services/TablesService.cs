using Microsoft.EntityFrameworkCore;
using RetAnal.Core.Models;
using RetAnal.Core.Interfaces;
using RetAnal.Data;

namespace RetAnal.Core.Services;

public class TablesService : ITablesService
{
    private readonly PostgresContext _dbContext;
    private readonly ILoggerService _logger;

    public TablesService(PostgresContext postgres, ILoggerService logger)
    {
        _dbContext = postgres;
        _logger = logger;
    }

    public async Task<Table> GetTableAsync(string tableName, int pageIndex, int pageSize)
    {
        await _logger.InfoAsync(
            $"GetTableAsync(string tableName, int pageIndex, int pageSize): tableName = {tableName}, pageIndex = {pageIndex}, pageSize = {pageSize}");

        return await _dbContext.GetTableAsync(tableName, pageIndex, pageSize);
    }

    public async Task InsertAsync(string tableName, string[] values)
    {
        await _logger.InfoAsync(
            $"InsertAsync(string tableName, string[] values): tableName = {tableName}, values = {values}");

        if (await _dbContext.InsertToTableAsync(tableName, values))
            await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(string tableName, string[] values)
    {
        await _logger.InfoAsync(
            $"UpdateAsync(string tableName, string[] values): tableName = {tableName}, values = {values}");

        if (_dbContext.UpdateTable(tableName, values))
            await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(string tableName, string[] values)
    {
        await _logger.InfoAsync(
            $"DeleteAsync(string tableName, string[] values): tableName = {tableName}, values = {values}");

        if (_dbContext.DeleteFromTable(tableName, values))
            await _dbContext.SaveChangesAsync();
    }

    public async Task ImportAsync(string tableName, string fileName)
    {
        await _logger.InfoAsync(
            $"ImportAsync(string tableName, string fileName): tableName = {tableName}, fileName = {fileName}");

        var sql = $@"CALL import_table('{fileName}', '{tableName}', ',')";
        await _dbContext.Database.ExecuteSqlRawAsync(sql);
    }
}