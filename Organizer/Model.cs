using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Organizer
{
  
        public class NotesContext : DbContext
        {
            public DbSet<Notatka> Notes { get; set; }
            public DbSet<Wydarzenie> Events { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Filename=Organizer.db");
            }
        }

        public class Notatka
        {
        [Key]
        public int NoteId { get; set; }

            public string NoteText { get; set; }
            public string NoteTitle { get; set; }

        }

        public class Wydarzenie
        {
        [Key]
        public int EventId { get; set; }
            public string EventTitle { get; set; }
            public string EventDate { get; set; }
            public string EventText { get; set; }

         }
}