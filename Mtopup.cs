// using System;
// using Npgsql;
// using Oracle.ManagedDataAccess.Client;
// using Soap_Bss;

// class Program
// {

//     static void Main(string[] args)
//     {
//         //DB Postgres
//         string connectStrNpgsl = "Host=172.28.26.178;Username=apigee;Password=#Ltc1qaz2wsx@pg;Database=postgres";

//         var result_ = "";
//         var seq_number="";
//         var msisdn_ = "";
//         var amount_ = 0;
//         int cnt = 0;
//         var getdate = String.Format("{0:yyyyMMddHHmm}", DateTime.Now);
//         DateTime datetime_ = DateTime.Now;
//         string formattedDate = $"{datetime_:yyyyMMddHHmmss}";
//         var transaction = "ADDJUSTPAYMENT_" + formattedDate + cnt.ToString();;
//         try
//         {
            
//             Console.WriteLine("start proces:.........");

//             string sql = $"SELECT msisdn, amount,seq_number FROM public.refund_payment_mtopup";
//             using (NpgsqlConnection conn_Npgsl = new NpgsqlConnection(connectStrNpgsl))
//             {
//                 try
//                 {
//                     conn_Npgsl.Open();
//                     NpgsqlCommand command = new NpgsqlCommand(sql, conn_Npgsl);
//                     using (NpgsqlDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
                            
//                             msisdn_ = reader["msisdn"].ToString();
//                             amount_ = Convert.ToInt32(reader["amount"]);
//                             seq_number = reader["seq_number"].ToString();

                        
//                             //---addjust payment---
//                             var client = new EntityActionClient(EntityActionClient.EndpointConfiguration.EntityAction);
//                             var request = client.executeCommandAsync(@"command=make_payment_third_party;"
//                             + $"p_msisdn={msisdn_};"
//                             + " p_username=LTC;"
//                             + $"amount={amount_};"
//                             + "bankcode=TRANSFER;"
//                             + "bankname=TRANSFER;"
//                             + "shopcode=MTOPUPPLUS;"
//                             + "staffcode=MTOPUPPLUS;"
//                             + $"transaction_id={seq_number};"
//                             + "p_password=12345", "ltc", "ltc");
//                             var result = request.Result;
//                             var listdata = result.Split("responce=")[1].Replace("{", "").Replace("}", "").Replace(" ", "");
//                             var collectiondata = listdata.Split(",");
//                             // result_ = collectiondata[1];

//                             Console.WriteLine("Count:" + cnt + "|" + "Seq_number:" + seq_number + "|" + "Msisdn:" + msisdn_ +"|"+"Amount:"+amount_);

//                             //write log txt file
//                             string detail = string.Format("{0}|{1}|{2}|{3}{4}|{5}",$"{cnt}",$"{seq_number}", $"{msisdn_}",$"{amount_}",$"{result}", $"{getdate}");
//                             WriteLog("TranPayment", detail.Trim());

//                              ++cnt;
//                         }
//                     }
//                 }
//                 catch (System.Exception ex)
//                 {
//                     Console.WriteLine("continue process is error:" + ex.Message);
//                 }
//                 finally
//                 {
//                     conn_Npgsl.Close();
//                     Console.WriteLine("end process:");
//                 }
//             }

//         }
//         catch (System.Exception ex)
//         {
//             Console.WriteLine("incorrect addj payment:" + ex.Message + "===");
//         }


//     }

//     public static void WriteLog(string fnName, string detail)
//     {
//         FileStream fs;
//         StreamWriter sw;
//         try
//         {
//             string pth = @"C:\LOG_ADDJ_PAYMENT\";
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











