using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
  
namespace ToDo.Models.EF
{
    public class Todolist
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Task Name")]
        [Required(ErrorMessage = "This field is required.")]
        public string Task { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Priority { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = string.Empty;

        [DisplayName("Date Created")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime DateCreated { get; set; }
        //public string DateCreatedDateOnly => DateCreated.ToString("MM/dd/yyyy");
    }
}
