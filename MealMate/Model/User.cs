﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MealMate.Model
{
    public class User
    {   
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
