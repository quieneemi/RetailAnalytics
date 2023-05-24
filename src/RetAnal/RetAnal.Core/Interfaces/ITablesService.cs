using RetAnal.Core.Models;

namespace RetAnal.Core.Interfaces;

public interface ITablesService
{
    Task<Table> GetTableAsync(string tableName, int pageIndex, int pageSize);
    Task InsertAsync(string tableName, string[] values);
    Task UpdateAsync(string tableName, string[] values);
    Task DeleteAsync(string tableName, string[] values);
    Task ImportAsync(string tableName, string fileName);
}