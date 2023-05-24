namespace RetAnal.Data;

public partial class Store
{
    public int TransactionStoreId { get; set; }

    public int SkuId { get; set; }

    public decimal SkuPurchasePrice { get; set; }

    public decimal SkuRetailPrice { get; set; }

    public virtual Sku Sku { get; set; } = null!;
}
