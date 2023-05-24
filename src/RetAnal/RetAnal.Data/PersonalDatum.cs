namespace RetAnal.Data;

public partial class PersonalDatum
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerSurname { get; set; } = null!;

    public string CustomerPrimaryEmail { get; set; } = null!;

    public decimal CustomerPrimaryPhone { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
