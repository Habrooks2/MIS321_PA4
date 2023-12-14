using System.Data.SQLite;

namespace fitnessdatabase.Database
{
    public class SaveData : ISeedData, ISaveData
    {
        public void SaveExercise(Exercise value)
        {
                    string cs = @"URI=file:C:\Users\hunterbrooks\Desktop\FALL2023\MIS 321\Projects\MIS321_PA4\exercisesdets.db";
                    using var con = new SQLiteConnection(cs);
                    con.Open();

                    using var cmd = new SQLiteCommand(con);

                    cmd.CommandText = @"UPDATE exercises SET id = @id, activity_type = @activity_type, distance = @distance, date_completed= @date
                                        WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id",value.Id);
                    cmd.Parameters.AddWithValue("@activity_type",value.Workout);
                    cmd.Parameters.AddWithValue("@distance",value.Distance);
                    cmd.Parameters.AddWithValue("@date",value.Date);

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
        }

        public void SeedData(){
                    string cs = @"URI=file:C:\Users\hunterbrooks\Desktop\FALL2023\MIS 321\Projects\MIS321_PA4\exercisesdets.db";
                    using var con = new SQLiteConnection(cs);
                    con.Open();

                    using var cmd = new SQLiteCommand(con);

                    cmd.CommandText = "DROP TABLE IF EXISTS exercises";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE exercises(id INTEGER PRIMARY KEY, activity_type TEXT, distance REAL, date_completed DATE)";
                    cmd.ExecuteNonQuery();
                    
                    cmd.CommandText = @"INSERT INTO exercises(id, activity_type, distance, date_completed) VALUES (@id, @activity_type, @distance, @date)";
                    cmd.Parameters.AddWithValue("@id","123021");
                    cmd.Parameters.AddWithValue("@activity_type","Cycling");
                    cmd.Parameters.AddWithValue("@distance",12.2);
                    cmd.Parameters.AddWithValue("@date","2023-09-27");

                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
        }           
    
    }
}