using AutoMapper;
using Help.DBAccessLayer.Model.UsermanageDB;
using Help.EF.UsermanageDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Service.Mappers
{
    public class RoleInfoMapper : Profile
    {
        public override string ProfileName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        protected override void Configure()
        {
            CreateMap<MRoleInfo, roleinfo>();
            CreateMap<roleinfo, MRoleInfo>();
        }
    }
}
