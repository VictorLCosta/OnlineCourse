using System;
using System.Threading.Tasks;
using OnlineCourse.Data.Interfaces;

namespace OnlineCourse.Data.Transactions
{
    public interface IUow : IDisposable
    {
        ICourseRepository Courses { get; }
        Task Commit();
    }
}