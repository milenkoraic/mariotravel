﻿using EnsureThat;

namespace DubrovnikTours.Web.Models.Tour
{
    public class TourTimeViewModel
    {
        public TourTimeViewModel(string startAt)
        {
            StartAt = EnsureArg.IsNotNullOrEmpty(startAt, nameof(startAt));
        }

        public string StartAt { get; }
    }
}