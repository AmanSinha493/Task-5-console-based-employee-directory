using System;
using services.employee;

namespace employees;
     class Role:IRole
     {
        // public static List<Role> roleList = [];
        // public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public string? Description { get; set; }
    }
