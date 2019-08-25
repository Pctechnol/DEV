using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsightConsulting.Domain.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        public DateTime dateOfBirth { get; set; }

        public int identityNumber { get; set; }

        public string address { get; set; }

        public string lineOne { get; set; }

        public string lineTwo { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public int postalCode { get; set; }
    }
}
