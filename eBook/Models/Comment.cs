using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBook.Models
{
    public class Comment
    {
        public Comment()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Comment ID")]
        public int CommentId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [ReadOnly(true)]
        public int PostId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Site { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3)]
        public string Body { get; set; }

        [ForeignKey("PostId")]
        public virtual Post RelatedPost { get; set; }
    }
}
}