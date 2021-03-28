using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class AccountDTO
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<int> ParentAccID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public CategoryDTO Category { get; set; }
        public TypeDTO Type { get; set; }
    }
   
}