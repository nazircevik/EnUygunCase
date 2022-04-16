using CaseEnUygun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseEnUygun.Helper
{
    public  interface ICalcute
    {
        public int CalcuteStatus(out List<Mission> Dev1, out List<Mission> Dev2, out List<Mission> Dev3, out List<Mission> Dev4, out List<Mission> Dev5, out int hafta);

    }
}
