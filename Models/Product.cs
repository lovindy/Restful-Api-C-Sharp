using System;

namespace MyRestApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        // Navigation property
        public User User { get; set; }
    }
}