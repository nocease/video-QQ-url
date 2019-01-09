using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
   public class TX_video
    {
        public static String Geturl(string url)
        {
            try
            {
                //获取网址id
                //string url = ;
                string[] url_html = url.Split('/');
                string[] url_id = url_html[5].Split('.');
                //label9.Text = url_id[0];

                //获取json链接
                string url_json = "http://vv.video.qq.com/getinfo?vids=" + url_id[0] + "&platform=101001&charge=0&otype=json";
                //label10.Text = url_json;

                //获取json链接源代码
                string html_root = getwebcode1(url_json, "UTF-8");
                System.Console.WriteLine(html_root);
                //label11.Text = html_root;

                //获取fn
                string[] fn_1 = Regex.Split(html_root, "fn", RegexOptions.IgnoreCase);
                string[] fn_2 = Regex.Split(fn_1[1], "head", RegexOptions.IgnoreCase);
                string[] fn_3 = fn_2[0].Split('"');
                string fn = fn_3[2];
                //label16.Text = fn;

                //获取fvkey
                string fvkey = fn_3[10];
                //label17.Text = fvkey;

                //获取url前缀
                string[] URL_1 = Regex.Split(html_root, "url", RegexOptions.IgnoreCase);
                string[] URL_2 = URL_1[2].Split('"');
                string URL = URL_2[2];
                //label18.Text = URL;



                string geturl = URL + fn + "?vkey=" + fvkey;//最终结果
                //Session["http_url"] = TextBox2.Text;
                //label8.Text = "解析成功！";
                return geturl;
            }
            catch
            {
                return "false!";
            }

        }

        //获取网页源代码
        private static string getwebcode1(string url, string encoder)
        {
            WebClient myWebClient = new WebClient();
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string SourceCode = Encoding.GetEncoding(encoder).GetString(myDataBuffer);
            return SourceCode;
        }
    }
}
