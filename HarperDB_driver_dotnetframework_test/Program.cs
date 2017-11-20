using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HarperDB.NET;

namespace HarperDB_driver_dotnetframework_test
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }
        static async Task<dynamic> GetAsync()
        {
            HarperDBClient harperDB = new HarperDBClient(new Uri("http://52.187.61.90:9925"), "HDB_ADMIN", "root1984");
            var response = await harperDB.SQLSelect(@"select productid as id,* from northwnd.products order by id asc limit 1000");
            var data = JsonConvert.SerializeObject(response);
            foreach (var pair in response)
            {
                Console.Write(pair);    // json data
            }
            //Console.WriteLine(data);  // json object
            return data;
        }
    }
}
