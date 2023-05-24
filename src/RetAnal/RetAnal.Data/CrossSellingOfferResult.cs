using System.ComponentModel.DataAnnotations.Schema;

namespace RetAnal.Data;

public class CrossSellingOfferResult
{
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("sku_name")]
    public string SkuName { get; set; } = null!;

    [Column("offer_discount_depth")]
    public int OfferDiscountDepth { get; set; }
}