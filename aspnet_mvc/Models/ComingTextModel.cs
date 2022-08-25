using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CSharp.RuntimeBinder;
using System.Globalization;
using System.IO;
using static System.IO.FileStream;

namespace aspnet_mvc.Models
{
    public class ComingTextModel
    {
        public static string error { get; set; }
        public int? RemainingVacation { get; set; }
        public string? Name { get; set; }
        public string Surname { get; set; }
        public int? EarnedVacation { get; set; }
        public int? Salary { get; set; }
        public string? Branch { get; set; }
        public string? Department { get; set; }
        public int? YearsWorked { get; set; }
        public bool? WantsToAddVacations { get; set; }


        //public ComingTextModel(string vac, string name, string surname, string earnedvac, string salary, string branch, string department, string years, string want)
        //{
        //    error = null;
        //    try
        //    {
        //        this.RemainingVacation = int.Parse(vac, NumberStyles.AllowLeadingSign);
        //        this.Name = name;
        //        this.Surname = surname;
        //        this.EarnedVacation = int.Parse(earnedvac);
        //        this.Salary = int.Parse(salary);
        //        this.Branch = branch;
        //        this.Department = department;
        //        this.YearsWorked = int.Parse(years);
        //        this.WantsToAddVacations = bool.Parse(want);
        //    }
        //    catch (Exception e)
        //    {
        //        error = e.Message;
        //    }
        //}

        //returning string instead of list and try to put it on the screen to check whether function works properly or not

        // public ComingTextModel ReadText() { }

    }
}