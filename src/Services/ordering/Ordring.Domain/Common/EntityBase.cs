using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordring.Domain.Common
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifyedBy { get; set; }

        public DateTime? LastModifyedDate { get; set; }

    }
}
