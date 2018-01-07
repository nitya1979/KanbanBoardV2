using AutoMapper;
using KanbanAPI.ViewModels;
using KanbanBoardCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration():base("KanbanProfile")
        {
        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<ProjectViewModel, Project>();
        }


    }
}
