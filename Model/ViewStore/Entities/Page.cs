using System;

namespace Model.ViewStore.Entities
{
    public class Page
    {
        public Guid Id { get; set; }
        public string PageName { get; set; }
        public string PageData { get; set; }
    }
}

