﻿namespace THA.API.Endpoints.Persons.Requests
{
    public sealed class RecordBirthRequest
    {
        public Guid PersonId { get; set; }
        public DateTime BirthDate { get; set; }
        public required string BirthLocation { get; set; }
    }
}
