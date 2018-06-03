﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using SplitPackage.Business.NumFreights.Dto;
using SplitPackage.Business.WeightFreights.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SplitPackage.Business.LogisticChannels.Dto
{
    public class CreateLogisticChannelDto : EntityDto<long>
    {
        [Required]
        [StringLength(LogisticChannel.MaxChannelNameLength)]
        public string ChannelName { get; set; }
        
        [StringLength(LogisticChannel.MaxAliasNameLength)]
        public string AliasName { get; set; }

        [Required]
        public ChannelType Type { get; set; }

        [Required]
        public ChargeWay Way { get; set; }

        [Required]
        public long LogisticId { get; set; }

        public IEnumerable<NumFreightDto> NumChargeRules { get; set; }

        public IEnumerable<WeightFreightDto> WeightChargeRules { get; set; }
    }
}