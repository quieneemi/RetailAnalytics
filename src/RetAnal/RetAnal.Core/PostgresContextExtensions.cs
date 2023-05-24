using RetAnal.Core.Models;
using RetAnal.Data;

namespace RetAnal.Core;

public static class PostgresContextExtensions
{
    public static async Task<Table> GetTableAsync(this PostgresContext dbContext,
        string tableName, int pageIndex = 0, int pageSize = 0)
    {
        return tableName switch
        {
            "cards" => await dbContext.Cards
                .OrderBy(x => x.CustomerCardId)
                .GetAsTableAsync(pageIndex, pageSize),
            "checks" => await dbContext.Checks
                .OrderBy(x => x.TransactionId)
                .GetAsTableAsync(pageIndex, pageSize),
            "groups_sku" => await dbContext.GroupsSkus
                .OrderBy(x => x.GroupId)
                .GetAsTableAsync(pageIndex, pageSize),
            "personal_data" => await dbContext.PersonalData
                .OrderBy(x => x.CustomerId)
                .GetAsTableAsync(pageIndex, pageSize),
            "sku" => await dbContext.Skus
                .OrderBy(x => x.SkuId)
                .GetAsTableAsync(pageIndex, pageSize),
            "stores" => await dbContext.Stores
                .OrderBy(x => x.TransactionStoreId)
                .GetAsTableAsync(pageIndex, pageSize),
            "transactions" => await dbContext.Transactions
                .OrderBy(x => x.TransactionId)
                .GetAsTableAsync(pageIndex, pageSize),
            _ => new Table()
        };
    }

    public static async Task<bool> InsertToTableAsync(this PostgresContext dbContext, string tableName, string[] values)
    {
        return tableName switch
        {
            "cards" => await dbContext.Cards.InsertAsync(values),
            "checks" => await dbContext.Checks.InsertAsync(values),
            "groups_sku" => await dbContext.GroupsSkus.InsertAsync(values),
            "personal_data" => await dbContext.PersonalData.InsertAsync(values),
            "sku" => await dbContext.Skus.InsertAsync(values),
            "stores" => await dbContext.Stores.InsertAsync(values),
            "transactions" => await dbContext.Transactions.InsertAsync(values),
            _ => false
        };
    }

    public static bool UpdateTable(this PostgresContext dbContext, string tableName, string[] values)
    {
        return tableName switch
        {
            "cards" => dbContext.Cards.Update(values),
            "checks" => dbContext.Checks.Update(values),
            "groups_sku" => dbContext.GroupsSkus.Update(values),
            "personal_data" => dbContext.PersonalData.Update(values),
            "sku" => dbContext.Skus.Update(values),
            "stores" => dbContext.Stores.Update(values),
            "transactions" => dbContext.Transactions.Update(values),
            _ => false
        };
    }

    public static bool DeleteFromTable(this PostgresContext dbContext, string tableName, string[] values)
    {
        return tableName switch
        {
            "cards" => dbContext.Cards.Delete(values),
            "checks" => dbContext.Checks.Delete(values),
            "groups_sku" => dbContext.GroupsSkus.Delete(values),
            "personal_data" => dbContext.PersonalData.Delete(values),
            "sku" => dbContext.Skus.Delete(values),
            "stores" => dbContext.Stores.Delete(values),
            "transactions" => dbContext.Transactions.Delete(values),
            _ => false
        };
    }
}