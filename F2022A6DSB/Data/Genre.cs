using System.ComponentModel.DataAnnotations;

namespace F2022A6DSB.Data
{
    public class Genre
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}