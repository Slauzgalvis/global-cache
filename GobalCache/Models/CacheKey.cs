namespace GobalCache.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CacheKey
    {
        [Required]
        public int BookingSiteId { get; set; }
        [Required]
        [StringLength(2)]
        public string Method { get; set; } = string.Empty;
        [Required]
        public string DictionaryName { get; set; } = string.Empty;
        [Required]
        public string Key { get; set; } = string.Empty;
        public string GetRedisKey()
            => $"{BookingSiteId}_{Method}_{DictionaryName}_{Key}";
    }
}
