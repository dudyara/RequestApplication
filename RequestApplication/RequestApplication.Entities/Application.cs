﻿namespace RequestApplication.Entities
{
    public class Application : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Request> Requests { get;set; } = new();
    }
}
