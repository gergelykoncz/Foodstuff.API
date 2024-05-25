using FoodStuff.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodStuff.Data;

public partial class FoodstuffContext : DbContext
{
    public FoodstuffContext()
    {
    }

    public FoodstuffContext(DbContextOptions<FoodstuffContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandName> BrandNames { get; set; }

    public virtual DbSet<BrandOwner> BrandOwners { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodCategory> FoodCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Foodstuff");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandName>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brand_na__3214EC27B54F785E");

            entity.ToTable("brand_name");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<BrandOwner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brand_ow__3214EC27E4688E04");

            entity.ToTable("brand_owner");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.ToTable("food");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.BrandNameId).HasColumnName("brand_name_id");
            entity.Property(e => e.BrandOwnerId).HasColumnName("brand_owner_id");
            entity.Property(e => e.CalciumAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("calcium_amount");
            entity.Property(e => e.CalciumUnit)
                .HasMaxLength(10)
                .HasColumnName("calcium_unit");
            entity.Property(e => e.CarbAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("carb_amount");
            entity.Property(e => e.CarbUnit)
                .HasMaxLength(10)
                .HasColumnName("carb_unit");
            entity.Property(e => e.CholesterolAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("cholesterol_amount");
            entity.Property(e => e.CholesterolUnit)
                .HasMaxLength(10)
                .HasColumnName("cholesterol_unit");
            entity.Property(e => e.EnergyAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("energy_amount");
            entity.Property(e => e.EnergyUnit)
                .HasMaxLength(10)
                .HasColumnName("energy_unit");
            entity.Property(e => e.FatAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("fat_amount");
            entity.Property(e => e.FatUnit)
                .HasMaxLength(10)
                .HasColumnName("fat_unit");
            entity.Property(e => e.FattyAcidsAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("fatty_acids_amount");
            entity.Property(e => e.FattyAcidsUnit)
                .HasMaxLength(10)
                .HasColumnName("fatty_acids_unit");
            entity.Property(e => e.FdcId).HasColumnName("fdc_id");
            entity.Property(e => e.FiberAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("fiber_amount");
            entity.Property(e => e.FiberUnit)
                .HasMaxLength(10)
                .HasColumnName("fiber_unit");
            entity.Property(e => e.FoodCategoryId).HasColumnName("food_category_id");
            entity.Property(e => e.Ingredients)
                .HasMaxLength(511)
                .HasColumnName("ingredients");
            entity.Property(e => e.IronAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("iron_amount");
            entity.Property(e => e.IronUnit)
                .HasMaxLength(10)
                .HasColumnName("iron_unit");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PotassiumAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("potassium_amount");
            entity.Property(e => e.PotassiumUnit)
                .HasMaxLength(10)
                .HasColumnName("potassium_unit");
            entity.Property(e => e.ProteinAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("protein_amount");
            entity.Property(e => e.ProteinUnit)
                .HasMaxLength(10)
                .HasColumnName("protein_unit");
            entity.Property(e => e.ServingSize)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("serving_size");
            entity.Property(e => e.ServingSizeUnit)
                .HasMaxLength(40)
                .HasColumnName("serving_size_unit");
            entity.Property(e => e.SodiumAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("sodium_amount");
            entity.Property(e => e.SodiumUnit)
                .HasMaxLength(10)
                .HasColumnName("sodium_unit");
            entity.Property(e => e.SugarsAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("sugars_amount");
            entity.Property(e => e.SugarsUnit)
                .HasMaxLength(40)
                .HasColumnName("sugars_unit");
            entity.Property(e => e.UpdateYear).HasColumnName("update_year");
            entity.Property(e => e.VitaminAAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vitamin_a_amount");
            entity.Property(e => e.VitaminAUnit)
                .HasMaxLength(10)
                .HasColumnName("vitamin_a_unit");
            entity.Property(e => e.VitaminCAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("vitamin_c_amount");
            entity.Property(e => e.VitaminCUnit)
                .HasMaxLength(10)
                .HasColumnName("vitamin_c_unit");
            entity.Property(e => e.VitaminDAmount)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("vitamin_d_amount");
            entity.Property(e => e.VitaminDUnit)
                .HasMaxLength(10)
                .HasColumnName("vitamin_d_unit");

            entity.HasOne(d => d.BrandName).WithMany(p => p.Foods)
                .HasForeignKey(d => d.BrandNameId)
                .HasConstraintName("FK_food_brand_name");

            entity.HasOne(d => d.BrandOwner).WithMany(p => p.Foods)
                .HasForeignKey(d => d.BrandOwnerId)
                .HasConstraintName("FK_food_brand_owner");

            entity.HasOne(d => d.FoodCategory).WithMany(p => p.Foods)
                .HasForeignKey(d => d.FoodCategoryId)
                .HasConstraintName("FK_food_food_category");
        });

        modelBuilder.Entity<FoodCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__food_cat__3214EC2758EFC520");

            entity.ToTable("food_category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
