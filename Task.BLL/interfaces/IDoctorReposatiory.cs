using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.DAL.Entity;

namespace Task.BLL.interfaces
{
    public interface IDoctorReposatiory:IGenaricReposatory<Doctor>
    {
        IQueryable<Doctor> GetDoctors(string docname);
       
    }
}
