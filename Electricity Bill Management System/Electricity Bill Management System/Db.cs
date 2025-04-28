using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Electricity_Bill_Management_System
{
    internal class Db
    {
        public static bool HaveUser(User us)
        {
            bool flag = false;
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "select userid from users where userid=@uid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@uid", us.UserID);

                        SqlDataReader rr = cmd.ExecuteReader();
                        while (rr.Read())
                        {
                            if (us.UserID == (int)rr[0])
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return flag;
        }
        public static void AddUser(User us)
        {
            int userid = 0;
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"insert into users (username,phase,type,address)
                        values(@uname,@uphase,@utype,@uaddress);select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@uname", us.UserName);
                        cmd.Parameters.AddWithValue("@uphase", us.ConnectionPhase);
                        cmd.Parameters.AddWithValue("@utype", us.ConnectionType);
                        cmd.Parameters.AddWithValue("@uaddress", us.Address);

                        object uid = cmd.ExecuteScalar();
                        userid = Convert.ToInt32(uid);
                        us.UserID = userid;
                    }
                    Console.WriteLine("user successfully added");
                    Console.WriteLine("user id is " + us.UserID);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void DeleteUser(User us)
        {
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query1= "delete from bill where userid = @uid";
                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {
                        cmd1.Parameters.AddWithValue("@uid", us.UserID);

                        cmd1.ExecuteNonQuery();
                    }

                    string query2 = "delete from users where userid=@uid";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {

                        cmd2.Parameters.AddWithValue("@uid", us.UserID);

                        cmd2.ExecuteNonQuery();
                    }

                    Console.WriteLine("user successfully deleted");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void UpdateUser(User us)
        {
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "update users set username=@uname,phase=@uphase,type=@utype,address=@uaddress where userid=@uid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("@uname", us.UserName);
                        cmd.Parameters.AddWithValue("@uphase", us.ConnectionPhase);
                        cmd.Parameters.AddWithValue("@utype", us.ConnectionType);
                        cmd.Parameters.AddWithValue("@uaddress", us.Address);
                        cmd.Parameters.AddWithValue("@uid", us.UserID);

                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("user successfully added");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void SaveBill(Bill b)
        {
            int billid = 0;
            char phase = ' ';
            char type = ' ';
            int amount = 0;
            int rate = 0;
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query1 = "select phase,type from users where userid=@uid";
                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {

                        cmd1.Parameters.AddWithValue("@uid", b.UserID);
                        SqlDataReader rr = cmd1.ExecuteReader();
                        while (rr.Read())
                        {
                            phase = Convert.ToChar(rr[0]);
                            type = Convert.ToChar(rr[1]);
                        }
                        rr.Close();

                    }
                    if (phase == '1')
                    {
                        rate = rate + 1;
                    }
                    else if (phase == '2')
                    {
                        rate = rate + 3;
                    }
                    else
                    {
                        rate = rate + 5;
                    }
                    if (type == 'D')
                    {
                        rate = rate + 2;
                    }
                    else if (type == '5')
                    {
                        rate = rate + 4;
                    }
                    else
                    {
                        rate = rate + 6;
                    }
                    amount = rate * b.NumberOfUnits;
                    b.Amount = amount;
                    
                    if(IsUserIDBillMonthSame(b))
                    {
                        string query2 = "insert into bill (userid,month,billdate,noofunits,amount) values(@uid,@mon,@dat,@nunits,@amo);select scope_identity()";
                        using (SqlCommand cmd2 = new SqlCommand(query2, con))
                        {

                            cmd2.Parameters.AddWithValue("@uid", b.UserID);
                            cmd2.Parameters.AddWithValue("@mon", b.Month);
                            cmd2.Parameters.AddWithValue("@dat", b.date);
                            cmd2.Parameters.AddWithValue("@nunits", b.NumberOfUnits);
                            cmd2.Parameters.AddWithValue("@amo", b.Amount);

                            object uid = cmd2.ExecuteScalar();
                            billid = Convert.ToInt32(uid);
                            b.BillNo = billid;
                        }
                        Console.WriteLine("bill successfully added");
                        Console.WriteLine("bill id is " + b.BillNo);

                    }
                    else
                    {
                        Console.WriteLine("bill already exists");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static bool IsUserIDBillMonthSame(Bill b)
        {
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "select amount from bill where userid=@uid and month=@umon";
                    using(SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@uid", b.UserID);
                        cmd.Parameters.AddWithValue("@umon", b.Month);

                        SqlDataReader ro = cmd.ExecuteReader();
                        while(ro.Read())
                        {
                            return false;
                        }
                        ro.Close();
                    }
                }
                catch(Exception o)
                {
                    Console.WriteLine(o);
                }
            }
            return true;
        }
        public static void CreateDatabase()
        {
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query1 = "if object_id('dbo.users','U') is null begin create table users(userid int identity(1,1) primary key,username varchar(50),phase varchar(1),type varchar(1),address varchar(100)) end";
                    using (SqlCommand cmd1 = new SqlCommand(query1, con))
                    {
                        cmd1.ExecuteNonQuery();
                    }
                    Console.WriteLine("users successfully created");

                    string query2 = "if object_id('dbo.bill','U') is null begin create table bill(billid int identity(1,1) primary key,userid int foreign key references users(userid),[month] varchar(20),billdate date,noofunits int,amount int,constraint UQ_User_Month unique (userid, [month])) end;";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {

                        cmd2.ExecuteNonQuery();
                    }
                    Console.WriteLine("bill successfully created");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        public static void ShowBill(User us)
        {
            string connectionString = "Data Source=NAVEEN;Initial Catalog=electricity;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string query = "select * from bill where userid=@uid";
                    using(SqlCommand cmd=new SqlCommand(query,con))
                    {
                        cmd.Parameters.AddWithValue("@uid", us.UserID);

                        using (SqlDataReader rr = cmd.ExecuteReader())
                        {
                            Console.WriteLine("billid         " + "userid         " +"month          "+"billdate       " + "noofunits      " + "amount          ");
                            while(rr.Read())
                            {
                                int billid = Convert.ToInt32(rr[0]);
                                int userid = Convert.ToInt32(rr[1]);
                                string month = Convert.ToString(rr[2]);
                                DateTime billdate = Convert.ToDateTime(rr[3]);
                                int noofunits= Convert.ToInt32(rr[4]);
                                int amount= Convert.ToInt32(rr[5]);
                                Console.WriteLine($"{billid,-15}{userid,-15}{month,-15}{billdate.ToShortDateString(),-15}{noofunits,-15}{amount,-15}");
                            }
                        }
                    }
                }
                catch(Exception o)
                {
                    Console.WriteLine(o);
                }
            }
        }
    }
}
