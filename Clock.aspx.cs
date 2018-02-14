using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsTest
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ThisMonthCurrendar.Text = this.CalendarHtml(0)+ this.CalendarHtml(1);
        }
        /// <summary>
        /// カレンダ要素の日付配列を取得する
        /// </summary>
        /// <param name="AddMonth"></param>
        /// <returns></returns>
        public string[] CalendarElements(int AddMonth)
        {
            // 月の最初日
            DateTime FirstDay = new DateTime(DateTime.Today.Year,DateTime.Today.Month+AddMonth,1);
            // 翌月最初日
            DateTime NextMonthFirstDay = new DateTime(DateTime.Today.Year, DateTime.Today.Month + AddMonth + 1, 1) ;
            // 月の最終日
            DateTime LastDay = NextMonthFirstDay.AddDays(-1);
            
            int intLastDay = LastDay.Day;
            
            // 返却値
            string[] Arr = new string [0] ;
            
            // 日付
            int Count= 1;

            for (int i=0; i<=42; i++){
                if (i < (int)FirstDay.DayOfWeek)
                {
                    Array.Resize(ref Arr, i + 1);
                }
                else if (Count <= intLastDay)
                    
                {
                    Array.Resize(ref Arr, i + 1);
                    Arr[i] = Count.ToString();
                    Count = Count+1;
                 }
            }
            return Arr;            
        }
        /// <summary>
        /// HTMLを書く
        /// </summary>
        /// <param name="AddMonth"></param>
        /// <returns></returns>
        public string CalendarHtml(int AddMonth)
        {

            // 月
            DateTime DateMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month + AddMonth , 1);
            int month = DateMonth.Month;

            // 年
            int year = DateMonth.Year;

            string HTML = "<h1><small>" + year + "<small>年</small>&nbsp;&nbsp;</small>" 
                + month + "<small>月</small></h1>";
            HTML+="<Table class=\"CalendarTable\">";
            HTML += "<TH class=\"RedFont\">日</TH>";
            HTML += "<TH>月</TH>";
            HTML += "<TH>火</TH>";
            HTML += "<TH>水</TH>";
            HTML += "<TH>木</TH>";
            HTML += "<TH>金</TH>";
            HTML += "<TH class=\"BlueFont\">土</TH>";
            string[] Arr = CalendarElements(AddMonth);

            for (int i = 0; i<Arr.Length;i++)
            {
                // 週はじめ日（日曜日）→行を追加
                if (i % 7 == 0) {
                    if (i != 0)
                    {
                        HTML += "</TR><TR>";
                    }
                    else
                    {
                        HTML += "<TR>";
                    }
                }
                // セル開くタグ入力
                string HtmlPart = "<TD";
                // ブランクセル
                if (Arr[i] == null)
                {
                    HtmlPart += "><BR />";
                } 
                // 今日の日付の書式設定
                else if (year == DateTime.Today.Year 
                    && month == DateTime.Today.Month && DateTime.Today.Day==Int32.Parse(Arr[i]))
                {
                    HtmlPart += " style=\"background-color:yellow\"";
                }
                // 日曜日の書式・値設定
                if (i % 7 == 0 && Arr[i] != null)
                {
                    HtmlPart += " class=\"RedFont\">" + Arr[i];
                }
                // 土曜日の書式・値設定
                else if (i % 7 == 6 && Arr[i] != null)
                {
                    HtmlPart += " class=\"BlueFont\">" + Arr[i];
                }
                // 書式設定なし・値設定
                else if (Arr[i] != null)
                {
                    HtmlPart += ">" + Arr[i];
                }
                // セル閉じるタグ
                HTML += HtmlPart + "</TD>";
            }
            // テーブル閉じるタグ
            HTML += "</TR></TABLE>";
                      
            return HTML;
        }
    }
}