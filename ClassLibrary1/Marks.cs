using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1 {
    public class Marks {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Subject { get; set; }
        [MaxLength(1)]
        public int Value { get; set; }
        [MaxLength(3)]
        public int Weight { get; set; }
    }
}
