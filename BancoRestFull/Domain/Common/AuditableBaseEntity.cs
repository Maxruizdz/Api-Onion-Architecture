﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        public virtual int id { get; set; }

        public string CreatedBy { get; set; }


        public DateTime Create { get; set; }


        public string LastModifiedBy { get; set; }


        public DateTime? LastModified { get; set; }
    }
}
