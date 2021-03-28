
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApplication1
{
 
    
    public partial class AccountsCategory
    {
        public AccountsCategory()
        {
            this.Accounts = new HashSet<Account>();
        }
    
        public int ID { get; set; }
        public string CategoryName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
