using System.ComponentModel.DataAnnotations;

namespace NewApi.Models
{
    public class AddTodoRequest
    {
        
        public long Phone { get; set; }
        public string FullName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Item { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ExpiresOn { get; set; }

    }
}
