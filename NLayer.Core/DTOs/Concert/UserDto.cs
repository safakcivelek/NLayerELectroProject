using NLayer.Core.DTOs.Abstract;
using NLayer.Core.Entities.Concert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.Concert
{
    public class UserDto : GetBaseDto
    {
        public User User { get; set; }
    }
}
