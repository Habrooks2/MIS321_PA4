namespace fitnessdatabase
{
    public class Exercise
    {
        public int Id{get;set;}
        public required string Workout{get;set;}
        public double Distance{get;set;}
        public DateTime Date{get;set;}
        public override string ToString()
        {
            return Id + " " + Workout + " " + Distance + " " + Date.Date.ToString("yyyy-MM-dd");
        }



    }
}