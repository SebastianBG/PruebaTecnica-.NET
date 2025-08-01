using System;
using System.ComponentModel.DataAnnotations;

namespace CatGiphyApp.Models
{
    public class SearchHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime SearchDate { get; set; }
        public string CatFact { get; set; } = string.Empty;
        public string QueryWords { get; set; } = string.Empty;
        public string GifUrl { get; set; } = string.Empty;
    }
}
