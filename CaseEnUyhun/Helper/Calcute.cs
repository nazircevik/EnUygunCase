using CaseEnUygun.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseEnUygun.Helper
{
    public class Calcute:ICalcute
    {
        IRestData _restData;

        public Calcute(IRestData restData)
        {
            _restData = restData;


        }
        List<Mission> missionsLevel1 = new List<Mission>();
        List<Mission> missionsLevel2 = new List<Mission>();
        List<Mission> missionsLevel3 = new List<Mission>();
        List<Mission> missionsLevel4 = new List<Mission>();
        List<Mission> missionsLevel5 = new List<Mission>();

        List<Mission> dev1 = new List<Mission>();
        List<Mission> dev2 = new List<Mission>();
        List<Mission> dev3 = new List<Mission>();
        List<Mission> dev4 = new List<Mission>();
        List<Mission> dev5 = new List<Mission>();

        List<Mission> DeleteMission5;
        List<Mission> DeleteMission4;
        List<Mission> DeleteMission3;
        List<Mission> DeleteMission2;
        List<Mission> DeleteMission1;


        void TaskLevelRegulation()
        {
            foreach (var item in _restData.GetBusinesTask())
            {
                Mission mission = new Mission();
                mission.Level = item.level;
                mission.Name = item.business;
                mission.Time = item.estimated_duration;
                TaskAddForMissionLevel(mission);
            }

            foreach (var item in _restData.GetItTask())
            {
                Mission mission = new Mission();
                mission.Level = item.zorluk;
                mission.Name = item.id;
                mission.Time = item.sure;
                TaskAddForMissionLevel(mission);
            }

           missionsLevel1=   missionsLevel1.OrderByDescending(x=>x.Time).ToList();
            missionsLevel2 = missionsLevel2.OrderByDescending(x => x.Time).ToList();
            missionsLevel3= missionsLevel3.OrderByDescending(x => x.Time).ToList();
            missionsLevel4 = missionsLevel4.OrderByDescending(x => x.Time).ToList();
            missionsLevel5 = missionsLevel5.OrderByDescending(x => x.Time).ToList();

        }
        void DeleteMission()
        {
            DeleteMission5 = new List<Mission>();
            DeleteMission4 = new List<Mission>();
            DeleteMission3 = new List<Mission>();
            DeleteMission2 = new List<Mission>();
            DeleteMission1 = new List<Mission>();
        }
        void TaskAddForMissionLevel(Mission mission)
        {
            switch (mission.Level)
            {
                case 1:
                    missionsLevel1.Add(mission);
                    break;
                case 2:
                    missionsLevel2.Add(mission);
                    break;
                case 3:
                    missionsLevel3.Add(mission);
                    break;
                case 4:
                    missionsLevel4.Add(mission);
                    break;
                case 5:
                    missionsLevel5.Add(mission);
                    break;
            }
        }

        public int CalcuteStatus(out List<Mission>Dev1 , out List<Mission> Dev2, out List<Mission> Dev3, out List<Mission> Dev4, out List<Mission> Dev5,out int hafta)
        {
            TaskLevelRegulation();
            int Hafta = 0;
            while (missionsLevel1.Count>0|| missionsLevel2.Count > 0|| missionsLevel3.Count > 0|| missionsLevel4.Count > 0|| missionsLevel5.Count > 0)
            {
                Hafta++;
                double dev5h = 0;
                DeleteMission();
                while (dev5h<45)
                {
                    if (missionsLevel2.Count == 0 && missionsLevel1.Count == 0 && missionsLevel3.Count == 0 && missionsLevel4.Count == 0 && missionsLevel5.Count == 0)
                        break;

                    dev5.Add(new Mission { Name = Hafta.ToString() + ". Hafta", Level = 0, Time = 0 }); ;
                    foreach (var item in missionsLevel5)
                    {
                        if ((item.Time + dev5h) <= 45)
                        {
                            dev5.Add(item);
                            dev5h += item.Time;
                            DeleteMission5.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }
                    dev4.Add(new Mission { Name = Hafta.ToString() + ". Hafta", Level = 0, Time = 0 }); ;
                    foreach (var item in missionsLevel4)
                    {
                        if (((Convert.ToDouble(item.Time)*(4/5)) + dev5h) <= 45)
                        {
                            dev5.Add(item);
                            dev5h += item.Time;
                            DeleteMission4.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission4)
                    {
                        missionsLevel4.Remove(item);
                    }
                    dev3.Add(new Mission { Name = Hafta.ToString() + ". Hafta", Level = 0, Time = 0 }); ;
                    foreach (var item in missionsLevel3)
                    {
                        if (((Convert.ToDouble(item.Time) * (3/5)) + dev5h) <= 45)
                        {
                            dev5.Add(item);
                            dev5h += item.Time;
                            DeleteMission3.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission3)
                    {
                        missionsLevel3.Remove(item);
                    }
                    dev2.Add(new Mission { Name = Hafta.ToString() + ". Hafta", Level = 0, Time = 0 }); ;
                    foreach (var item in missionsLevel2)
                    {
                        if (((Convert.ToDouble(item.Time) * (2/5)) + dev5h) <= 45)
                        {
                            dev5.Add(item);
                            dev5h += item.Time;
                            DeleteMission2.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission2)
                    {
                        missionsLevel2.Remove(item);
                    }
                    dev1.Add(new Mission { Name = Hafta.ToString() + ". Hafta", Level = 0, Time = 0 }); ;
                    foreach (var item in missionsLevel1)
                    {
                        if (((Convert.ToDouble(item.Time) * (1/5)) + dev5h) <= 45)
                        {
                            dev5.Add(item);
                            dev5h += item.Time;
                            DeleteMission1.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }
                }
                double dev4h = 0;
                DeleteMission();
                while (dev4h < 45)
                {
                    if (missionsLevel2.Count == 0 && missionsLevel1.Count == 0 && missionsLevel3.Count == 0 && missionsLevel4.Count == 0 && missionsLevel5.Count == 0)
                        break;

                    foreach (var item in missionsLevel4)
                    {
                        if (((Convert.ToDouble(item.Time)*(4/4)) + dev4h) <= 45)
                        {
                            dev4.Add(item);
                            dev4h += item.Time;
                            DeleteMission4.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission4)
                    {
                        missionsLevel4.Remove(item);
                    }
                    foreach (var item in missionsLevel5)
                    {
                        if (((Convert.ToDouble(item.Time)* (5 / 4)) + dev4h) <= 45)
                        {
                            dev4.Add(item);
                            dev4h += item.Time;
                            DeleteMission5.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }
                    foreach (var item in missionsLevel3)
                    {
                        if (((Convert.ToDouble(item.Time) * (3/4)) + dev4h) <= 45)
                        {
                            dev4.Add(item);
                            dev4h += item.Time;
                            DeleteMission3.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission3)
                    {
                        missionsLevel3.Remove(item);
                    }
                    foreach (var item in missionsLevel2)
                    {
                        if (((Convert.ToDouble(item.Time) * (2/4)) + dev4h) <= 45)
                        {
                            dev4.Add(item);
                            dev4h += item.Time;
                            DeleteMission2.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission2)
                    {
                        missionsLevel2.Remove(item);
                    }
                    foreach (var item in missionsLevel1)
                    {
                        if (((Convert.ToDouble(item.Time) * (1/4)) + dev4h) <= 45)
                        {
                            dev4.Add(item);
                            dev4h += item.Time;
                            DeleteMission1.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission1)
                    {
                        missionsLevel1.Remove(item);
                    }
                }
                double dev3h = 0;
                DeleteMission();
                while (dev3h < 45)
                {
                    if (missionsLevel2.Count == 0 && missionsLevel1.Count == 0 && missionsLevel3.Count == 0 && missionsLevel4.Count == 0 && missionsLevel5.Count == 0)
                        break;

                    foreach (var item in missionsLevel3)
                    {
                        if (((Convert.ToDouble(item.Time) * (3 / 3)) + dev3h) <= 45)
                        {
                            dev3.Add(item);
                            dev3h += item.Time;
                           DeleteMission3.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission3)
                    {
                        missionsLevel3.Remove(item);
                    }
                    foreach (var item in missionsLevel4)
                    {
                        if (((Convert.ToDouble(item.Time) * (4 / 3)) + dev3h) <= 45)
                        {
                            dev3.Add(item);
                            dev3h += item.Time;
                            DeleteMission4.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission4)
                    {
                        missionsLevel4.Remove(item);
                    }
                    foreach (var item in missionsLevel5)
                    {
                        if (((Convert.ToDouble(item.Time) * (5 / 3)) + dev3h) <= 45)
                        {
                            dev3.Add(item);
                            dev3h += item.Time;
                            DeleteMission5.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }

                    foreach (var item in missionsLevel2)
                    {
                        if (((Convert.ToDouble(item.Time) * (2 / 3)) + dev3h) <= 45)
                        {
                            dev3.Add(item);
                            dev3h += item.Time;
                            DeleteMission2.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission2)
                    {
                        missionsLevel2.Remove(item);
                    }
                    foreach (var item in missionsLevel1)
                    {
                        if (((Convert.ToDouble(item.Time) * (1 / 3)) + dev3h) <= 45)
                        {
                            dev3.Add(item);
                            dev3h += item.Time;
                            DeleteMission1.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission1)
                    {
                        missionsLevel1.Remove(item);
                    }
                }
                double dev2h = 0;
                DeleteMission();
                while (dev2h < 45)
                {
                    if (missionsLevel2.Count == 0 && missionsLevel1.Count == 0 && missionsLevel3.Count == 0 && missionsLevel4.Count == 0 && missionsLevel5.Count == 0)
                        break;

                    foreach (var item in missionsLevel2)
                    {
                        if (((Convert.ToDouble(item.Time) * (2 / 2)) + dev2h) <= 45)
                        {
                            dev2.Add(item);
                            dev2h += item.Time;
                            DeleteMission2.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission2)
                    {
                        missionsLevel2.Remove(item);
                    }
                    foreach (var item in missionsLevel1)
                    {
                        if (((Convert.ToDouble(item.Time) * (1 / 2)) + dev2h) <= 45)
                        {
                            dev2.Add(item);
                            dev2h += item.Time;
                            DeleteMission1.Remove(item);
                        }
                    }
                    foreach (var item in DeleteMission1)
                    {
                        missionsLevel1.Remove(item);
                    }
                    foreach (var item in missionsLevel3)
                    {
                        if (((Convert.ToDouble(item.Time) * (3 / 2)) + dev2h) <= 45)
                        {
                            dev2.Add(item);
                            dev2h += item.Time;
                            DeleteMission3.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission3)
                    {
                        missionsLevel3.Remove(item);
                    }
                    foreach (var item in missionsLevel4)
                    {
                        if (((Convert.ToDouble(item.Time) * (4 / 2)) + dev2h) <= 45)
                        {
                            dev2.Add(item);
                            dev2h += item.Time;
                            DeleteMission4.Add(item);

                        }
                    }
                    foreach (var item in DeleteMission4)
                    {
                        missionsLevel4.Remove(item);
                    }
                    foreach (var item in missionsLevel5)
                    {
                        if (((Convert.ToDouble(item.Time) * (5 / 2)) + dev2h) <= 45)
                        {
                            dev2.Add(item);
                            dev2h += item.Time;
                            DeleteMission5.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }
                }
                double dev1h = 0;
                DeleteMission();
                while (dev1h < 45)
                {
                    if (missionsLevel2.Count == 0 && missionsLevel1.Count == 0 && missionsLevel3.Count == 0 && missionsLevel4.Count == 0 && missionsLevel5.Count == 0)
                        break;

                    foreach (var item in missionsLevel1)
                    {
                        if (((Convert.ToDouble(item.Time) * (1 / 1)) + dev1h) <= 45)
                        {
                            dev1.Add(item);
                            dev1h += item.Time;
                            DeleteMission1.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission1)
                    {
                        missionsLevel1.Remove(item);
                    }
                    foreach (var item in missionsLevel2)
                    {
                        if (((Convert.ToDouble(item.Time) * (2 / 1)) + dev1h) <= 45)
                        {
                            dev1.Add(item);
                            dev1h += item.Time;
                            DeleteMission2.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission2)
                    {
                        missionsLevel2.Remove(item);
                    }
                    foreach (var item in missionsLevel3)
                    {
                        if (((Convert.ToDouble(item.Time) * (3 / 1)) + dev1h) <= 45)
                        {
                            dev1.Add(item);
                            dev1h += item.Time;
                            DeleteMission2.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission3)
                    {
                        missionsLevel3.Remove(item);
                    }
                    foreach (var item in missionsLevel4)
                    {
                        if (((Convert.ToDouble(item.Time) * (4 / 1)) + dev1h) <= 45)
                        {
                            dev1.Add(item);
                            dev1h += item.Time;
                            DeleteMission4.Add(item);
                        }
                    }
                    foreach (var item in DeleteMission4)
                    {
                        missionsLevel4.Remove(item);
                    }
                    foreach (var item in missionsLevel5)
                    {
                        if (((Convert.ToDouble(item.Time) * (5 / 1)) + dev1h) <= 45)
                        {
                            dev1.Add(item);
                            dev1h += item.Time;
                            DeleteMission5.Remove(item);
                        }
                    }
                    foreach (var item in DeleteMission5)
                    {
                        missionsLevel5.Remove(item);
                    }
                }



            }

            int dev1last=  dev1.IndexOf(dev1.FirstOrDefault(x => x.Name.Contains(Hafta.ToString() + ". Hafta")));
            int dev2last = dev2.IndexOf(dev2.FirstOrDefault(x => x.Name.Contains(Hafta.ToString() + ". Hafta")));
            int dev3last = dev3.IndexOf(dev3.FirstOrDefault(x => x.Name.Contains(Hafta.ToString() + ". Hafta")));
            int dev4last = dev4.IndexOf(dev4.FirstOrDefault(x => x.Name.Contains(Hafta.ToString() + ". Hafta")));
            int dev5last = dev5.IndexOf(dev5.FirstOrDefault(x => x.Name.Contains(Hafta.ToString() + ". Hafta")));
            List<Mission> Lastweek = new List<Mission>();
            if(dev1.Count!=dev1last+1)
            {
                for (int i = dev1last + 1; i < dev1.Count; i++)
                {
                    Lastweek.Add(dev1[i]);
                }
                dev1.RemoveRange(dev1last + 1, (dev1.Count - dev1last - 1));
            }
            if (dev2.Count != dev2last + 1)
            {
                for (int i = dev2last + 1; i < dev2.Count; i++)
                {
                    Lastweek.Add(dev2[i]);
                }
                dev2.RemoveRange(dev2last + 1, (dev2.Count - dev2last - 1));

            }
            if (dev3.Count != dev3last + 1)
            {
                for (int i = dev3last + 1; i < dev3.Count; i++)
                {
                    Lastweek.Add(dev3[i]);
                }
                dev3.RemoveRange(dev3last + 1, (dev3.Count - dev3last - 1));

            }
            if (dev4.Count != dev4last + 1)
            {
                for (int i = dev4last+1; i < dev4.Count; i++)
                {
                    Lastweek.Add(dev4[i]);
                }
                dev4.RemoveRange(dev4last + 1, (dev4.Count-dev4last-1));

            }
            if (dev5.Count != dev5last + 1)
            {
                for (int i = dev5last + 1; i < dev5.Count; i++)
                {
                    Lastweek.Add(dev5[i]);
                }
                dev5.RemoveRange(dev5last + 1, (dev5.Count - dev5last - 1));

            }
            List<int> Time = new List<int>();

            foreach (var item in Lastweek)
            {
                Time.Add(item.Time * item.Level);
            }
            double sonuc = Time.Sum()/5;
            double say1 = 0;
            List<Mission> Deleted = new List<Mission>();
            foreach (var item in Lastweek)
            {
                if(say1<sonuc)
                {
                    dev1.Add(item);
                    Deleted.Add(item);
                    say1 = say1 + (item.Time * 1);
                }

            }
            foreach (var item in Deleted)
            {
                Lastweek.Remove(item);
            }
            say1 = 0;

            Deleted = new List<Mission>();
            foreach (var item in Lastweek)
            {
                if (say1*4 < sonuc)
                {
                    dev2.Add(item);
                    Deleted.Add(item);
                    say1 = say1 + (Convert.ToDouble(item.Time) * 0.8);

                }

            }
            foreach (var item in Deleted)
            {
                Lastweek.Remove(item);

            }
            Deleted = new List<Mission>();
            say1 = 0;

            foreach (var item in Lastweek)
            {
                if (say1*3 < sonuc)
                {
                    dev3.Add(item);
                    Deleted.Add(item);
                    say1 = say1 + (Convert.ToDouble(item.Time)*0.6);

                }

            }
            foreach (var item in Deleted)
            {
                Lastweek.Remove(item);
            }
            Deleted = new List<Mission>();
            say1 = 0;

            foreach (var item in Lastweek)
            {
                if (say1*2 < sonuc)
                {
                    dev4.Add(item);
                    Deleted.Add(item);
                    say1 = say1 + (Convert.ToDouble(item.Time) * 0.4);

                }

            }
            foreach (var item in Deleted)
            {
                Lastweek.Remove(item);

            }
            Deleted = new List<Mission>();
            say1 = 0;

            foreach (var item in Lastweek)
            {
                    dev5.Add(item);
                    Deleted.Add(item);
            }
            foreach (var item in Deleted)
            {
                Lastweek.Remove(item);

            }
            Deleted = new List<Mission>();

            Dev1 = dev1;
            Dev2 = dev2;
            Dev3=  dev3;
            Dev4 = dev4;
            Dev5 = dev5;
            hafta = Hafta;
            return 1;
        }
    }
}
