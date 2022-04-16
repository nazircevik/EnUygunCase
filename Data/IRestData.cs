using CaseEnUygun.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  interface IRestData
    {
        public List<ItTask> GetItTask();
        public List<BusinessTask> GetBusinesTask();


    }
}
