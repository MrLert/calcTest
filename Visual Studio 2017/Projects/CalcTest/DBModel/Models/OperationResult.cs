﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCalcNew.Managers
{
    /// <summary>
    /// Результат выполнения операции
    /// </summary>
    [Table("OperationResult")]
    public class OperationResult
    {
        public int Id { get; set; }
        public string OperationName { get; set; }
        public string Arguments { get; set; }
        public double? Result { get; set; }
        /// <summary>
        /// Продолжительность выполнения операции
        /// </summary>
        public long ExecutionTime { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}