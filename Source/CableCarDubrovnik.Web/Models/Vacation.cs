﻿using System;

namespace CableCarDubrovnik.Web.Models.Models
{
    public class Vacation
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public Vacation(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
}