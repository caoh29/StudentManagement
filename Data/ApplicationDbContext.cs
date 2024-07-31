using Microsoft.EntityFrameworkCore;
using Npgsql;
using StudentManagement.Models;

namespace StudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //public DbSet<Student> Students { get; set; }

        public List<Student> GetStudents()
        {
            List<Student> dataList = new List<Student>();

            using (NpgsqlConnection conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM students", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student data = new Student
                            {
                                // Assuming YourModel has properties that match your table columns
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Age = reader.GetInt32(reader.GetOrdinal("age")),
                                Course = reader.GetString(reader.GetOrdinal("course"))
                                // Add other properties here
                            };
                            dataList.Add(data);
                        }
                    }
                }
            }
            return dataList;
        }
    }
}
