using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.BLL.interfaces;
using Task.DAL.Context;
using Task.DAL.Entity;

namespace Task.BLL.Reposatiories
{
    public class DoctorReposatiory : GenericReposatiory<Doctor>, IDoctorReposatiory
    {
        private readonly DbContextClinic _dbContextClinic;

        public DoctorReposatiory(DbContextClinic dbContextClinic):base(dbContextClinic)
        {
            _dbContextClinic = dbContextClinic;
        }

        public IQueryable<Doctor> GetDoctors(string docname)
        {
            throw new NotImplementedException();
        }

        
    }
}
