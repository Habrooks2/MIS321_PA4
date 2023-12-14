using System;
using System.Data.SQLite;
using System.Collections.Generic;
using fitnessdatabase.Database;

namespace fitnessdatabase{

    class Program{

        static void Main(string[] args){

            //string cs = @"URI=file:C:\Users\hunterbrooks\Desktop\FALL2023\MIS 321\Projects\MIS321_PA4\exercisesdets.db";

            //using var con = new SQLiteConnection(cs);
            //con.Open();

            //using var cmd = new SQLiteCommand(con);
            
            SaveData saveObject = new SaveData();
            saveObject.SeedData();

            IReadAllData readObject = new ReadData();
            List<Exercise> allexercises = readObject.GetAllExercises();

            foreach(Exercise exercise in allexercises){
                Console.WriteLine(exercise.ToString());
            }
            allexercises[2].Distance = 12.3;
            saveObject.SaveExercise(allexercises[2]);
           
            Console.WriteLine("After Update");
            foreach(Exercise exercise in allexercises){
                Console.WriteLine(exercise.ToString());
            }



        }

    }

}