using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Employee_Registration.Models
{
    public class _Employee
    {
        public int Employee_Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^[a-zA-Z\s]{1,60}$", ErrorMessage = "This field must only contain alphabetic characters and spaces.")]
        public string Employee_Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(1, 100, ErrorMessage = "This field must be between 1 to 3 characters long")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number is invalid.")]
        [Remote(action:"ValidateMoNumber",controller:"Employee",AdditionalFields = "Employee_Id",ErrorMessage = "Already registered user. Please enter a new one")]
        public string Mobile_Num { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "Address Line 1 cannot exceed 250 characters")]
        public string AddressLine1 { get; set; }


        [StringLength(250, ErrorMessage = "Address Line 2 cannot exceed 250 characters")]
        public string AddressLine2 { get; set; }


        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Pincode must be exactly 6 digits")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int? State { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int? Country { get; set; } 



    }
    
}
        
            


    

