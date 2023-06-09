﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicentaSfranciog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace LicentaSfranciog.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    internal string Nume { get; set; }
    
    internal string Prenume { get; set; }
    public virtual ICollection<Eveniment> Evenimente { get; set; }
}

