using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Automapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.EmpID = 90;
            emp.EmpName = "Tudu";
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, Subscriber>();
            });
            IMapper mapper = config.CreateMapper();
            var source = new Employee();
            var dest = mapper.Map<Employee, Subscriber>(emp);
        }
    }
    /// <summary>
    /// source
    /// </summary>
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
    }
    /// <summary>
    /// Destination
    /// </summary>
    class Subscriber
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
    }
}
