using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Weather.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { set; get; }
    }
}
