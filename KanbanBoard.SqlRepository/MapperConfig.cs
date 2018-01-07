using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using core = KanbanBoardCore;

namespace KanbanBoard.SqlRepository
{
    public static class MapperConfig
    {
        public static void InitializeMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<core.UserDetail, UserEntity>().ReverseMap();
                cfg.CreateMap<core.Project, DbProject>().ReverseMap();
                cfg.CreateMap<core.ProjectStage, DbProjectStage>().ReverseMap();
                cfg.CreateMap<core.ProjectTask, DbProjectTask>().ReverseMap();
            });

        }

        
    }

   
}
