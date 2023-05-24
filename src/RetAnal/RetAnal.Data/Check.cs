namespace RetAnal.Data;

public partial class Check
{
    public int TransactionId { get; set; }

    public int SkuId { get; set; }

    public decimal SkuAmount { get; set; }

    public decimal SkuSumm { get; set; }

    public decimal SkuSummPaid { get; set; }

    public decimal SkuDiscount { get; set; }

    public virtual Sku Sku { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
