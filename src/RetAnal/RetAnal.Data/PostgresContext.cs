using Microsoft.EntityFrameworkCore;

namespace RetAnal.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext() { }

    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

    public virtual DbSet<Card> Cards { get; set; } = null!;

    public virtual DbSet<Check> Checks { get; set; } = null!;

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    public virtual DbSet<CustomerSegmentation> CustomerSegmentations { get; set; } = null!;

    public virtual DbSet<Group> Groups { get; set; } = null!;

    public virtual DbSet<GroupsSku> GroupsSkus { get; set; } = null!;

    public virtual DbSet<MarginParameter> MarginParameters { get; set; } = null!;

    public virtual DbSet<Period> Periods { get; set; } = null!;

    public virtual DbSet<PersonalDatum> PersonalData { get; set; } = null!;

    public virtual DbSet<PurchaseHistory> PurchaseHistories { get; set; } = null!;

    public virtual DbSet<Sku> Skus { get; set; } = null!;

    public virtual DbSet<Store> Stores { get; set; } = null!;

    public virtual DbSet<Transaction> Transactions { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<PersonalOffersByAverageCheckResult> PersonalOffersByAverageCheck { get; set; } = null!;

    public virtual DbSet<CrossSellingOfferResult> CrossSellingOffer { get; set; } = null!;

    public virtual DbSet<PersonalOffersByFrequencyOfVisitsResult> PersonalOffersByFrequencyOfVisits { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("state", new[] { "Start", "Success", "Failure" });

        modelBuilder.Entity<PersonalOffersByAverageCheckResult>(entity => entity.HasNoKey());

        modelBuilder.Entity<CrossSellingOfferResult>(entity => entity.HasNoKey());

        modelBuilder.Entity<PersonalOffersByFrequencyOfVisitsResult>(entity => entity.HasNoKey());

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CustomerCardId).HasName("cards_pkey");

            entity.ToTable("cards");

            entity.HasIndex(e => new { e.CustomerCardId, e.CustomerId }, "crd_1");

            entity.Property(e => e.CustomerCardId).HasColumnName("customer_card_id");
            entity.Property(e => e.CustomerId)
                .ValueGeneratedOnAdd()
                .HasColumnName("customer_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Cards)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cards_customer_id_fkey");
        });

        modelBuilder.Entity<Check>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("checks");

            entity.HasIndex(e => new { e.TransactionId, e.SkuId }, "ch_1");

            entity.Property(e => e.SkuAmount).HasColumnName("sku_amount");
            entity.Property(e => e.SkuDiscount).HasColumnName("sku_discount");
            entity.Property(e => e.SkuId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sku_id");
            entity.Property(e => e.SkuSumm).HasColumnName("sku_summ");
            entity.Property(e => e.SkuSummPaid).HasColumnName("sku_summ_paid");
            entity.Property(e => e.TransactionId)
                .ValueGeneratedOnAdd()
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Sku).WithMany()
                .HasForeignKey(d => d.SkuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("checks_sku_id_fkey");

            entity.HasOne(d => d.Transaction).WithMany()
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("checks_transaction_id_fkey");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("customers");

            entity.Property(e => e.CustomerAverageCheck).HasColumnName("customer_average_check");
            entity.Property(e => e.CustomerAverageCheckSegment).HasColumnName("customer_average_check_segment");
            entity.Property(e => e.CustomerChurnRate).HasColumnName("customer_churn_rate");
            entity.Property(e => e.CustomerChurnSegment).HasColumnName("customer_churn_segment");
            entity.Property(e => e.CustomerFrequency).HasColumnName("customer_frequency");
            entity.Property(e => e.CustomerFrequencySegment).HasColumnName("customer_frequency_segment");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerInactivePeriod).HasColumnName("customer_inactive_period");
            entity.Property(e => e.CustomerPrimaryStore).HasColumnName("customer_primary_store");
            entity.Property(e => e.CustomerSegment).HasColumnName("customer_segment");
        });

        modelBuilder.Entity<CustomerSegmentation>(entity =>
        {
            entity.HasKey(e => e.SegmentId).HasName("customer_segmentation_pkey");

            entity.ToTable("customer_segmentation");

            entity.Property(e => e.SegmentId)
                .ValueGeneratedNever()
                .HasColumnName("segment_id");
            entity.Property(e => e.AverageCheckSegment)
                .HasColumnType("character varying")
                .HasColumnName("average_check_segment");
            entity.Property(e => e.ChurnSegment)
                .HasColumnType("character varying")
                .HasColumnName("churn_segment");
            entity.Property(e => e.FrequencySegment)
                .HasColumnType("character varying")
                .HasColumnName("frequency_segment");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("groups");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.GroupAffinityIndex).HasColumnName("group_affinity_index");
            entity.Property(e => e.GroupAverageDiscount).HasColumnName("group_average_discount");
            entity.Property(e => e.GroupChurnRate).HasColumnName("group_churn_rate");
            entity.Property(e => e.GroupDiscountShare).HasColumnName("group_discount_share");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupMargin).HasColumnName("group_margin");
            entity.Property(e => e.GroupMinimumDiscount).HasColumnName("group_minimum_discount");
            entity.Property(e => e.GroupStabilityIndex).HasColumnName("group_stability_index");
        });

        modelBuilder.Entity<GroupsSku>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("groups_sku_pkey");

            entity.ToTable("groups_sku");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupName)
                .HasColumnType("character varying")
                .HasColumnName("group_name");
        });

        modelBuilder.Entity<MarginParameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("margin_parameters");

            entity.Property(e => e.MType)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("m_type");
            entity.Property(e => e.Parameter)
                .HasDefaultValueSql("0")
                .HasColumnName("parameter");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("periods");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.FirstGroupPurchaseDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("first_group_purchase_date");
            entity.Property(e => e.GroupFrequency).HasColumnName("group_frequency");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupMinDiscount).HasColumnName("group_min_discount");
            entity.Property(e => e.GroupPurchase).HasColumnName("group_purchase");
            entity.Property(e => e.LastGroupPurchaseDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_group_purchase_date");
        });

        modelBuilder.Entity<PersonalDatum>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("personal_data_pkey");

            entity.ToTable("personal_data");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasColumnType("character varying")
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerPrimaryEmail)
                .HasColumnType("character varying")
                .HasColumnName("customer_primary_email");
            entity.Property(e => e.CustomerPrimaryPhone)
                .HasPrecision(10)
                .HasColumnName("customer_primary_phone");
            entity.Property(e => e.CustomerSurname)
                .HasColumnType("character varying")
                .HasColumnName("customer_surname");
        });

        modelBuilder.Entity<PurchaseHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("purchase_history");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.GroupCost).HasColumnName("group_cost");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.GroupSumm).HasColumnName("group_summ");
            entity.Property(e => e.GroupSummPaid).HasColumnName("group_summ_paid");
            entity.Property(e => e.TransactionDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transaction_datetime");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
        });

        modelBuilder.Entity<Sku>(entity =>
        {
            entity.HasKey(e => e.SkuId).HasName("sku_pkey");

            entity.ToTable("sku");

            entity.HasIndex(e => new { e.SkuId, e.GroupId }, "sku_1");

            entity.Property(e => e.SkuId).HasColumnName("sku_id");
            entity.Property(e => e.GroupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("group_id");
            entity.Property(e => e.SkuName)
                .HasColumnType("character varying")
                .HasColumnName("sku_name");

            entity.HasOne(d => d.Group).WithMany(p => p.Skus)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sku_group_id_fkey");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stores");

            entity.HasIndex(e => new { e.TransactionStoreId, e.SkuId }, "str_1");

            entity.Property(e => e.SkuId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sku_id");
            entity.Property(e => e.SkuPurchasePrice).HasColumnName("sku_purchase_price");
            entity.Property(e => e.SkuRetailPrice).HasColumnName("sku_retail_price");
            entity.Property(e => e.TransactionStoreId)
                .ValueGeneratedOnAdd()
                .HasColumnName("transaction_store_id");

            entity.HasOne(d => d.Sku).WithMany()
                .HasForeignKey(d => d.SkuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stores_sku_id_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.HasIndex(e => new { e.TransactionId, e.CustomerCardId }, "tr_1");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.CustomerCardId)
                .ValueGeneratedOnAdd()
                .HasColumnName("customer_card_id");
            entity.Property(e => e.TransactionDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("transaction_datetime");
            entity.Property(e => e.TransactionStoreId)
                .ValueGeneratedOnAdd()
                .HasColumnName("transaction_store_id");
            entity.Property(e => e.TransactionSumm).HasColumnName("transaction_summ");

            entity.HasOne(d => d.CustomerCard).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CustomerCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactions_customer_card_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying")
                .HasColumnName("user_password");
            entity.Property(e => e.UserRole)
                .HasColumnType("character varying")
                .HasColumnName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
