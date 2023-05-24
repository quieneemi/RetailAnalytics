namespace RetAnal.Data;

public partial class Period
{
    public int? CustomerId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? FirstGroupPurchaseDate { get; set; }

    public DateTime? LastGroupPurchaseDate { get; set; }

    public long? GroupPurchase { get; set; }

    public decimal? GroupFrequency { get; set; }

    public decimal? GroupMinDiscount { get; set; }
}
