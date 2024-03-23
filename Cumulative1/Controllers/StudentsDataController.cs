using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using Cumulative1.Models;
using MySql.Data.MySqlClient;

namespace Cumulative1.Controllers
{
    ///<summary>
    /// This controller will be returning a list of the student information from the MySql Database
    /// </summary>
    /// <example>
    /// GET: api/StudentData/StudentInfo
    /// </example>
    /// <returns>
    /// complete list of student info
    /// </returns>
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]

        public IEnumerable<Student> ListStudent() //student Model connection
        {

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();  //database connection: ON

            MySqlCommand cmd = Conn.CreateCommand();
            //MySQL command declaration
            cmd.CommandText = "Select * from students";

            MySqlDataReader resultSet = cmd.ExecuteReader();

            //creation of a list to store the students' info
            List<Student> StudentInfo = new List<Student> { };

            while (resultSet.Read())
            {

                int StudentId = (int)resultSet["studentid"];
                string StudentFname = resultSet["studentfname"].ToString();
                string StudentLname = resultSet["studentlname"].ToString();
                string StudentNumber = resultSet["studentnumber"].ToString();
                string EnrolDate = resultSet["enroldate"].ToString();
                

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
              

                StudentInfo.Add(NewStudent);
            }
            //database connection: OFF
            Conn.Close();

            return StudentInfo;


        }

        /// <summary>
        /// Finds a student using the student's ID as an input
        /// </summary>
        [HttpGet]
        public Student FindStudent(int IDinput)
        {
            Student NewStudent = new Student();
            //creates the connection to the school database
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open(); //connection: ON

            MySqlCommand cmd = Conn.CreateCommand();
            //MySQL command to get the specified student from the ID given
            cmd.CommandText = "select * from students where studentid = " + IDinput;

            MySqlDataReader resultSet = cmd.ExecuteReader();

            while (resultSet.Read())
            {
                int StudentId = (int)resultSet["studentid"];
                string StudentFname = resultSet["studentfname"].ToString();
                string StudentLname = resultSet["studentlname"].ToString();
                string StudentNumber = resultSet["studentnumber"].ToString();
                string EnrolDate = resultSet["enroldate"].ToString();


                
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;
            }

            Conn.Close();
            return NewStudent;




        }





    }

}
