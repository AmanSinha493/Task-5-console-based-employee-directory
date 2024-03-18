using System;
using employees;

namespace services.employee{
    internal class EmployeeModel{
        public static List<EmployeeModel> employeeList = [];
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
        public string? MobileNo { get; set; }
    }
}