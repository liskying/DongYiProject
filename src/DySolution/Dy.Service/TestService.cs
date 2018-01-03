
using Dy.Data.Domain;
using Dy.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dy.Service
{
    public class TestService : ITestService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IPagedList<SysDept> GetDept(Expression<Func<SysDept, bool>> filter, int pgIndex = 1, int pgSize = 20)
        {
            IList<SysDept> objRet = new List<SysDept>();
            var deptRop = _unitOfWork.GetRepository<SysDept>();
            var result = deptRop.GetPagedList(u => u, filter, null, null, pgIndex, pgSize);
            return result;
        }

        IPagedList<SysDept> ITestService.GetDept(Expression<Func<SysDept, bool>> filter, int pgIndex, int pgSize)
        {
            throw new NotImplementedException();
        }
    }
}