﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRedarbor.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int? CompanyId { get; set; }
        public string CreatedOn { get; set; }
        public string DeletedOn { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Name { get; set; }
        public string Lastlogin { get; set; }
        public string Password { get; set; }
        public int? PortalId { get; set; }
        public int? RoleId { get; set; }
        public int? StatusId { get; set; }
        public string Telephone { get; set; }
        public string UpdatedOn { get; set; }
        public string Username { get; set; }
    }
}
