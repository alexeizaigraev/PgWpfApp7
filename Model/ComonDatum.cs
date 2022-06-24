using System;
using System.Collections.Generic;

namespace PgWpfApp7
{
    public partial class ComonDatum
    {
        public string Partner { get; set; } = null!;
        public string? Code { get; set; }
        public string KassOwner { get; set; } = null!;
        public string? Email { get; set; }
        public string Gdrive { get; set; } = null!;
        public string Regime { get; set; } = null!;
        public string TermOwner { get; set; } = null!;
        public string TermShablon { get; set; } = null!;
        public string SoftVersion { get; set; } = null!;
        public string LimitKass { get; set; } = null!;
    }
}
