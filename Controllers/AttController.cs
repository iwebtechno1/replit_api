using att_api_ipe.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Globalization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using HtmlAgilityPack;


namespace att_api_ipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttController : ControllerBase
    {
        [Route("GetData")]
        [HttpPost]
        public List<Output> GetData([FromBody] AttModel model)
        {
            var dateStr = model.P_ATTENDANCE_DATE.ToString("yyyy-MM-dd HH:mm:ss");
            List<Output> customers = new List<Output>();
            string constr = @"Data Source=IUMSDemo;Initial Catalog=IPE_LIVE_TEST;User ID=iweb;Password=passwd@1;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "exec getCourseStudentListByTimetablePeriodId @P_TIMETABLE_PERIOD_ID=" + model.P_TIMETABLE_PERIOD_ID + ",@P_ATTENDANCE_DATE='" + dateStr + "',@P_BATCH_ID=" + model.P_BATCH_ID + ",@P_OBJECT_ID='" + model.P_OBJECT_ID + "',@P_CLASS_ID='" + model.P_CLASS_ID + "',@FACULTY_ID='" + model.FACULTY_ID + "',@P_IS_SPECIALIZATION_TT=" + model.P_IS_SPECIALIZATION_TT + "";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Output
                            {
                                student_name = sdr["STUDENT_NAME"].ToString(),
                                roll_number = sdr["RollNumber"].ToString(),
                                //roll_number = sdr["RollNumber"].ToString()
                                /*internal_course = (int?)sdr["@internal_course"],
                                regular_course = (int?)sdr["@regular_course"],
                                admitted = (int?)sdr["@admitted"],
                                class_type = (int?)sdr["@class_type"]*/
                            });
                        }
                    }
                    con.Close();
                }
            }
            return customers;
        }

        // Set the JSON serialization settings to use the correct date format
       // public override void OnActionExecuting(ActionExecutingContext context)
       // {
         //   var serializerSettings = new JsonSerializerSettings
           // {
             //   DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffZ",
               // DateTimeZoneHandling = DateTimeZoneHandling.Utc
            //};
            //var body = context.ActionArguments.FirstOrDefault().Value;
            //var json = JsonConvert.SerializeObject(body, serializerSettings);
            //context.HttpContext.Request.Body = GenerateStreamFromString(json);
            //base.OnActionExecuting(context);
        //}

        // Helper method to convert a string to a stream
        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
