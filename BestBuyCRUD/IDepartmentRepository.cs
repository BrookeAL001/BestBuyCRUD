using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUD
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
