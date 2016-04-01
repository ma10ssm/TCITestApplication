using System;
using System.Collections.Generic;
using TCIApplication.Models;

namespace TCIApplication.DAL
{
    public class TCIApplicationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TCIApplicationContext>
    {
        protected override void Seed(TCIApplicationContext context)
        {
            var departments = new List<Department>
            {
                new Department{ Name = "Finance" },
                new Department{ Name = "HR" },
                new Department{ Name = "Computing" },
                new Department{ Name = "Sales" }
            };
            departments.ForEach(d => context.Departments.Add(d));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{FirstName = "Nick", MiddleName = "Andrew", LastName="Alexander", Address = "259 Pinner Rd, Harrow, Greater London, UK", StartDate = DateTime.Parse("2011-01-09"), Department = context.Departments.Find(1)},
                new Employee{FirstName = "John", MiddleName = null, LastName="Patterson", Address = "86 York St,Marylebone, London W1H 1QS, UK", StartDate = DateTime.Parse("2015-09-01"), Department = context.Departments.Find(1)},
                new Employee{FirstName = "Carson", MiddleName = null, LastName="Alexander", Address = "248 Commercial Way, London SE15 1PU, UK", StartDate = DateTime.Parse("2014-10-05"), Department = context.Departments.Find(1)},
                new Employee{FirstName = "Caroline", MiddleName = null, LastName="Godson", Address = "30A Baker St, Reading RG1 7XX, UK", StartDate = DateTime.Parse("2005-05-17"), Department = context.Departments.Find(1)}

            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

        }
    }
}