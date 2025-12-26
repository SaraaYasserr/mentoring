using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace WebPro1
{
    internal class Program
    {
        static string connectionString =
        "Server=Sarsora;Database=WebPro1;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------- Web Example --------");
                Console.WriteLine("1/Sign up");
                Console.WriteLine("2/Login");
                Console.WriteLine("3/Exit");
                Console.WriteLine("Choose ");
                int choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                    signup();
                else if (choose == 2)
                    Login();
                else break;
            }


        }
        static void signup()
        {

            Console.Write("Enter your id: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your name ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter username ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your Email ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter Password ");
            string passwordd = Console.ReadLine();

           

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
           

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Users (id, namee, UserName, email, passwordd) VALUES (@i, @n, @u, @e, @p)", conn);

            cmd.Parameters.AddWithValue("@i", id);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@e", email);
            cmd.Parameters.AddWithValue("@p", passwordd);


            cmd.ExecuteNonQuery();


            Console.WriteLine(" Account created successfully!");
        }

        static void Login()
        {
            Console.WriteLine("Enter user name ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password ");
            string password = Console.ReadLine();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(
            "SELECT passwordd FROM users WHERE username=@u", conn);
            cmd.Parameters.AddWithValue("@u", username);

            var result = cmd.ExecuteScalar();

            if (result == null)
            {
                Console.WriteLine("User not found!");
                return;
            }

            if (result.ToString() == password)
                Console.WriteLine("Login successful!");
            else
                Console.WriteLine("Wrong password!");

        }
    }
}

