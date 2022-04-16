using CaseEnUygun.Models;
using Data.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public  class RestData:IRestData
    {
        public List<ItTask> GetItTask()
        { 
            List<ItTask> listObjects = new List<ItTask>();

            string response = "";
            using (var client = new WebClient() { UseDefaultCredentials = true })
            {
                response = client.DownloadString("http://www.mocky.io/v2/5d47f24c330000623fa3ebfa");
            }

            listObjects = JsonConvert.DeserializeObject<List<ItTask>>(response);
            return listObjects;
        }
        public List<BusinessTask> GetBusinesTask()
        {
            List<BusinessTask> listObjects = new List<BusinessTask>();

            string response = "";
            using (var client = new WebClient() { UseDefaultCredentials = true })
            {
                response = client.DownloadString("http://www.mocky.io/v2/5d47f235330000623fa3ebf7");
            }
            var responeList = JsonConvert.DeserializeObject<List<JObject>>(response);
            for (int i = 0; i < responeList.Count; i++)
            {
                BusinessTask businessTask = new BusinessTask();
                var fdate = JObject.Parse(responeList[i].ToString());
                string Task= "Business Task "+i.ToString();
                var deneme = fdate[Task]; 
                 businessTask.level = Convert.ToInt32(deneme.SelectToken("level"));
                 businessTask.estimated_duration  = Convert.ToInt32(deneme.SelectToken("estimated_duration"));
                businessTask.business = Task;
                listObjects.Add(businessTask);

            }

           
            return listObjects;
        }
    }
}
