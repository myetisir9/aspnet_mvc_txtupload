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



    }
}