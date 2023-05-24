namespace RetAnal.Data;

public partial class GroupsSku
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Sku> Skus { get; set; } = new List<Sku>();
}
