﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SplitPackage.Business.SplitRules.Dto
{
    [AutoMapTo(typeof(SplitRuleProductClass))]
    public class UpdateRuleItemDto : EntityDto<long>
    {
        [JsonProperty("ptid")]
        public string PTId { get; set; }

        public int MaxNum { get; set; }

        public int MinNum { get; set; }
    }
}
