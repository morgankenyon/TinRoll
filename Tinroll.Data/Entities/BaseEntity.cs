using System;

namespace Tinroll.Data.Entities 
{
    public class BaseEntity 
    {
        public DateTime CreatedDate {get;set;}
        public DateTime ModifiedDate {get;set;}
        public string ModifiedBy {get;set;}
    }
}