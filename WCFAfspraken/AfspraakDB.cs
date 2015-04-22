using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WCFAfspraken
{
    public class AfspraakDB  
    {
        public AfspraakDB()
        {

        }

        public List<Afspraak> GetAll()
        {
            List<Afspraak> list = new List<Afspraak>();
            string sql = "SELECT Afspraken.*, Cursisten.*, Trajectbegeleiders.* FROM Afspraken " +
                        "INNER JOIN Cursisten ON Afspraken.CursistId=Cursisten.CursistId " +
                        "INNER JOIN Trajectbegeleiders ON Afspraken.TBid=Trajectbegeleiders.TBid";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Afspraak a = new Afspraak();
                        Cursist c = new Cursist();
                        TrajectBegeleider t = new TrajectBegeleider();

                        t.TBid = dr["TBid"].ToString();
                        t.Naam = dr[13].ToString();
                        t.Voornaam = dr[14].ToString();

                        c.CursistId = dr["CursistId"].ToString();
                        c.Naam = dr[9].ToString();
                        c.Voornaam = dr[10].ToString();

                        a.Id = Convert.ToInt32(dr[0]);
                        a.StartUur = Convert.ToDateTime(dr["StartUur"]);
                        a.StopUur = Convert.ToDateTime(dr["StopUur"]);
                        a.Comments = dr["Comments"].ToString();
                        a.Vastgelegd = Convert.ToBoolean(dr["Vastgelegd"]);
                        a.cursist = c;
                        a.TB = t;

                        list.Add(a);
                    }
                }
            }
            return list;
        }

        public List<Afspraak> GetInvites()
        {
            List<Afspraak> list = new List<Afspraak>();
            string sql = "SELECT Afspraken.*, Cursisten.*, Trajectbegeleiders.* FROM Afspraken " +
                        "INNER JOIN Cursisten ON Afspraken.CursistId=Cursisten.CursistId " +
                        "INNER JOIN Trajectbegeleiders ON Afspraken.TBid=Trajectbegeleiders.TBid " +
                        "WHERE Afspraken.Vastgelegd = 0";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Afspraak a = new Afspraak();
                        Cursist c = new Cursist();
                        TrajectBegeleider t = new TrajectBegeleider();

                        t.TBid = dr["TBid"].ToString();
                        t.Naam = dr[13].ToString();
                        t.Voornaam = dr[14].ToString();

                        c.CursistId = dr["CursistId"].ToString();
                        c.Naam = dr[9].ToString();
                        c.Voornaam = dr[10].ToString();

                        a.Id = Convert.ToInt32(dr[0]);
                        a.StartUur = Convert.ToDateTime(dr["StartUur"]);
                        a.StopUur = Convert.ToDateTime(dr["StopUur"]);
                        a.Comments = dr["Comments"].ToString();
                        a.Vastgelegd = Convert.ToBoolean(dr["Vastgelegd"]);
                        a.cursist = c;
                        a.TB = t;

                        list.Add(a);
                    }
                }
            }
            return list;
        }

        public List<Afspraak> GetAfspraken()
        {
            List<Afspraak> list = new List<Afspraak>();
            string sql = "SELECT Afspraken.*, Cursisten.*, Trajectbegeleiders.* FROM Afspraken " +
                        "INNER JOIN Cursisten ON Afspraken.CursistId=Cursisten.CursistId " +
                        "INNER JOIN Trajectbegeleiders ON Afspraken.TBid=Trajectbegeleiders.TBid " +
                        "WHERE Afspraken.Vastgelegd = 1";

            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Afspraak a = new Afspraak();
                        Cursist c = new Cursist();
                        TrajectBegeleider t = new TrajectBegeleider();

                        t.TBid = dr["TBid"].ToString();
                        t.Naam = dr[13].ToString();
                        t.Voornaam = dr[14].ToString();

                        c.CursistId = dr["CursistId"].ToString();
                        c.Naam = dr[9].ToString();
                        c.Voornaam = dr[10].ToString();

                        a.Id = Convert.ToInt32(dr[0]);
                        a.StartUur = Convert.ToDateTime(dr["StartUur"]);
                        a.StopUur = Convert.ToDateTime(dr["StopUur"]);
                        a.Comments = dr["Comments"].ToString();
                        a.Vastgelegd = Convert.ToBoolean(dr["Vastgelegd"]);
                        a.cursist = c;
                        a.TB = t;

                        list.Add(a);
                    }
                }
            }
            return list;
        }

         private string GetConnectionString()
        {
            return "Data Source=RODERIK-PC\\SQLEXPRESS;Initial Catalog=CursistAfspraken;Integrated Security=True";
        }
    }
}