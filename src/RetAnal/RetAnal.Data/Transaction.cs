namespace RetAnal.Data;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int CustomerCardId { get; set; }

    public decimal TransactionSumm { get; set; }

    public DateTime TransactionDatetime { get; set; }

    public int TransactionStoreId { get; set; }

    public virtual Card CustomerCard { get; set; } = null!;
}
