using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace fitnessdatabase.Database
{
    public class ReadData : IReadAllData
    {

        public List<Exercise> GetAllExercises()
        {
            List<Exercise> allExercises = new List<Exercise>();

            string cs = @"URI=file:C:\Users\hunterbrooks\Desktop\FALL2023\MIS 321\Projects\MIS321_PA4\exercisesdets.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM exercises";
            using var cmd = new SQLiteCommand(stm,con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allExercises.Add(new Exercise(){Id=rdr.GetInt32(0), Workout=rdr.GetString(1), Distance=rdr.GetDouble(2), Date=rdr.GetDateTime(3)});
            }
            return allExercises;
        }
    }


}