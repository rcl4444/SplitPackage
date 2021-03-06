﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitPackage.Business.SplitRules.Dto
{
    [AutoMapFrom(typeof(SplitRuleItem))]
    public class RuleItemDto: EntityDto<long>
    {
        public string RuleName { get; set; }

        [JsonProperty("ptid")]
        public string StintMark { get; set; }

        public string ProductClass { get; set; }

        public int MaxNum { get; set; }

        public int MinNum { get; set; }

        public int? TenantId { get; set; }

        public RuleItemStintType Type { get; set; }
    }
}
