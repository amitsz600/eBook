﻿using System;
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
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3)]
        public string Body { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Range(1, 5, ErrorMessage = "Rating between 1 to 5")]
        public int Rating { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [ForeignKey("ProductId")]
        public virtual Book RelatedProduct { get; set; }
    }
}
