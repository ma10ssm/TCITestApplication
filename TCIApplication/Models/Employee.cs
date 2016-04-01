using System;
using System.ComponentModel.DataAnnotations;

namespace TCIApplication.Models
{
    
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
                
        [StringLength(50, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}