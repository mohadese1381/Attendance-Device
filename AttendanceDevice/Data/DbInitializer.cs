using AttendanceDevice.Models;

namespace AttendanceDevice.Data
{
    public class DbInitializer
    {
        //used to put some datas in created tables
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //create context reference
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //Checking whether create database or it has already been created 
                context.Database.EnsureCreated();

                if (!context.Person.Any())
                {
                    context.Person.AddRange(new List<Person>
                    {
                        new Person(){ PersonId = 1, Name = "Zahra", LastName = "Motamed"
                                    , NationalCode ="443", IdentityCode =null , PictureURL = ""},
                        new Person(){ PersonId = 2, Name = "Mahdi", LastName = "Akhoondy"
                                    , NationalCode ="444", IdentityCode =null, PictureURL = ""}
                    });
                    context.SaveChanges();
                }

                if (!context.Attendance.Any())
                {
                    context.Attendance.AddRange(new List<Attendance>
                    {
                        new Attendance(){AttendanceId = 1, PersonId = 1, Day = DayOfWeek.Saturday, EntryTime = new DateTime(2019,05,09,9,15,0), ExitTime = new DateTime(2019,05,09,18,15,0)},
                                   
                        new Attendance(){AttendanceId = 2, PersonId = 2, Day = DayOfWeek.Sunday, EntryTime = new DateTime(2019,05,10,8,15,0), ExitTime = new DateTime(2019,05,10,19,15,0) }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}