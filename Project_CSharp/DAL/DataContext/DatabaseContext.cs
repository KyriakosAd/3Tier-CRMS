using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();

                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                
                DatabaseOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }
        
        public static OptionsBuild Options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //DbSets [Entities]
        public DbSet<User> Users { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<TeacherLecture> TeacherLectures { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAvailability> RoomAvailabilities { get; set; }

        public DbSet<SubRequest> SubRequests { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationships
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne()
                .HasForeignKey<Teacher>(t => t.User_ID);

            modelBuilder.Entity<TeacherLecture>()
                .HasKey(tl => new { tl.Teacher_ID, tl.Lecture_ID });

            modelBuilder.Entity<TeacherLecture>()
                .HasOne(tl => tl.Teacher)
                .WithMany()
                .HasForeignKey(tl => tl.Teacher_ID);

            modelBuilder.Entity<TeacherLecture>()
                .HasOne(tl => tl.Lecture)
                .WithMany()
                .HasForeignKey(tl => tl.Lecture_ID);

            modelBuilder.Entity<RoomAvailability>()
                .HasOne(ra => ra.Room)
                .WithMany()
                .HasForeignKey(ra => ra.Room_ID);

            modelBuilder.Entity<SubRequest>()
                .HasOne(sr => sr.Reservation)
                .WithMany()
                .HasForeignKey(sr => sr.Reservation_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubRequest>()
                .HasOne(sr => sr.Room)
                .WithMany()
                .HasForeignKey(sr => sr.Room_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(res => res.Room)
                .WithMany()
                .HasForeignKey(res => res.Room_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}