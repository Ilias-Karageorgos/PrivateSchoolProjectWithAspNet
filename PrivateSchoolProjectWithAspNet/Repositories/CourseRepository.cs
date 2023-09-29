using PrivateSchoolProjectWithAspNet.IRepositories;
using PrivateSchoolProjectWithAspNet.Models;
using PrivateSchoolProjectWithAspNet.MyDatabase;
using PrivateSchoolProjectWithAspNet.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Repositories
{
    public class CourseRepository : GenRepository<Course>, ICourse
    {
        public CourseRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;
    }
}