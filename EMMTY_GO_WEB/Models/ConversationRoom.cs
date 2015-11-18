
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMMTY_GO_WEB.Models
{
    public class ConversationRoom
    {
        [Key]
        public string RoomName { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
