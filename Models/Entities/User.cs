using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Case_API.Models.Entities
{
    public class User
    {

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public string? NoHP { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDt { get; set; }

        public DateTime? DeletedDt { get; set; }

    }
}
