// using System;
// using Npgsql;
// using Oracle.ManagedDataAccess.Client;
// using Soap_Bss;
// using System.Xml;

// class Program
// {

//     static void Main(string[] args)
//     {
//         var result_ = "";
//         var msisdn_ = "";
//         var shopcode_="";
//         int cnt = 2;

//         string filePath = @"D:\BssWork\addj_payment\request_data\data_activeDB\data.txt";
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

//                     msisdn_=data_arr[0];
//                     shopcode_=data_arr[1];


//                     //---activateServiceDBt---

//                     var client = new EntityActionClient(EntityActionClient.EndpointConfiguration.EntityAction);
//                     var request = client.executeCommandAsync(@"command=activateServiceDB;"
//                     + $"msisdn={msisdn_};"
//                     + $"servicecode={shopcode_};"
//                     + "username=LTC;"
//                     + "password=12345;"
//                     + "remote_address=10.30.5.123;"
//                     + "shopcode=LTC;"
//                     + "p_password=12345", "ltc", "ltc");
//                     var result = request.Result;
//                     var listdata = result.Split("responce=")[1].Replace("{", "").Replace("}", "").Replace(" ", "");
//                     var collectiondata = listdata.Split(",");
//                     // result_ = collectiondata[1];

//                     Console.WriteLine("Count:" + cnt + "|" + "Msisdn:" + msisdn_ + "|" + "ServiceType:" +shopcode_ +"|"+"Result:"+result);

//                     //write log txt file
//                     string detail = string.Format("{0}|{1}|{2}|{3}|{4}", $"{cnt}", $"{msisdn_}",$"{shopcode_}", $"{result}", $"{getdate}");
//                     WriteLog("ACTIVESRV_DB", detail.Trim());

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

//             string pth = @"D:\BssWork\addj_payment\respones_data\Activeservice\";
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

















