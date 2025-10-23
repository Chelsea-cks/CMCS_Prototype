<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assignment_part_2.Models;

namespace Assignment_part_2.Logic
=======
﻿using System.Collections.Generic;

namespace CMCS_Prototype.Models
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
{
    public static class ClaimManager
    {
        public static List<Claim> Claims { get; } = new List<Claim>();

        public static void AddClaim(Claim claim)
        {
            Claims.Add(claim);
        }
<<<<<<< HEAD

        public static void ApproveClaim(Guid id)
        {
            var claim = Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Approved";
            }
        }

        public static void RejectClaim(Guid id)
        {
            var claim = Claims.FirstOrDefault(c => c.Id == id);
            if (claim != null)
            {
                claim.Status = "Rejected";
            }
        }
=======
>>>>>>> 6a6969f1d4f065001ef1b3d9415577ca1af45acc
    }
}
