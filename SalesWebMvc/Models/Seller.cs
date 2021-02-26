using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size must be between {2} and {1} characters.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "{0} required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [Range(100.0, 5000.0, ErrorMessage = "{0} must range between {1} and {2}.")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        //[DataType(DataType.Currency)]
        public double BaseSalary { get; set; }
        
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecord { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            SalesRecord.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            SalesRecord.Remove(salesRecord);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate)
        {
            return SalesRecord.Where(salesRecord => salesRecord.Date >= initialDate && salesRecord.Date <= finalDate).Sum(salesRecord => salesRecord.Amount);

            //double totalSales = 0;

            //foreach (var sale in SalesRecord)
            //{
            //    if (sale.Date >= initialDate && sale.Date <= finalDate)
            //        totalSales += sale.Amount;
            //}

            //return totalSales;
        }
    }
}
