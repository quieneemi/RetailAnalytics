namespace RetAnal.Data;

public partial class Customer
{
    public int? CustomerId { get; set; }

    public decimal? CustomerAverageCheck { get; set; }

    public string? CustomerAverageCheckSegment { get; set; }

    public decimal? CustomerFrequency { get; set; }

    public string? CustomerFrequencySegment { get; set; }

    public decimal? CustomerInactivePeriod { get; set; }

    public decimal? CustomerChurnRate { get; set; }

    public string? CustomerChurnSegment { get; set; }

    public int? CustomerSegment { get; set; }

    public int? CustomerPrimaryStore { get; set; }
}
