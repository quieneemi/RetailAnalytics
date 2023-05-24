using System.ComponentModel.DataAnnotations.Schema;

namespace RetAnal.Data;

public class PersonalOffersByAverageCheckResult
{
    [Column("customer_id_")]
    public int CustomerId { get; set; }

    [Column("required_check_measure")]
    public double RequiredCheckMeasure { get; set; }

    [Column("group_name")]
    public string GroupName { get; set; } = null!;

    [Column("offer_discount_depth")]
    public double OfferDiscountDepth { get; set; }
}