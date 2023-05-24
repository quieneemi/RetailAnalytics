namespace RetAnal.Data;

public partial class CustomerSegmentation
{
    public int SegmentId { get; set; }

    public string AverageCheckSegment { get; set; } = null!;

    public string FrequencySegment { get; set; } = null!;

    public string ChurnSegment { get; set; } = null!;
}
