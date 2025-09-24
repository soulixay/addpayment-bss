// using System;
// using Npgsql;
// using Oracle.ManagedDataAccess.Client;
// using Soap_Bss;
// using System.Xml;

// class Program
// {

//     static void Main(string[] args)
//     {
//         //DB Postgres
//         string connectStrNpgsl = "Host=172.28.26.178;Username=apigee;Password=#Ltc1qaz2wsx@pg;Database=postgres";

//         var result_ = "";
//         var seq_number_ = "";
//         var msisdn_ = "";
//         var amount_ = 0;
//         var shopcode_="";
//         var staffcode_="";
//         var bankname="";
//         var bankcode="";
        
//         int cnt = 1;


//         string filePath = @"D:\BssWork\addj_payment\request_data\rerun_prom .txt";
//         try
//         {

//             Console.WriteLine("start proces:.........");

//             using (StreamReader reader = new StreamReader(filePath))
//             {

//                 string line;

//                 while ((line = reader.ReadLine()) != null)
//                 {

//                     string[] data_arr = line.Split("|");

//                     var getdate = String.Format("{0:yyyyMMddHHmm}", DateTime.Now);
//                     // DateTime datetime_ = DateTime.Now;
//                     // string formattedDate = $"{datetime_:yyyyMMddHHmmss}";
//                     // var transaction = "ADDJUSTPAYMENT_" + formattedDate + cnt.ToString();

//                     seq_number_=data_arr[0];
//                     msisdn_=data_arr[1];
//                     amount_=Convert.ToInt32(data_arr[2]);
//                     shopcode_=data_arr[3];
//                     staffcode_=data_arr[4];
//                     bankcode=data_arr[5];
//                     bankname=data_arr[6];

//                     //---addjust payment---

//                     var client = new EntityActionClient(EntityActionClient.EndpointConfiguration.EntityAction);
//                     var request = client.executeCommandAsync(@"command=make_payment_third_party;"
//                     + $"p_msisdn={msisdn_};"
//                     + " p_username=LTC;"
//                     + $"amount={amount_};"
//                     + $"bankcode={bankcode};"
//                     + $"bankname={bankname};"
//                     + $"shopcode={shopcode_};"
//                     + $"staffcode={staffcode_};"
//                     + $"transaction_id={seq_number_};"
//                     + "p_password=12345", "ltc", "ltc");
//                     var result = request.Result;
//                     var listdata = result.Split("responce=")[1].Replace("{", "").Replace("}", "").Replace(" ", "");
//                     var collectiondata = listdata.Split(",");
//                     // result_ = collectiondata[1];

//                     Console.WriteLine("Count:" + cnt + "|" + "Seq_number:" + seq_number_ + "|" + "Msisdn:" + msisdn_ + "|" + "Amount:" + amount_);

//                     //write log txt file
//                     string detail = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", $"{cnt}", $"{seq_number_}", $"{msisdn_}", $"{amount_}",$"{staffcode_}",$"{shopcode_}", $"{result}", $"{getdate}");
//                     WriteLog("RERUN_PROMADDJUST_BSS", detail.Trim());

//                     ++cnt;
//                 }
//             }
//         }
//         catch (System.Exception ex)
//         {
//             Console.WriteLine("continue process is error:" + ex.Message);
//         }
//         finally
//         {

//             Console.WriteLine("end process:");
//         }



//     }

//     public static void WriteLog(string fnName, string detail)
//     {
//         FileStream fs;
//         StreamWriter sw;
//         try
//         {

//             string pth = @"D:\BssWork\addj_payment\respones_data\";
//             fs = new FileStream(pth + fnName.Trim() + String.Format("{0:yyyyMMdd}", DateTime.Now) + ".log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
//             sw = new StreamWriter(fs);
//             sw.WriteLine(string.Format("{0}", detail.Trim()));
//             sw.Close();
//             fs.Close();
//             sw.Dispose();
//             fs.Dispose();
//         }
//         catch { }
//     }
// }

















