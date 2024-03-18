using System;
using employees;

namespace services.employee{
    internal class RoleModel{
        public static List<RoleModel> roleList = [];
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
    }
}