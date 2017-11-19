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
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<core.Project, Project>().ReverseMap();
                cfg.CreateMap<core.ProjectStage, ProjectStage>().ReverseMap();
                cfg.CreateMap<core.ProjectTask, ProjectTask>().ReverseMap();
            });

        }
    }
}
