using AspEntity.Abstract;
using System.ComponentModel.DataAnnotations;

namespace AspEntity.Concrete
{
    public class CommingTextEntities:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int? RemainingVacation { get; set; }

        [StringLength(30)]
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