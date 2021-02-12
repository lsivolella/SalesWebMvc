﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
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
