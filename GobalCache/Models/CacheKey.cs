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
            => string.Format("{0}_{1}_{2}_{3}", BookingSiteId, Method, DictionaryName, Key);
    }
}
