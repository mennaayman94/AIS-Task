using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
   
    
    public partial class Accounts_DBEntities : DbContext
    {
        public Accounts_DBEntities()
            : base("name=Accounts_DBEntities")
        {
        }
       

        //public async Task SaveChangesAsync(string userId)
        //{

        //    // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
        //    foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified))
        //    {
        //        // For each changed record, get the audit record entries and add them
        //        foreach (AccountsLog x in GetAuditRecordsForChange(ent, ""))
        //        {
        //            this.AccountsLogs.Add(x);
        //        }
        //    }

        //    // Call the original SaveChanges(), which will save both the changes made and the audit records
        //    await base.SaveChangesAsync();
        //}

        //private List<AccountsLog> GetAuditRecordsForChange(DbEntityEntry dbEntry, string userId)
        //{
        //    List<AccountsLog> result = new List<AccountsLog>();

        //    DateTime changeTime = DateTime.Now;

        //    // Get the Table() attribute, if one exists
        //    TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

        //    // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
        //    string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

        //    // Get primary key value (If you have more than one key column, this will need to be adjusted)
        //    string keyName = dbEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;

        //    if (dbEntry.State == EntityState.Added)
        //    {
        //        // For Inserts, just add the whole record
        //        // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()
        //        result.Add(new AccountsLog()
        //        {
                    
        //            EventType = "A", // Added
        //            TableName = tableName,
        //            RecordID = dbEntry.CurrentValues.GetValue<object>(keyName).ToString(),  // Again, adjust this if you have a multi-column key
        //            ColumnName = "*ALL",    // Or make it nullable, whatever you want
        //            Created_date = changeTime
        //        }
        //            );
        //    }
        //    else if (dbEntry.State == EntityState.Deleted)
        //    {
        //        // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
        //        result.Add(new AccountsLog()
        //        {
        //            EventType = "D", // Deleted
        //            TableName = tableName,
        //            RecordID = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
        //            ColumnName = "*ALL",
        //            Created_date = changeTime
        //        }
        //            );
        //    }
        //    else if (dbEntry.State == EntityState.Modified)
        //    {
        //        foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
        //        {
        //            // For updates, we only want to capture the columns that actually changed
        //            if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
        //            {
        //                result.Add(new AccountsLog()
        //                {
                            
        //                    EventType = "M",    // Modified
        //                    TableName = tableName,
        //                    RecordID = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
        //                    ColumnName = propertyName,
        //                    OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
        //                    NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString(),
        //                    Created_date = changeTime
        //                }
        //                    );
        //            }
        //        }
        //    }
        //    // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

        //    return result;
        //}
        public DbSet<AccountsLog> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountsCategory> AccountsCategories { get; set; }
        public virtual DbSet<AccountsLog> AccountsLogs { get; set; }
        public virtual DbSet<AccountsType> AccountsTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
