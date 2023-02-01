using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Core.Domain
{
    public abstract  class Entity<T>
    {
        public T Id { get; set; } = default!;
    }
}
