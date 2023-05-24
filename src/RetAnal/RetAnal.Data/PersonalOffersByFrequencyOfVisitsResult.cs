using System.ComponentModel.DataAnnotations.Schema;

namespace RetAnal.Data;

public class PersonalOffersByFrequencyOfVisitsResult
{
    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("required_transactions_count")]
    public int RequiredTransactionsCount { get; set; }

    [Column("group_name")]
    public string GroupName { get; set; } = null!;

    [Column("offer_discount_depth")]
    public float OfferDiscountDepth { get; set; }
}