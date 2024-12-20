﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JobCandidateHub.API.Contracts.Responses
{
    public class CandidateResponse
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
