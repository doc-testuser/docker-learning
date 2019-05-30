using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleLogin.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        public static ConcurrentDictionary<int, string> dic = new ConcurrentDictionary<int, string>();
        private string filePath = @"TextFile.txt";
        // GET: api/User
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return System.IO.File.ReadAllLines(filePath);
            //var dictionary = array.Select((value, index) => new { value, index })
            //          .ToDictionary(pair => pair.value, pair => pair.index);
            //return ;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            string[] strArr = System.IO.File.ReadAllLines(filePath);
            if (strArr.Count() > 0)
            {
               return (string)strArr.GetValue(id);
            }
            else
            {
                return null;
            }
            
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody]string value)
        {
            string[] strArr = System.IO.File.ReadAllLines(filePath);
            List<string> lstArr = new List<string>();
            lstArr = strArr.ToList();
            if (!lstArr.Contains(value))
            {
                lstArr.Add(value);
                System.IO.File.WriteAllLines(filePath, lstArr);
            }
        }
              
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            string[] strArr = System.IO.File.ReadAllLines(filePath);
            List<string> lstArr = new List<string>();
            lstArr = strArr.ToList();
            if (lstArr.Count > 0)
            {
                lstArr.RemoveAt(id);
                System.IO.File.WriteAllLines(filePath, lstArr);
            }

            return true;

        }
    }
}
