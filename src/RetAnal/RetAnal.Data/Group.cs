namespace RetAnal.Data;

public partial class Group
{
    public int? CustomerId { get; set; }

    public int? GroupId { get; set; }

    public decimal? GroupAffinityIndex { get; set; }

    public decimal? GroupChurnRate { get; set; }

    public decimal? GroupStabilityIndex { get; set; }

    public decimal? GroupMargin { get; set; }

    public decimal? GroupDiscountShare { get; set; }

    public decimal? GroupMinimumDiscount { get; set; }

    public decimal? GroupAverageDiscount { get; set; }
}
