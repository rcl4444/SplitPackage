﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SplitPackage.Business.LogisticLines.Dto
{
    [AutoMapFrom(typeof(LogisticLine))]
    public class LogisticLineDto: EntityDto<long>, IPassivable
    {
        [Required]
        [StringLength(LogisticLine.MaxLineNameLength)]
        public string LineName { get; set; }

        [Required]
        [StringLength(LogisticLine.MaxLineCodeLength)]
        public string LineCode { get; set; }

        [Required]
        public long LogisticId { get; set; }

        public string LogisticName { get; set; }

        public bool IsActive { get; set; }
    }
}