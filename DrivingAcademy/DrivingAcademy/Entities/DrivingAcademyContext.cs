using Microsoft.EntityFrameworkCore;

namespace DrivingAcademy.Entities
{
    public class DrivingAcademyContext : DbContext

    {
        public DrivingAcademyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> TableStudents => Set<Student>();
        public DbSet<Licence> TableLicences => Set<Licence>();
        public DbSet<Module> TableModules => Set<Module>();
        public DbSet<Lesson> TableLessons => Set<Lesson>();
        public DbSet<InfoDrivingAcademy> TableDetails => Set<InfoDrivingAcademy>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(u => u.Identification).IsUnique();

            modelBuilder.Entity<InfoDrivingAcademy>()
                .HasKey(x => new { x.StudentId, x.LessonId });

            FillData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void FillData(ModelBuilder modelBuilder)
        {
            #region data tipos de licencias
            var A1 = new Licence() { Id = 1, TypeName = "A1" };
            var A2 = new Licence() { Id = 2, TypeName = "A2" };
            var B1 = new Licence() { Id = 3, TypeName = "B1" };
            var B2 = new Licence() { Id = 4, TypeName = "B2" };
            var C1 = new Licence() { Id = 5, TypeName = "C1" };
            var C2 = new Licence() { Id = 6, TypeName = "C2" };

            modelBuilder.Entity<Licence>()
             .HasData(new List<Licence>
             {
                 A1,A2,B1,B2,C1,C2
             });
            #endregion

            #region data modulos
            var adaptacion = new Module() { Id = 1, NameModule = "Adaptación" };
            var etica = new Module() { Id = 2, NameModule = "Ética" };
            var marco_legal = new Module() { Id = 3, NameModule = "Marco Legal" };
            modelBuilder.Entity<Module>()
             .HasData(new List<Module>
             {
                    adaptacion,etica, marco_legal
             });
            #endregion

            #region data clases
            var adaptacion_1 = new Lesson() { Id = 1, NameLesson = "adaptación 1", ModuleId = 1 };
            var adaptacion_2 = new Lesson() { Id = 2, NameLesson = "adaptación 2", ModuleId = 1 };
            var etica_1 = new Lesson() { Id = 3, NameLesson = "Ética 1", ModuleId = 2 };
            var etica_2 = new Lesson() { Id = 4, NameLesson = "Ética 2", ModuleId = 2 };

            modelBuilder.Entity<Lesson>()
             .HasData(new List<Lesson>
             {
                    adaptacion_1,adaptacion_2,etica_1,etica_2
             });
            #endregion

            #region data estudiantes
            var diego = new Student() { Id = 1, Name = "Diego Molina", Age = 23, TypeLicenceId = 1, Identification = "1030692100" };
            var laura = new Student() { Id = 2, Name = "Laura Molina", Age = 25, TypeLicenceId = 2, Identification = "1039139838" };

            modelBuilder.Entity<Student>()
             .HasData(new List<Student>
             {
                    diego,laura
             });
            #endregion

            #region data Detalle
            var detalle_1_1 = new InfoDrivingAcademy() { StudentId = 1, LessonId = 1 };
            var detalle_1_2 = new InfoDrivingAcademy() { StudentId = 1, LessonId = 3 };
            var detalle_2_1 = new InfoDrivingAcademy() { StudentId = 2, LessonId = 2 };
            var detalle_2_2 = new InfoDrivingAcademy() { StudentId = 2, LessonId = 4 };

            modelBuilder.Entity<InfoDrivingAcademy>()
             .HasData(new List<InfoDrivingAcademy>
             {
                    detalle_1_1,detalle_1_2, detalle_2_1, detalle_2_2
             });
            #endregion

        }
    }
}
