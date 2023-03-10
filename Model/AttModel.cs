namespace att_api_ipe.Model
{
    public class AttModel
    {
        public int P_TIMETABLE_PERIOD_ID { get; set; }
        public DateTime P_ATTENDANCE_DATE { get; set; }
        public string P_BATCH_ID { get; set; }
        public string P_OBJECT_ID { get; set; }
        public string P_CLASS_ID { get; set; }
        public string FACULTY_ID { get; set; }
        public int P_IS_SPECIALIZATION_TT { get; set; }
    }

    public class Output
    {
        public string student_name { get; set; }
        public string roll_number { get; set; }
        public int? regular_course { get; set; }
        public int? admitted { get; set; }
        public int? class_type { get; set; }
    }
}
