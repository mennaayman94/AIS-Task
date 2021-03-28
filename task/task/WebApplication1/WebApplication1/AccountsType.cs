using System;
using System.Collections.Generic;

namespace WebApplication1
{
    
    
    public partial class AccountsType
    {
        public AccountsType()
        {
            this.Accounts = new HashSet<Account>();
        }
    
        public int ID { get; set; }
        public string TypeName { get; set; }
    
        public virtual ICollection<Account> Accounts { get; set; }

        
    }
}
