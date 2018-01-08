using System;
using System.Collections.Generic;
using System.Text;

namespace Basics.Application.ADtos
{
    public class BaseDtos
    {
        public string Id { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
    }
}
