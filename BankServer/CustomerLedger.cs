using System.Collections.Generic;

namespace BankServer
{
    public static class CustomerLedger
    {
        public static Dictionary<int, double> Ledger { get; } = new Dictionary<int, double>();
    }
}