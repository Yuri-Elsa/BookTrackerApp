using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTrackerApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Judul buku wajib diisi")]
        [StringLength(200, ErrorMessage = "Judul maksimal 200 karakter")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama penulis wajib diisi")]
        [StringLength(150, ErrorMessage = "Nama penulis maksimal 150 karakter")]
        public string Author { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 999999999999.99, ErrorMessage = "Harga harus di antara Rp 0 dan Rp 999.999.999.999")]
        public decimal Price { get; set; }

        public bool IsRead { get; set; } = false;
    }
}