﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dto.Employee
{
    public class BoxDto
    {
        public string? Name;


        public int? EmployeeId { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        // public Address Address { get; set; }


    }
}