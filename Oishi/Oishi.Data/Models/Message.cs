using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int AdvertisementId { get; set; }

        public int SenderUserAccountId { get; set; }

        public int ReceiverUserAccountId { get; set; }

        [StringLength(5000)]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        
        public Advertisement Advertisement { get; set; }
        public UserAccount SenderUserAccount { get; set; }
        public UserAccount ReceiverUserAccount { get; set; }

    }
}
