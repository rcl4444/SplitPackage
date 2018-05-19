﻿// <auto-generated />
using Abp.Authorization;
using Abp.BackgroundJobs;
using Abp.Events.Bus.Entities;
using Abp.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SplitPackage.Business;
using SplitPackage.EntityFrameworkCore;
using System;

namespace SplitPackage.Migrations
{
    [DbContext(typeof(SplitPackageDbContext))]
    [Migration("20180413020024_convert")]
    partial class convert
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity<Logistic>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.CorporationName).IsRequired().HasMaxLength(Logistic.MaxCorporationNameLength);
                b.Property(p => p.CorporationUrl).HasMaxLength(Logistic.MaxCorporationUrlLength);
                b.Property(p => p.LogisticCode).IsRequired().HasMaxLength(Logistic.MaxLogisticCodeLength);
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.HasKey(p => p.Id);
                b.HasIndex(o => o.LogisticCode).IsUnique();
                b.ToTable("Logistics");
            });

            modelBuilder.Entity<LogisticChannel>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.ChannelName).IsRequired().HasMaxLength(LogisticChannel.MaxChannelNameLength);
                b.Property(p => p.AliasName).HasMaxLength(LogisticChannel.MaxAliasNameLength);
                b.Property(p => p.Type).IsRequired();
                b.Property(p => p.Way).IsRequired();
                b.Property(p => p.IsActive);
                b.Property(p => p.LogisticId).IsRequired();
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.Property(p => p.TenantId);
                b.HasKey(p => p.Id);
                b.HasIndex(o => new { o.LogisticId}).IsUnique();
                b.ToTable("LogisticChannels");
                b.HasOne(p => p.LogisticBy).WithMany(p => p.LogisticChannels).HasForeignKey(p => p.LogisticId);
            });

            modelBuilder.Entity<NumFreight>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.LogisticChannelId).IsRequired();
                b.Property(p => p.Currency).HasMaxLength(CommonConstraintConst.MaxCurrencyLength);
                b.Property(p => p.Unit).HasMaxLength(CommonConstraintConst.MaxUnitLength);
                b.Property(p => p.SplitNum);
                b.Property(p => p.FirstPrice);
                b.Property(p => p.CarryOnPrice);
                b.Property(p => p.IsActive);
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.HasKey(p => p.Id);
                b.ToTable("NumFreights");
                b.HasOne(p => p.LogisticChannelBy).WithMany(p => p.NumFreights).HasForeignKey(p => p.LogisticChannelId);
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.CreationTime);
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.Property(p => p.TenantId);
                b.Property(p => p.ProductName).IsRequired().HasMaxLength(Product.MaxProductNameLength);
                b.Property(p => p.Sku).IsRequired().HasMaxLength(Product.MaxSkuLength);
                b.Property(p => p.Brand).HasMaxLength(Product.MaxBrandLength);
                b.Property(p => p.Weight).HasDefaultValue(Product.DefaultWeightValue);
                b.Property(p => p.DeclarePrice).HasDefaultValue(Product.DefaultDeclarePriceValue);
                b.Property(p => p.DeclareTaxrate).HasDefaultValue(Product.DefaultDeclareTaxrateValue);
                b.HasKey(p => p.Id);
                b.HasIndex(p => new { p.TenantId, p.Sku }).IsUnique();
                b.ToTable("Products");
            });

            modelBuilder.Entity<SplitRule>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.LogisticChannelId).IsRequired();
                b.Property(p => p.MaxPackage);
                b.Property(p => p.MaxWeight);
                b.Property(p => p.MaxTax);
                b.Property(p => p.MaxPrice);
                b.Property(p => p.IsActive);
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.Property(p => p.TenantId);
                b.HasKey(p => p.Id);
                b.ToTable("SplitRules");
                b.HasOne(p => p.LogisticChannelBy).WithMany(p => p.SplitRules).HasForeignKey(p => p.LogisticChannelId);
            });

            modelBuilder.Entity<SplitRuleProductClass>(b =>
            {
                b.Property(p => p.SplitRuleId).IsRequired();
                b.Property(p => p.PTId).IsRequired();
                b.Property(p => p.MaxNum);
                b.Property(p => p.MinNum);
                b.HasKey(p => p.Id);
                b.ToTable("SplitRule_ProductClass");
                b.HasOne(pt => pt.SplitRuleBy)
                    .WithMany(p => p.ProductClasses)
                    .HasForeignKey(pt => pt.SplitRuleId);
            });

            modelBuilder.Entity<WeightFreight>(b =>
            {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.LogisticChannelId).IsRequired();
                b.Property(p => p.Currency).HasMaxLength(CommonConstraintConst.MaxCurrencyLength);
                b.Property(p => p.Unit).HasMaxLength(CommonConstraintConst.MaxUnitLength);
                b.Property(p => p.StartingWeight);
                b.Property(p => p.EndWeight);
                b.Property(p => p.StartingPrice);
                b.Property(p => p.StepWeight);
                b.Property(p => p.Price);
                b.Property(p => p.CostPrice);
                b.Property(p => p.IsActive);
                b.Property(p => p.CreatorUserId);
                b.Property(p => p.DeleterUserId);
                b.Property(p => p.DeletionTime);
                b.Property(p => p.IsActive);
                b.Property(p => p.IsDeleted);
                b.Property(p => p.LastModificationTime);
                b.Property(p => p.LastModifierUserId);
                b.HasKey(p => p.Id);
                b.ToTable("WeightFreights");
                b.HasOne(p => p.LogisticChannelBy).WithMany(p => p.WeightFreights).HasForeignKey(p => p.LogisticChannelId);
            });

            modelBuilder.Entity<TenantLogisticChannel>(b=> {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.TenantId).IsRequired();
                b.Property(p => p.LogisticChannelId).IsRequired();
                b.Property(p => p.LogisticChannelChange);
                b.Property(p => p.AliasName);
                b.Property(p => p.Way);
                b.HasKey(p => p.Id);
                b.ToTable("Tenant_LogisticChannel");
                b.HasOne(p => p.TenantBy).WithMany().HasForeignKey(p => p.TenantId);
                b.HasOne(p => p.LogisticChannelBy).WithMany().HasForeignKey(p => p.LogisticChannelId);
            });

            modelBuilder.Entity<LogisticRelated>(b => {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.TenantId);
                b.Property(p => p.RelatedName).HasMaxLength(LogisticRelated.MaxRelatedNameLength);
                b.HasKey(p => p.Id);
                b.ToTable("LogisticRelateds");
                b.HasMany(p => p.Items).WithOne().HasForeignKey(p => p.LogisticRelatedId);
            });

            modelBuilder.Entity<LogisticRelatedItem>(b => {
                b.Property(p => p.Id).ValueGeneratedOnAdd();
                b.Property(p => p.LogisticRelatedId).IsRequired();
                b.Property(p => p.LogisticId).IsRequired();
                b.HasKey(p => p.Id);
                b.ToTable("LogisticRelatedItems");
                b.HasOne(p => p.LogisticBy).WithMany().HasForeignKey(p => p.LogisticId);
                b.HasOne(p => p.LogisticRelatedBy).WithMany().HasForeignKey(p => p.LogisticId);
            });

            modelBuilder.Entity<ProductSort>(b => {
                b.ToTable("ProductSorts");
                b.HasKey(p => p.Id);
                b.Property(p => p.SortName);
                b.Property(p=>p.IsActive);
                b.HasMany(p => p.Items).WithOne().HasForeignKey(p => p.ProductSortId);
            });

            modelBuilder.Entity<ProductClass>(b => {
                b.ToTable("ProductClasses");
                b.HasKey(p => p.Id);
                b.Property(p => p.ClassName);
                b.Property(p => p.PTId);
                b.Property(p => p.PostTaxRate);
                b.Property(p => p.BCTaxRate);
                b.Property(p => p.IsActive);
                b.Property(p => p.ProductSortId);
                b.HasOne(p => p.ProductSortBy).WithMany().HasForeignKey(p => p.ProductSortId);
            });
#pragma warning restore 612, 618
        }
    }
}
