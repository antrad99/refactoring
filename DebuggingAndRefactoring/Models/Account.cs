using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Models
{
    public class Account
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public double Balance { get; set; } = 0;
    }
}
