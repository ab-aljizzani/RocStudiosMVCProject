using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RocStudiosMVCProject.Models;

namespace RocStudiosMVCProject.ViewModels
{
    public class AllModels
    {
        public IEnumerable<About> about { get; set; }
        public IEnumerable<Clients> client { get; set; }
        public IEnumerable<Portfolio> portfolio { get; set; }
        public IEnumerable<Services>services { get; set; }
        public IEnumerable<Team> team { get; set; }
        public IEnumerable<Order> orders { get; set; }
        public Order dborder { get; set; }
        public Services dbserv { get; set; }
    }
}