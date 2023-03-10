namespace iums_ipe_api_last.Model
{
    public class CustomerModel
    {
        public int P_PeriodId { get; set; }
        public int P_UserId { get; set; }
        //public int P_interval_id { get; set; }
        //public int P_ALL { get; set; }
        //public int P_DEGREE_TYPE { get; set; }
    }

    public class OutputModel
    {
        //public string PERIOD_NAME { get; set; }
        //public string X_TIMETABLE_PERIOD_ID { get; set; }
        
        public string? WEEKDAY { get; set; }
        /*public string? StartDate { get; set; }
        public string? EndDate { get; set; }*/
        public TimeTableAttributes? time_7_8 { get; set; }
        public TimeTableAttributes? time_9_10 { get; set; }
        public TimeTableAttributes? time_12_13 { get; set; }
/*        public TimeTableAttributes? time_13_14 { get; set; }
        public TimeTableAttributes? time_15_16 { get; set; }
        public TimeTableAttributes? time_19_20 { get; set; }*/
    }
}

