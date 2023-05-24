namespace RetAnal.Data;

public partial class Card
{
    public int CustomerCardId { get; set; }

    public int CustomerId { get; set; }

    public virtual PersonalDatum Customer { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
