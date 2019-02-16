using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TwoTap.Models;
using Megastore.Models;

namespace Megastore.App_Start
{
    public class MappingProfile : Profile
    {
       public MappingProfile() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<TwoTap.Models.Brand, Megastore.Models.Brand>();
            });
        }
    }
}