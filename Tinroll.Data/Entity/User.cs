using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entity {
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId {get;set;}
        [StringLength(100)]
        public string UserName {get;set;}  
        [StringLength(100)]
        public string Email {get;set;}
        [StringLength(1000)]
        public string Description {get;set;}      
    }
}