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
    public class SecretaryReposatiory : GenaricReposatory<Secretary>
    {
        public SecretaryReposatiory(DbContextClinic dbContextClinic):base(dbContextClinic)
        {

        }
      
    }
}
