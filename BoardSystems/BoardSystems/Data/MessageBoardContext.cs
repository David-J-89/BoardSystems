using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardSystems.Data
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext() 
            : base("DefaultConnection")
        {

        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }
}