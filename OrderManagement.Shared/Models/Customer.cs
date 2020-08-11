using System;

namespace OrderManagement.Shared.Models
{
    public class Customer    {
        public Customer()
        {
           id = Guid.Empty;
        }
        public Guid id { get; set; } 
        public string email { get; set; } 
        public string first_name { get; set; } 
        public string last_name { get; set; } 
        public string gender { get; set; } 
        public string Street_Number { get; set; } 
        public string Address1 { get; set; } 
        public string Address2 { get; set; } 
        public string City { get; set; } 
        public string ZipCode { get; set; } 
        public string State { get; set; } 
        public string Avatar_Url { get; set; } 

    }  
}
  
