namespace GobalCache.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CacheKey
    {
        [Required]
        public int BookingSiteId { get; set; }
        [Required]
        public string? Method { get; set; }
        [Required]
        public string? Prefix { get; set; }
        [Required]
        public string? InstanceId { get; set; }
        [Required]
        public int LifeTimeMinutes { get; set; }
    }
}
