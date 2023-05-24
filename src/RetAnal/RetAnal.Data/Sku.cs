namespace RetAnal.Data;

public partial class Sku
{
    public int SkuId { get; set; }

    public string SkuName { get; set; } = null!;

    public int GroupId { get; set; }

    public virtual GroupsSku Group { get; set; } = null!;
}
