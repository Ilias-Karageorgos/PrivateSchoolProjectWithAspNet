using PrivateSchoolProjectWithAspNet.IRepositories;
using PrivateSchoolProjectWithAspNet.Models;
using PrivateSchoolProjectWithAspNet.MyDatabase;
using PrivateSchoolProjectWithAspNet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Trainers = new TrainerRepository(_context);
            Students = new StudentRepository(_context);
            Courses = new CourseRepository(_context);
            Assignments = new AssignmentRepository(_context);
        }

        #region UnitOfWorkMembers
        public ITrainer Trainers { get; private set; }
        public IStudent Students { get; private set; }
        public ICourse Courses { get; private set; }
        public IAssignment Assignments { get; private set; }
        #endregion

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}