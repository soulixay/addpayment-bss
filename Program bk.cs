// using System;
// using Npgsql;
// using Oracle.ManagedDataAccess.Client;
// using Soap_Bss;

// class Program
// {

//     static void Main(string[] args)
//     {

//         var result_ = "";
//         var msisdn = "";
//         var amount = 0;
//         var getdate = String.Format("{0:yyyyMMddHHmm}", DateTime.Now);
//         string connectStrNpgsl = "Host=172.28.26.178;Username=apigee;Password=#Ltc1qaz2wsx@pg;Database=postgres";
//         string connectStrOracle = @"Data Source=(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 172.)(PORT = 1521))(CONNECT_DATA=(SID=CCD)));User Id=K;Password=k;";
//         try
//         {
//             using (OracleConnection connection = new OracleConnection(connectStrOracle))
//             {
//                 try
//                 {
//                      connection.Open();
//                     DateTime datetime_ = DateTime.Now;
//                     string formattedDate = $"{datetime_:yyyyMMddHHmmss}";
//                     var transaction = "PROM_" + formattedDate;
//                     string sql = "SELECT * FROM";
//                     OracleCommand command = new OracleCommand(sql, connection);
//                     using (OracleDataReader reader = command.ExecuteReader())
//                     {
//                         while (reader.Read())
//                         {
//                             //list data
//                            msisdn = reader.GetString(0);
//                            amount = reader.GetInt32(1);


//                             //addjust payment
//                             var client = new EntityActionClient(EntityActionClient.EndpointConfiguration.EntityAction);
//                             var request = client.executeCommandAsync(@"command=make_payment_third_party;"
//                             + $"p_msisdn={msisdn};"
//                             + " p_username=LTC;"
//                             + $"amount={amount};"
//                             + "bankcode=LTC;"
//                             + "bankname=LTC;"
//                             + "shopcode=LTC;"
//                             + "staffcode=LTC;"
//                             + $"transaction_id={transaction};"
//                             + "p_password=12345", "ltc", "ltc");
//                             var result = request.Result;
//                             var listdata = result.Split("responce=")[1].Replace("{", "").Replace("}", "").Replace(" ", "");
//                             var collectiondata = listdata.Split(",");
//                             result_ = collectiondata[1];


//                         }
//                     }

//                     // var client = new EntityActionClient(EntityActionClient.EndpointConfiguration.EntityAction);
//                     // var request = client.executeCommandAsync($"command=queryService;msisdn='21fhtest03'; username=LTC;password=12345;remote_address=10.30.5.123;shopcode=LTC", "ltc", "ltc");
//                     // var result = request.Result;
//                     // var listdata=result.Split("responce=")[1].Replace("{","").Replace("}","").Replace(" ", "");
//                     // var collectiondata=listdata.Split(",");
//                     // result_=collectiondata[1];

//                 }
//                 catch (System.Exception ex)
//                 {
//                     Console.WriteLine("continue process is error:" + ex.Message);
//                 }
//                 finally
//                 {
//                     connection.Close();
//                 }
//             }


//         }
//         catch (System.Exception ex)
//         {
//             Console.WriteLine("rerun is error:" + ex.Message);

//         }
//         finally
//         {
//             //add log to database
//             string sql = $"insert into public.log_addjust_payment (msisdn, amt_adjust, response) "
//             + $"values ('{msisdn}','{amount}','{result_}')";
//             using (NpgsqlConnection conn_Npgsl = new NpgsqlConnection(connectStrNpgsl))
//             {
//                 try
//                 {
//                     conn_Npgsl.Open();
//                     using (NpgsqlCommand command = new NpgsqlCommand(sql, conn_Npgsl))
//                     {
//                         command.Parameters.AddWithValue($"msisdn", $"{msisdn}");
//                         command.Parameters.AddWithValue($"amt_adjust", $"{amount}");
//                         command.Parameters.AddWithValue($"response", $"{result_}");
//                         command.ExecuteNonQuery();
//                     }
//                 }
//                 catch (System.Exception ex)
//                 {
//                     Console.WriteLine(ex.Message);

//                 }
//                 finally
//                 {
//                     conn_Npgsl.Close();
//                 }
//             }
//             //write log txt file
//             string detail = string.Format("{0}|{1}|{2}|{3}", "21fhtest03", $"{result_}", $"2000", $"{getdate}");
//             WriteLog("addjust_payment", detail.Trim());
//         }

//     }



//     public static void WriteLog(string fnName, string detail)
//     {
//         FileStream fs;
//         StreamWriter sw;
//         try
//         {
//             string pth = @"C:\LOG_ADDJ_PAYMENT\";
//             fs = new FileStream(pth + fnName.Trim() + String.Format("{0:yyyyMMddHHmm}", DateTime.Now) + ".log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
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




