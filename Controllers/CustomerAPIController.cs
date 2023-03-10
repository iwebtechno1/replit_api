using HtmlAgilityPack;
using iums_ipe_api_last.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace iums_ipe_api_last.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        [Route("GetCustomers")]
        [HttpPost]
        public List<OutputModel> GetCustomers([FromBody] CustomerModel model)
        {
            List<OutputModel> customers = new List<OutputModel>();
            string constr = @"Data Source=IUMSDemo;Initial Catalog=IPE_LIVE_TEST;User ID=iweb;Password=passwd@1;";
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "EXEC GetTeacherTimetable @PeriodID=" + model.P_PeriodId + ",@UserID=" + model.P_UserId + "";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            string sub_7_8_html = sdr["07:00 - 08:00"].ToString();
                            string sub_9_10_html = sdr["09:00 - 10:00"].ToString();
                            string sub_12_13_html = sdr["12:00 - 13:00"].ToString();
                            /*string sub_13_14_html = sdr["13:00 - 14:00"].ToString();
                            string sub_15_16_html = sdr["15:00 - 16:00"].ToString();
                            string sub_19_20_html = sdr["19:00 - 20:00"].ToString();*/

                            /*List<string> allTimings = new List<string>();
                            allTimings.Add(sub_7_8_html);
                            allTimings.Add(sub_9_10_html);
                            allTimings.Add(sub_12_13_html);
                            allTimings.Add(sub_13_14_html);
                            allTimings.Add(sub_15_16_html);
                            allTimings.Add(sub_19_20_html);*/

                            TimeTableAttributes newObject = new TimeTableAttributes();
                            TimeTableAttributes newObject1 = new TimeTableAttributes();
                            TimeTableAttributes newObject2 = new TimeTableAttributes();
                            TimeTableAttributes newObject3 = new TimeTableAttributes();
                            TimeTableAttributes newObject4 = new TimeTableAttributes();
                            TimeTableAttributes newObject5 = new TimeTableAttributes();

                            if (!string.IsNullOrEmpty(sub_7_8_html))
                            { 
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_7_8_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null) {
                                    newObject.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                   newObject.division = spanNode2.InnerText; 
                                }
                                if (spanNode3 != null)
                                {
                                    newObject.lh = spanNode3.InnerText;
                                }
                            }

                            if (!string.IsNullOrEmpty(sub_9_10_html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_9_10_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null)
                                {
                                    newObject1.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject1.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                    newObject1.division = spanNode2.InnerText;
                                }
                                if (spanNode3 != null)
                                {
                                    newObject1.lh = spanNode3.InnerText;
                                }
                            }

                            if (!string.IsNullOrEmpty(sub_12_13_html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_12_13_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null)
                                {
                                    newObject2.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject2.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                    newObject2.division = spanNode2.InnerText;
                                }
                                if (spanNode3 != null)
                                {
                                    newObject2.lh = spanNode3.InnerText;
                                }
                            }
                            
                            /*if (!string.IsNullOrEmpty(sub_13_14_html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_13_14_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null)
                                {
                                    newObject3.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject3.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                    newObject3.division = spanNode2.InnerText;
                                }
                                if (spanNode3 != null)
                                {
                                    newObject3.lh = spanNode3.InnerText;
                                }
                            }
                            
                            if (!string.IsNullOrEmpty(sub_15_16_html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_15_16_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null)
                                {
                                    newObject4.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject4.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                    newObject4.division = spanNode2.InnerText;
                                }
                                if (spanNode3 != null)
                                {
                                    newObject4.lh = spanNode3.InnerText;
                                }
                            }
                            
                            if (!string.IsNullOrEmpty(sub_19_20_html))
                            {
                                HtmlDocument doc = new HtmlDocument();
                                doc.LoadHtml(sub_19_20_html);
                                HtmlNode spanNode = doc.DocumentNode.SelectSingleNode("//span[@name=\"crs\"]");
                                HtmlNode spanNode1 = doc.DocumentNode.SelectSingleNode("//span[@name=\"sem\"]");
                                HtmlNode spanNode2 = doc.DocumentNode.SelectSingleNode("//span[@name=\"cls\"]");
                                HtmlNode spanNode3 = doc.DocumentNode.SelectSingleNode("//span[@name=\"fct\"]");
                                if (spanNode != null)
                                {
                                    newObject5.subject = spanNode.InnerText;
                                }
                                if (spanNode1 != null)
                                {
                                    newObject5.term = spanNode1.InnerText;
                                }
                                if (spanNode2 != null)
                                {
                                    newObject5.division = spanNode2.InnerText;
                                }
                                if (spanNode3 != null)
                                {
                                    newObject5.lh = spanNode3.InnerText;
                                }
                            }*/

                            customers.Add(new OutputModel
                            {
                                WEEKDAY = sdr["WEEKDAY"].ToString(),
                                /*StartDate = Convert.ToDateTime(sdr["StartDate"].ToString()).ToString("yyyy-MM-dd"),
                                EndDate = Convert.ToDateTime(sdr["EndDate"].ToString()).ToString("yyyy-MM-dd"),*/
                                time_7_8 = newObject,
                                time_9_10 = newObject1,
                                time_12_13 = newObject2,
/*                                time_13_14 = newObject3,
                                time_15_16 = newObject4,
                                time_19_20 = newObject5,*/
                            }
                            );
                        }
                    }
                    con.Close();
                }
            }
            return customers;
        }
    }
}