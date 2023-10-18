using System.Data.Entity;

namespace HospitalSystemManagement.Model
{
    public class DataContext:DbContext
    {
        public DataContext():base("HospitalManagementSystem") { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<UserAdmin> Users { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<MedicalHistory>MedicalHistories { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOptional<Floor>(s => s.Floor)
                .WithMany()
                .WillCascadeOnDelete(true);
        }
    }
}
