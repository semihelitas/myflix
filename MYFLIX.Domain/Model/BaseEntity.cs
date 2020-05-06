using System;
using System.ComponentModel.DataAnnotations;

namespace MYFLIX.Data.Model
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
