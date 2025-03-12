﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public sealed class PerformanceLog
    {
        public int Id { get; set; }
        public string MethodName { get; set; } = null!;
        public DateTime StatingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int TransactionTimeInSeconds { get; set; }
        public int TransactionTimeInMilliseconds { get; set; }
    }
}
