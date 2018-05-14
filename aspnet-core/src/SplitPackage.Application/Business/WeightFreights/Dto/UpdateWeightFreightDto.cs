﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SplitPackage.Business.WeightFreights.Dto
{
    [AutoMap(typeof(WeightFreight))]
    public class UpdateWeightFreightDto : EntityDto<long>
    {
        public string Currency { get; set; }

        public string Unit { get; set; }

        public double StartingWeight { get; set; }

        public double EndWeight { get; set; }

        public double StartingPrice { get; set; }

        public double StepWeight { get; set; }

        public double CostPrice { get; set; }

        public double Price { get; set; }
    }
}
