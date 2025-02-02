using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace BE.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public DateTime DoB { get; set; } = DateTime.MinValue;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? Specialization { get; set; }
        public DateTime? StartDate { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
