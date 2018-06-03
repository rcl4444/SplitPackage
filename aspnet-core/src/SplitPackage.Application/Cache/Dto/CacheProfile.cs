﻿using AutoMapper;
using SplitPackage.Business;
using SplitPackage.Business.NumFreights.Dto;
using SplitPackage.Business.WeightFreights.Dto;
using SplitPackage.Domain.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SplitPackage.Cache.Dto
{
    public class CacheProfile : Profile
    {
        public CacheProfile()
        {
            CreateMap<Logistic, LogisticCacheDto>().ForMember(dest => dest.LogisticChannels, opt => opt.MapFrom(o => o.LogisticChannels));

            CreateMap<SplitRule, SplitRuleCacheDto>();

            CreateMap<SplitRuleProductClass, SplitRuleProductClassCacheDto>();

            CreateMap<LogisticChannel, ChannelCacheDto>();

            CreateMap<LogisticRelated, IList<LogisticRelatedOptionCacheDto>>().ConvertUsing(o => o.Items.Select(oi => new LogisticRelatedOptionCacheDto()
            {
                LogisticId = oi.LogisticId,
                LogisticCode = oi.LogisticBy.LogisticCode
            }).ToList());

            CreateMap<WeightFreight, WeightFreightCacheDto>();

            CreateMap<NumFreight, NumFreightCacheDto>();

            CreateMap<NumFreightDto, NumFreightCacheDto>();

            CreateMap<WeightFreightDto, WeightFreightCacheDto>();

            CreateMap<ModifyChannelEvent, ChannelCacheDto>();

            CreateMap<SplitRule, SplitRuleCacheDto>();
        }
    }
}
