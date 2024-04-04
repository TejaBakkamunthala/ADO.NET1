using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SQLConnectionPogram1
{
    internal class Program
    {
         

        static void Main(string[] args)
        {

            string connectionString = @"Data Source=LAPTOP-9LF56231\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                  
                conn.Open();
                Console.WriteLine("Connection establishedd");

                string answer;
                do
                {
                    Console.WriteLine("Select from the option below\n 1.CREATE \n 2.RETREIVE \n 3.UPDATE \n 4.DELETE ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            //INSERT DATA
                            Console.WriteLine("Enter dept no");
                            int DEPTNO = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Department name ");
                            string DNAME = Console.ReadLine();

                            Console.WriteLine("Enter location");
                            string LOCATION = Console.ReadLine();

                            string insertQuery = "INSERT INTO DEPARTMENT(DEPTNO,DNAME,LOCATION) VALUES(" + DEPTNO + ",'" + DNAME + "','" + LOCATION + "')";
                            SqlCommand cmd1 = new SqlCommand(insertQuery, conn);

                            cmd1.ExecuteNonQuery();

                            Console.WriteLine("Data is succesfully inserted into table");
                            break;


                        //SELECT QUERY
                        case 2:
                            string displayqQuery = "select * from DEPARTMENT";

                            SqlCommand cmd2 = new SqlCommand(displayqQuery, conn);

                            SqlDataReader reader = cmd2.ExecuteReader();

                            while (reader.Read())
                            {
                                Console.Write("DEPTID " + reader.GetValue(0).ToString() + " ");
                                Console.Write("DNAME " + reader.GetValue(1).ToString() + " ");
                                Console.Write("LOACTION " + reader.GetValue(2).ToString() + " ");
                                Console.WriteLine();
                            }

                            reader.Close();
                            break;

                        case 3:
                            // UPDATE
                            Console.WriteLine("For Updation");

                            //   int DEPTNO;
                            // string LOCATION;

                            Console.WriteLine("Enter DEPTNO that you would like to be  updated");
                            DEPTNO = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the location to be updated");
                            LOCATION = Console.ReadLine();

                            string updateQuery = "UPDATE DEPARTMENT SET LOCATION='" + LOCATION + "' WHERE DEPTNO=" + DEPTNO + " ";

                            SqlCommand cmd3 = new SqlCommand(updateQuery, conn);
                            cmd3.ExecuteNonQuery();


                            Console.WriteLine("UPDATED SUCCESFULLY IN THE TABLE");

                            break;

                        case 4:
                            Console.WriteLine("DELETED QUERY");

                            // int DEPTNO;
                            Console.WriteLine("ENTER THE DELTED DEPTNO");
                            DEPTNO = int.Parse(Console.ReadLine());

                            string deleteQuery = "DELETE FROM DEPARTMENT WHERE DEPTNO=" + DEPTNO + " ";

                            SqlCommand cmd4 = new SqlCommand(deleteQuery, conn);
                            cmd4.ExecuteNonQuery();

                            Console.WriteLine("Deleted " + DEPTNO + " successfully");

                            break;

                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    Console.WriteLine("Do you wnat to continue yes or no");
                    answer = Console.ReadLine();
                }

                while (answer != "no");

              
            }


            

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }



        }
   

    }
}
