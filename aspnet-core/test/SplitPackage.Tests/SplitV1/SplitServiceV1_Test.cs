﻿using Abp.Authorization.Users;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.UI;
using SplitPackage.SplitV1;
using SplitPackage.Split.Common;
using SplitPackage.Split.Dto;
using SplitPackage.Split.RuleModels;
using SplitPackage.Split.SplitModels;
using SplitPackage.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SplitPackage.Tests.SplitV1
{
    /// <summary>
    /// 海购助手
    /// </summary>
    [Collection("Assistant collection")]
    public class SplitServiceV1_Test
    {
        private readonly ISplitService _splitService;
        private readonly AssistantCase _context;

        public SplitServiceV1_Test(Xunit.Abstractions.ITestOutputHelper output, AssistantCase context)
        {
            this._context = context;
            this._splitService = this._context.ResolveService<ISplitService>();
        }

        [Fact]
        public async Task<bool> SplitTest()
        {
            var request = new SplitRequest()
            {
                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "26098951",
                        Quantity = 1,
                        ProName = "MAMIA婴幼儿奶粉二段900G二段",
                        ProPrice = 100,
                        Weight = 100,
                        PTId = "1010703"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "26113807",
                        Quantity = 2,
                        ProName = "MAMIA婴幼儿奶粉三段900G三段",
                        ProPrice = 100,
                        Weight = 100,
                        PTId = "1010704"
                    }
                },
                TotalQuantity = 1,
                Type = 3
            };
            var result = await this._splitService.Split(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("4PX Express", result.OrderList[0].LogisticsName);
            Assert.Equal("4PX Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("转运四方现代物流3罐婴儿奶粉专线", result.OrderList[0].SubBusinessName);
            return true;
        }

        [Fact]
        public async Task SplitWithExp1Test()
        {
            var request = new SplitWithExpRequest1()
            {
                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "26098951",
                        Quantity = 1,
                        ProName = "MAMIA婴幼儿奶粉二段900G二段",
                        ProPrice = 100,
                        Weight = 100,
                        PTId = "1010703"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "26113807",
                        Quantity = 2,
                        ProName = "MAMIA婴幼儿奶粉三段900G三段",
                        ProPrice = 100,
                        Weight = 100,
                        PTId = "1010704"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "AOLAU EXPRESS" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("4PX Express", result.OrderList[0].LogisticsName);
            Assert.Equal("4PX Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("转运四方现代物流3罐婴儿奶粉专线", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitTest_1()
        {
            var request = new SplitRequest()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "391709501015",
                        Quantity = 1,
                        ProName = "NOZOHAEM止鼻血凝胶4粒",
                        ProPrice = 57,
                        Weight = 100,
                        PTId = "9029900"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "735282370007",
                        Quantity = 1,
                        ProName = "Munchkin草饲牧牛婴儿配方奶粉1段",
                        ProPrice = 57,
                        Weight = 100,
                        PTId = "1010703"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "768990017414",
                        Quantity = 1,
                        ProName = "孕妇DHA",
                        ProPrice = 57,
                        Weight = 100,
                        PTId = "1019904"
                    }
                },
                TotalQuantity = 1,
                Type = 3
            };
            var result = await this._splitService.Split(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("ZH Express", result.OrderList[0].LogisticsName);
            Assert.Equal("ZH Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中环杂货混装线", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitWithExp1Test_1()
        {
            var request = new SplitWithExpRequest1()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "391709501015",
                        Quantity = 1,
                        ProName = "NOZOHAEM止鼻血凝胶4粒",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "9029900"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "735282370007",
                        Quantity = 1,
                        ProName = "Munchkin草饲牧牛婴儿配方奶粉1段",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1010703"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "768990017414",
                        Quantity = 1,
                        ProName = "孕妇DHA",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019904"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "CNP Express" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中邮混装线", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitTest_2()
        {
            var request = new SplitRequest()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "735282490033",
                        Quantity = 10,
                        ProName = "MUNCHKIN碗",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "9029900"
                    }
                },
                TotalQuantity = 1,
                Type = 3
            };
            var result = await this._splitService.Split(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitWithExp1Test_2()
        {
            var request = new SplitWithExpRequest1()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "735282490033",
                        Quantity = 10,
                        ProName = "MUNCHKIN碗",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "9029900"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "CNP Express" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitTest_3()
        {
            var request = new SplitRequest()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "852696000204",
                        Quantity = 15,
                        ProName = "COBRAMESTATE橄榄油750ML",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019903"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "857052004445",
                        Quantity = 10,
                        ProName = "SKIPHOP围兜",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "9029900"
                    }
                },
                TotalQuantity = 25,
                Type = 3
            };
            var result = await this._splitService.Split(request, this._context.GetTenantId());
            Assert.Equal(2, result.OrderList.Count);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[0].SubBusinessName);
            Assert.Equal("CNP Express", result.OrderList[1].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[1].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[1].SubBusinessName);
        }

        [Fact]
        public async Task SplitWithExp1Test_3()
        {
            var request = new SplitWithExpRequest1()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "852696000204",
                        Quantity = 15,
                        ProName = "COBRAMESTATE橄榄油750ML",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019903"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "857052004445",
                        Quantity = 10,
                        ProName = "SKIPHOP围兜",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "9029900"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "CNP Express" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Equal(2, result.OrderList.Count);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[0].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[0].SubBusinessName);
            Assert.Equal("CNP Express", result.OrderList[1].LogisticsName);
            Assert.Equal("CNP Express", result.OrderList[1].LogisticsCode);
            Assert.Equal("中邮杂货专线", result.OrderList[1].SubBusinessName);
        }

        [Fact]
        public async Task SplitTest_4()
        {
            var request = new SplitRequest()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "70000137",
                        Quantity = 10,
                        ProName = "蜡笔细长0.15",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019903"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "93262170",
                        Quantity = 5,
                        ProName = "BONJELA口腔凝胶15G",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019904"
                    }
                },
                TotalQuantity = 15,
                Type = 3
            };
            var result = await this._splitService.Split(request, this._context.GetTenantId());
            Assert.Single(result.OrderList);
            Assert.Equal("THEARK EXPRESS", result.OrderList[0].LogisticsName);
            Assert.Equal("THEARK EXPRESS", result.OrderList[0].LogisticsCode);
            Assert.Equal("方舟AlphaEX", result.OrderList[0].SubBusinessName);
        }

        [Fact]
        public async Task SplitWithExp1Test_4()
        {
            var request = new SplitWithExpRequest1()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "70000137",
                        Quantity = 10,
                        ProName = "蜡笔细长0.15",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019903"
                    },
                    new Product()
                    {
                        ProNo = "",
                        SkuNo = "93262170",
                        Quantity = 5,
                        ProName = "BONJELA口腔凝胶15G",
                        ProPrice = 1,
                        Weight = 100,
                        PTId = "1019904"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "AOLAU EXPRESS" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Equal(2, result.OrderList.Count);
            Assert.Equal("AOLAU EXPRESS", result.OrderList[0].LogisticsName);
            Assert.Equal("AOLAU EXPRESS", result.OrderList[0].LogisticsCode);
            Assert.Equal("澳通速递单独装", result.OrderList[0].SubBusinessName);
            Assert.Equal("AOLAU EXPRESS", result.OrderList[1].LogisticsName);
            Assert.Equal("AOLAU EXPRESS", result.OrderList[1].LogisticsCode);
            Assert.Equal("澳通速递杂货混装线", result.OrderList[1].SubBusinessName);
        }

        [Fact]
        public async Task SplitWithExp1Test_5()
        {
            var request = new SplitWithExpRequest1()
            {

                OrderId = "18040300110001",
                ProList = new List<Product>() {
                    new Product()
                    {
                        ProNo = "9310160814098",
                        SkuNo = "9310160814098",
                        Quantity = 1,
                        ProName = "Menevit 爱乐维男性备孕营养素 90粒装",
                        ProPrice = 5.69M,
                        Weight = 200,
                        PTId = "101990401"
                    },
                    new Product()
                    {
                        ProNo = "9320971310566",
                        SkuNo = "9320971310566",
                        Quantity = 2,
                        ProName = "全脂奶粉",
                        ProPrice = 5.69M,
                        Weight = 200,
                        PTId = "1010701"
                    }
                },
                TotalQuantity = 1,
                logistics = new List<string> { "EWE Express 标准线" }
            };
            var result = await this._splitService.SplitWithOrganization1(request, this._context.GetTenantId());
            Assert.Equal(2, result.OrderList.Count);
            Assert.Equal("EWE Express 标准线", result.OrderList[0].LogisticsName);
            Assert.Equal("EWE Express 标准线", result.OrderList[0].LogisticsCode);
            Assert.Equal("EWE杂货标准线", result.OrderList[0].SubBusinessName);
            Assert.Equal("EWE Express 经济线", result.OrderList[1].LogisticsName);
            Assert.Equal("EWE Express 经济线", result.OrderList[1].LogisticsCode);
            Assert.Equal("EWE经济线1-3罐奶粉", result.OrderList[1].SubBusinessName);
        }

        [Fact]
        public async Task GetLogisticsList_Test()
        {
            var result = await this._splitService.GetLogisticsList(this._context.GetTenantId());
            foreach (var item in result)
            {
                Assert.Equal(item.ID, item.Name);
            }
        }
    }
}
