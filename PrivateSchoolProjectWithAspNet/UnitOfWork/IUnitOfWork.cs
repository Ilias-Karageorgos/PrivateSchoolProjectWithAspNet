using PrivateSchoolProjectWithAspNet.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Unit
{
    public interface IUnitOfWork : IDisposable
    {
        IAssignment Assignments { get; }
        ICourse Courses { get; }
        ITrainer Trainers { get; }
        IStudent Students { get; }
        Task<int> Complete();
    }
}