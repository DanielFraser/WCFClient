using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WCFClient.EmployeeReference;

namespace WCFClient.Models
{
    public class EmployeeModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Hiredate { get; set; }

        [Required]
        [Range(0.01, 999999999, ErrorMessage = "Salary must be greater than 0.00")]
        public decimal Salary { get; set; }

        [Required]
        [ValidDept (ErrorMessage = "Invalid Department Name")]
        public string Deptname { get; set; }

        [Required]
        public string Address { get; set; }

        public int Id { get; set; }

        public class ValidDept : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                EmployeeServiceClient esc = new EmployeeServiceClient();
                var val = (string)value;
                return esc.GetDepts("").Contains(val);
            }
        }
    }
}