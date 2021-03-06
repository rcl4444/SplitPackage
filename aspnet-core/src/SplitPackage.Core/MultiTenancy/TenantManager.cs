﻿using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using SplitPackage.Authorization.Users;
using SplitPackage.Editions;
using System.Threading.Tasks;

namespace SplitPackage.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }

        protected override Task ValidateTenancyNameAsync(string tenancyName)
        {
            return Task.FromResult(0);
        }
    }
}
