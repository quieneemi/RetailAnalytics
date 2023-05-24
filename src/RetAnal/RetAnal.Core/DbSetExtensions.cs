using Microsoft.EntityFrameworkCore;
using RetAnal.Core.Models;

namespace RetAnal.Core;

public static class DbSetExtensions
{
    public static async Task<Table> GetAsTableAsync<T>(this IQueryable<T> dbSet,
        int pageIndex = 0, int pageSize = 0) where T : class
    {
        var properties = typeof(T).GetProperties().Where(p => !p.GetMethod!.IsVirtual).ToArray();
        var columns = properties.Select(x => x.Name);
        var table = pageSize > 0 ? dbSet.Skip(pageIndex * pageSize).Take(pageSize) : dbSet;
        var rows = new List<string[]>();
        foreach (var entity in table)
            rows.Add(properties.Select(p => p.GetValue(entity)?.ToString() ?? string.Empty).ToArray());

        return new Table(columns.ToArray(), rows.ToArray(), await dbSet.CountAsync());
    }

    public static async Task<bool> InsertAsync<T>(this DbSet<T> dbSet, string[] values) where T : class
    {
        await dbSet.AddAsync(FillTableData<T>(values));
        return true;
    }

    public static bool Update<T>(this DbSet<T> dbSet, string[] values) where T : class
    {
        dbSet.Update(FillTableData<T>(values));
        return true;
    }

    public static bool Delete<T>(this DbSet<T> dbSet, string[] values) where T : class
    {
        dbSet.Remove(FillTableData<T>(values));
        return true;
    }

    private static T FillTableData<T>(IReadOnlyList<string> values) where T : class
    {
        var type = typeof(T);
        var instance = (T)Activator.CreateInstance(type)!;
        var properties = type.GetProperties().Where(p => !p.GetMethod!.IsVirtual).ToArray();
        for (var i = 0; i < properties.Length; ++i)
        {
            properties[i].SetValue(instance, Convert.ChangeType(values[i], properties[i].PropertyType));
        }
        return instance;
    }
}