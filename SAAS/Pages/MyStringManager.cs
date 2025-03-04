

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web;

namespace SAAS.Pages
{
    public static class MyStringManager
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static bool CheckIfTodayIsGreaterThanDate(string date)
        {

            DateTime Date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime TodayDate = DateTime.Now;


            int startResult = DateTime.Compare(TodayDate, Date);

            if (startResult >= 0)
            {

                return true;
            }
            return false;
        }
        public static string GetNumberWithComas(string numberAsaString)
        {

            string st = MyStringManager.RemoveSpecialCharacters(numberAsaString);

            string returnString = $"{Convert.ToInt64(st):n0}";
            return returnString;

        }
        public static int GetCountOfRowsWithCondition(DataTable dt, string CoulmnName, string Value)
        {
            int count = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[CoulmnName].ToString().Equals(Value))
                    count++;

            }

            return count;


        }
        public static double GetSumOfRowsWithCondition(DataTable dt, string CoulmnName)
        {
            double Sum = 0;

            foreach (DataRow dr in dt.Rows)
            {
                Sum += GetIntFromNumberStringWithComas(dr[CoulmnName].ToString());

            }

            return Sum;


        }
        public static int GetIntFromNumberStringWithComas(string numWithComasAsString)
        {

            string st = MyStringManager.RemoveSpecialCharacters(numWithComasAsString);
            int RetuirnInt = (int)Convert.ToInt64(st);
            return RetuirnInt;


        }
        public static DataTable GetTableAferDateIsWithTheTwoDatesFromTheTable(DataTable InTbl, string StartDateFeild, string EndDateFeild,
            string DateToBeWithn)
        {

            DataTable AfterDateDT = InTbl.Clone();
            DataTable retunrDT = AfterDateDT.Clone();
            retunrDT.Clone();
            if (DateToBeWithn.Length > 0)
            {
                AfterDateDT.Clear();

                foreach (DataRow dr in InTbl.Rows)
                {

                    DateTime Date = DateTime.ParseExact(DateToBeWithn, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime Startdate = DateTime.ParseExact(dr[StartDateFeild].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime Enddate = DateTime.ParseExact(dr[EndDateFeild].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    int startResult = DateTime.Compare(Date, Startdate);
                    int endResult = DateTime.Compare(Enddate, Date);

                    if (startResult >= 0 && endResult >= 0)
                    {
                        AfterDateDT.ImportRow(dr);

                    }


                }
                retunrDT = AfterDateDT;
            }
            else
            {
                retunrDT = InTbl;

            }

            return retunrDT;
        }
        public static DataTable GetTableAfterDateCheck(DataTable InTbl, string StartDate, string EndDate)
        {

            DataTable AfterDateDT = InTbl.Clone();
            DataTable retunrDT = AfterDateDT.Clone();
            retunrDT.Clone();
            if (StartDate.Length > 0 && EndDate.Length > 0)
            {
                AfterDateDT.Clear();

                foreach (DataRow dr in InTbl.Rows)
                {


                    CultureInfo enUS = new CultureInfo("en-US");

                    //  var dt = "1374755180";

                    DateTime dateValue;
                    DateTime Date;
                    // DateTime Date = DateTime.ParseExact(dr["التاريخ"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    bool yearFirst = false;

                    // Scenario #2
                    /*  if (DateTime.TryParseExact(dr["التاريخ"].ToString(), "dd/MM/yyyy", enUS, DateTimeStyles.None, out dateValue))
                      {
                          yearFirst = false;
                          Date = dateValue;
                      }

                      // Scenario #3
                      if (DateTime.TryParseExact(dr["التاريخ"].ToString(), "yyyy/MM/dd", enUS, DateTimeStyles.None, out dateValue))
                      {
                          yearFirst = true;
                          Date = dateValue;

                      }*/

                    var formatStrings = new string[] { "dd/MM/yyyy", "yyyy/MM/dd" };
                    if (DateTime.TryParseExact(dr["التاريخ"].ToString(), formatStrings, enUS, DateTimeStyles.None, out Date))
                    {

                        //  Date = Date;

                    }
                    //  return dateValue;

                    string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "yyyy/MM/dd", "yyyy/MM/d", "yyyy/M/dd", "yyyy/M/d" };
                    var dateTime = DateTime.ParseExact(dr["التاريخ"].ToString(), formats, new CultureInfo("en-GB"), DateTimeStyles.None);
                    Date = dateTime;
                    DateTime Startdate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime Enddate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                    int startResult = DateTime.Compare(Date, Startdate);
                    int endResult = DateTime.Compare(Enddate, Date);

                    if (startResult >= 0 && endResult >= 0)
                    {
                        AfterDateDT.ImportRow(dr);

                    }


                }
                retunrDT = AfterDateDT;
            }
            else
            {
                retunrDT = InTbl;

            }

            return retunrDT;
        }

        public static string GetDateAfterCheckingFormating(string inDate)
        {


            DateTime dateValue;
            DateTime Date;

            string[] formats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "yyyy/MM/dd", "yyyy/MM/d", "yyyy/M/dd", "yyyy/M/d" };
            var dateTime = DateTime.ParseExact(inDate, formats, new CultureInfo("en-GB"), DateTimeStyles.None);
            Date = dateTime;

            return Date.ToString("dd/MM/yyyy");




        }
        public static string GetLastDayOfTheMonth(int Month)
        {
            int total_days_in_month;

            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    total_days_in_month = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    total_days_in_month = 30;
                    break;
                case 2:
                default:
                    total_days_in_month = 28;
                    break;
            }

            return total_days_in_month + "";



        }

        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public static DataTable GetTableAfterCeckWithdorwParty(DataTable InTbl, string WithdorwParty, string FeildName)
        {

            DataTable AfterPrjectName = InTbl.Clone();
            AfterPrjectName.Clear();

            foreach (DataRow dr in InTbl.Rows)
            {

                if (dr[FeildName].ToString().Equals(WithdorwParty))
                {
                    AfterPrjectName.ImportRow(dr);
                }


            }

            return AfterPrjectName;

        }
        public static DataTable GetTableAfterCeckProjectName(DataTable InTbl, string ProjectName, string FeildName)
        {

            DataTable AfterPrjectName = InTbl.Clone();
            AfterPrjectName.Clear();

            foreach (DataRow dr in InTbl.Rows)
            {

                if (dr[FeildName].ToString().Equals(ProjectName))
                {
                    AfterPrjectName.ImportRow(dr);
                }


            }

            return AfterPrjectName;

        }


        public static DataTable ReturnTableWithCurrencyCommas(DataTable InTbl, string FeildName)
        {
            DataTable NewTable = InTbl.Clone();

            NewTable.Clear();
            NewTable.Columns.Remove(FeildName);

            NewTable.Columns.Add(FeildName, typeof(String));

            foreach (DataRow dr in InTbl.Rows)


            {

                NewTable.ImportRow(dr);



            }
            int counter = 0;
            foreach (DataRow dr in InTbl.Rows)


            {

                NewTable.Rows[counter][FeildName] = GetNumberWithComas(dr[FeildName].ToString() + "");

                counter++;

            }



            return NewTable;

        }


        public static double ReturnSumOfDTFildInInt(DataTable InTbl, string FildName)
        {
            double sum = 0;
            foreach (DataRow dr in InTbl.Rows)
            {

                sum += Convert.ToInt32(dr[FildName].ToString());


            }



            return sum;

        }

    }
}