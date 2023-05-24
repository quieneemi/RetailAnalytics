namespace RetAnal.Data;

public partial class PurchaseHistory
{
    public int? CustomerId { get; set; }

    public int? TransactionId { get; set; }

    public DateTime? TransactionDatetime { get; set; }

    public int? GroupId { get; set; }

    public decimal? GroupCost { get; set; }

    public decimal? GroupSumm { get; set; }

    public decimal? GroupSummPaid { get; set; }
}
