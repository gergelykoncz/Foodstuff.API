using System;
using System.Collections.Generic;

namespace FoodStuff.Data.Entities;

public partial class Food
{
    public int Id { get; set; }

    public int? FdcId { get; set; }

    public string? Name { get; set; }

    public int? BrandNameId { get; set; }

    public int? BrandOwnerId { get; set; }

    public int? FoodCategoryId { get; set; }

    public string? Ingredients { get; set; }

    public decimal? ServingSize { get; set; }

    public string? ServingSizeUnit { get; set; }

    public short? UpdateYear { get; set; }

    public decimal? SugarsAmount { get; set; }

    public string? SugarsUnit { get; set; }

    public decimal? FattyAcidsAmount { get; set; }

    public string? FattyAcidsUnit { get; set; }

    public decimal? CholesterolAmount { get; set; }

    public string? CholesterolUnit { get; set; }

    public decimal? VitaminCAmount { get; set; }

    public string? VitaminCUnit { get; set; }

    public decimal? VitaminDAmount { get; set; }

    public string? VitaminDUnit { get; set; }

    public decimal? VitaminAAmount { get; set; }

    public string? VitaminAUnit { get; set; }

    public decimal? SodiumAmount { get; set; }

    public string? SodiumUnit { get; set; }

    public decimal? PotassiumAmount { get; set; }

    public string? PotassiumUnit { get; set; }

    public decimal? IronAmount { get; set; }

    public string? IronUnit { get; set; }

    public decimal? CalciumAmount { get; set; }

    public string? CalciumUnit { get; set; }

    public decimal? FiberAmount { get; set; }

    public string? FiberUnit { get; set; }

    public decimal? EnergyAmount { get; set; }

    public string? EnergyUnit { get; set; }

    public decimal? CarbAmount { get; set; }

    public string? CarbUnit { get; set; }

    public decimal? FatAmount { get; set; }

    public string? FatUnit { get; set; }

    public decimal? ProteinAmount { get; set; }

    public string? ProteinUnit { get; set; }

    public virtual BrandName? BrandName { get; set; }

    public virtual BrandOwner? BrandOwner { get; set; }

    public virtual FoodCategory? FoodCategory { get; set; }
}
