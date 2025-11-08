using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
    public class BaseData
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdateAt { get; set; } = DateTimeOffset.Now;
    }
}
