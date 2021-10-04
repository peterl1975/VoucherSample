using System;

namespace VoucherSample
{
    public class VoucherObject
    {
        public DateTime ValidDateFrom { get; set; }

        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Approved { get; set; }
    }
}
