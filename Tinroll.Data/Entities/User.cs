using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tinroll.Data.Entities {
    public class User
    {
        public int UserId {get;set;}
        public string UserName {get;set;}
        
    }
}