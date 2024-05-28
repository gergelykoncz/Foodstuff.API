﻿// <auto-generated />
using System;
using FoodStuff.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FoodStuff.Data.Migrations
{
    [DbContext(typeof(FoodstuffContext))]
    partial class FoodstuffContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FoodStuff.Data.Entities.BrandName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id")
                        .HasName("PK__brand_na__3214EC27B54F785E");

                    b.ToTable("brand_name", (string)null);
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.BrandOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id")
                        .HasName("PK__brand_ow__3214EC27E4688E04");

                    b.ToTable("brand_owner", (string)null);
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    b.Property<int?>("BrandNameId")
                        .HasColumnType("integer")
                        .HasColumnName("brand_name_id");

                    b.Property<int?>("BrandOwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("brand_owner_id");

                    b.Property<decimal?>("CalciumAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("calcium_amount");

                    b.Property<string>("CalciumUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("calcium_unit");

                    b.Property<decimal?>("CarbAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("carb_amount");

                    b.Property<string>("CarbUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("carb_unit");

                    b.Property<decimal?>("CholesterolAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("cholesterol_amount");

                    b.Property<string>("CholesterolUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("cholesterol_unit");

                    b.Property<decimal?>("EnergyAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("energy_amount");

                    b.Property<string>("EnergyUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("energy_unit");

                    b.Property<decimal?>("FatAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("fat_amount");

                    b.Property<string>("FatUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fat_unit");

                    b.Property<decimal?>("FattyAcidsAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("fatty_acids_amount");

                    b.Property<string>("FattyAcidsUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fatty_acids_unit");

                    b.Property<int?>("FdcId")
                        .HasColumnType("integer")
                        .HasColumnName("fdc_id");

                    b.Property<decimal?>("FiberAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("fiber_amount");

                    b.Property<string>("FiberUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("fiber_unit");

                    b.Property<int?>("FoodCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("food_category_id");

                    b.Property<string>("Ingredients")
                        .HasMaxLength(511)
                        .HasColumnType("character varying(511)")
                        .HasColumnName("ingredients");

                    b.Property<decimal?>("IronAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("iron_amount");

                    b.Property<string>("IronUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("iron_unit");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name");

                    b.Property<decimal?>("PotassiumAmount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("potassium_amount");

                    b.Property<string>("PotassiumUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("potassium_unit");

                    b.Property<decimal?>("ProteinAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("protein_amount");

                    b.Property<string>("ProteinUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("protein_unit");

                    b.Property<decimal?>("ServingSize")
                        .HasColumnType("decimal(12, 2)")
                        .HasColumnName("serving_size");

                    b.Property<string>("ServingSizeUnit")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("serving_size_unit");

                    b.Property<decimal?>("SodiumAmount")
                        .HasColumnType("decimal(12, 2)")
                        .HasColumnName("sodium_amount");

                    b.Property<string>("SodiumUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("sodium_unit");

                    b.Property<decimal?>("SugarsAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("sugars_amount");

                    b.Property<string>("SugarsUnit")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("sugars_unit");

                    b.Property<short?>("UpdateYear")
                        .HasColumnType("smallint")
                        .HasColumnName("update_year");

                    b.Property<decimal?>("VitaminAAmount")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("vitamin_a_amount");

                    b.Property<string>("VitaminAUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vitamin_a_unit");

                    b.Property<decimal?>("VitaminCAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("vitamin_c_amount");

                    b.Property<string>("VitaminCUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vitamin_c_unit");

                    b.Property<decimal?>("VitaminDAmount")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("vitamin_d_amount");

                    b.Property<string>("VitaminDUnit")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("vitamin_d_unit");

                    b.HasKey("Id");

                    b.HasIndex("BrandNameId");

                    b.HasIndex("BrandOwnerId");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("food", (string)null);
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id")
                        .HasName("PK__food_cat__3214EC2758EFC520");

                    b.ToTable("food_category", (string)null);
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.Food", b =>
                {
                    b.HasOne("FoodStuff.Data.Entities.BrandName", "BrandName")
                        .WithMany("Foods")
                        .HasForeignKey("BrandNameId")
                        .HasConstraintName("FK_food_brand_name");

                    b.HasOne("FoodStuff.Data.Entities.BrandOwner", "BrandOwner")
                        .WithMany("Foods")
                        .HasForeignKey("BrandOwnerId")
                        .HasConstraintName("FK_food_brand_owner");

                    b.HasOne("FoodStuff.Data.Entities.FoodCategory", "FoodCategory")
                        .WithMany("Foods")
                        .HasForeignKey("FoodCategoryId")
                        .HasConstraintName("FK_food_food_category");

                    b.Navigation("BrandName");

                    b.Navigation("BrandOwner");

                    b.Navigation("FoodCategory");
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.BrandName", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.BrandOwner", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("FoodStuff.Data.Entities.FoodCategory", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
