using BankData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankData
{
    public interface IBankContext: IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Operation> Operations { get; set; }
        DbSet<Card> Cards { get; set; }

        int SaveChanges();
    }
}
