﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.SocityManager.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
