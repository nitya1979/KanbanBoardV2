using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using core = KanbanBoardCore;

namespace KanbanBoard.SqlRepository
{
    public class SqlMapperConfiguraiton : Profile
    {
        public SqlMapperConfiguraiton():base("sqlmapper")
        {
        }

        protected SqlMapperConfiguraiton(string profileName) : base(profileName)
        {
            CreateMap<core.UserDetail, UserEntity>().ReverseMap();
            CreateMap<core.Project, DbProject>().ForMember( d => d.Stages, o =>o.Ignore()).ReverseMap();
            CreateMap<core.ProjectStage, DbProjectStage>().ReverseMap();
            CreateMap<core.ProjectTask, DbProjectTask>().ReverseMap();
        }


    }
}
