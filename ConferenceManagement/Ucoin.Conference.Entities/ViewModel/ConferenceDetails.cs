﻿namespace Ucoin.Conference.Entities.ViewModel
{
    using System;

    public class ConferenceDetails
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Tagline { get; set; }

        public string TwitterSearch { get; set; }

        public DateTime StartDate { get; set; }
    }
}
