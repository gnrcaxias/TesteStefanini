﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Application.Dto
{
    public class UserRoleDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}
