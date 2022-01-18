using AutoMapper;
using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Helpers.Profiles
{
    public class MappingProfiles
    {
        public class Repo2WorkProfile : Profile
        {
            public Repo2WorkProfile()
            {
                CreateMap<RepoModel, WorkProjectModel>();
            }
        }
    }
}
