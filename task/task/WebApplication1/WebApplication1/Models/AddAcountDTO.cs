using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AddAcountDTO
    {
        
        public string CustomerName { get; set; }
        public Nullable<double> Balance { get; set; }
        public Nullable<int> ParentAccID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> CategoryID { get; set; }
       

    }
}