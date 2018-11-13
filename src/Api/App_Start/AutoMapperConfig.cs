using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EnterpriseMessagingGateway.Core.Entities;
using EnterpriseMessagingGateway.Services.Interfaces.Dto;

namespace EnterpriseMessagingGateway.Api
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Task, TaskDetailDto>().ReverseMap();
                cfg.CreateMap<TaskParameter, TaskParameterDto>().ReverseMap();
                cfg.CreateMap<TaskProperty, TaskPropertyDto>().ReverseMap();

                cfg.CreateMap<TaskParameterCreateDto, TaskParameter>();
                cfg.CreateMap<TaskPropertyCreateDto, TaskProperty>();
                cfg.CreateMap<TaskDetailCreateDto, Task>();

                // Mapper.CreateMap<DatabaseA, A>()
                //.ForMember(dest => dest.Bprop, opt => opt.MapFrom(src => src.Bprop));

                // Mapper.CreateMap<DatabaseB, B>()
                //     .ForMember(dest => dest.Cprop, opt => opt.MapFrom(src => src.Cprop));

                // Mapper.CreateMap<DatabaseC, C>();


                cfg.CreateMap<TradingPartner, TradingPartnerDetailDto>().ReverseMap();
                cfg.CreateMap<TradingPartnerIdentifier, TradingPartnerIdentifierDto>().ReverseMap();
                cfg.CreateMap<TradingPartnerProperty, TradingPartnerPropertyDto>().ReverseMap();
                cfg.CreateMap<TradingPartnerContact, TradingPartnerContactDetailDto>().ReverseMap();
                cfg.CreateMap<TradingPartnerContact, TradingPartnerContactDto>().ReverseMap();
                cfg.CreateMap<TradingPartnerContactProperty, TradingPartnerContactPropertyDto>().ReverseMap();
             
                cfg.CreateMap<TradingPartnerPropertyCreateDto, TradingPartnerProperty>();
                cfg.CreateMap<TradingPartnerContactCreateDto, TradingPartnerContact>();
                cfg.CreateMap<TradingPartnerContactDetailCreateDto, TradingPartnerContact>();
                cfg.CreateMap<TradingPartnerContactPropertyCreateDto, TradingPartnerContactProperty>();
                cfg.CreateMap<TradingPartnerIdentifierCreateDto, TradingPartnerIdentifier>();
                cfg.CreateMap<TradingPartnerDetailCreateDto, TradingPartner>();
                
            });

        }
    }
}