using System;
using System.Collections.Generic;

namespace PgWpfApp7
{
    public partial class Logi
    {
        public int Id { get; set; }
        public string Department { get; set; } = null!;
        public string? Termial { get; set; }
        public string SerialNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Datalog { get; set; } = null!;
        public string Kind { get; set; } = null!;
    }
}
