
using HttpClientExternalApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HttpClientExternalApi.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        public string imageUrl { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string contactNumber { get; set; }
        public int age { get; set; }
        public string dob { get; set; }
        public float salary { get; set; }
        public string address { get; set; }
    }
}
