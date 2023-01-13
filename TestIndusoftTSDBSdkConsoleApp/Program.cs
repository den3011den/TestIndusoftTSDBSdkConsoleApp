using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indusoft.TSDB.TSDBSDK;
using Indusoft.TSDB;
using Indusoft.TSDB.SDK.Entities;
using Indusoft.TSDB.BusinessLogic.Entities;
using System.Configuration;
using Indusoft.TSDB.BusinessLogic.Entities.Statistics.Enum;
using Enums;

namespace TestIndusoftTSDBSdkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //TSDBServer tSDBServer = new TSDBServer();
            //tSDBServer.ServerURL = ConfigurationManager.AppSettings["TSDBServerURL"];
            //tSDBServer.Login = ConfigurationManager.AppSettings["TSDBLogin"];
            //tSDBServer.Password = ConfigurationManager.AppSettings["TSDBPassword"];
            //tSDBServer.ServerName = ConfigurationManager.AppSettings["TSDBServerName"];

            ////var sDKLogger = new SDKLogger("c:\\temp_\\", 10000);
            //TSDBSDKLogger sDKLogger = new TSDBSDKLogger();

            //TSDBServerConnection tSDBServerConnection = new TSDBServerConnection(tSDBServer.ServerName, tSDBServer.ServerURL, tSDBServer.Login, tSDBServer.Password, sDKLogger);

            /////TSDB_SDK tSDB_SDK = TSDB_SDK.Instance;
            ////TSDB_SDK.GetConnection()

            //long jjj = tSDBServerConnection.GetTagsCount();

            //bool hhh = tSDBServerConnection.IsServiceAvailable();

            //bool jjj1 = tSDBServerConnection.TagExist("tsdb_integer_1");
            //bool jjj2 = tSDBServerConnection.TagExist("tsdb_integer_2");

            //var dataClient = tSDBServerConnection.DataClient;

            //DateTime timePoint = new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Local);

            //var dataPoint1 = dataClient.GetTagDataPoint("tsdb_integer_1", timePoint);

            ////tSDBServerConnection.GetData

            //System.Console.WriteLine("dataClient.GetTagDataPoint(\"tsdb_integer_1\", " + timePoint.ToString() + ") = " + dataPoint1.Value.ToString());

            //System.Console.WriteLine("tSDBServerConnection.TagExist(\"tsdb_integer_1\") = " + jjj1.ToString());
            //System.Console.WriteLine("tSDBServerConnection.TagExist(\"tsdb_integer_2\") = " + jjj2.ToString());
            //System.Console.WriteLine("tSDBServerConnection.GetTagsCount() = " + jjj.ToString());

            TSDBPointTimeStampWorker tSDBPointTimeStampWorker = new TSDBPointTimeStampWorker();

            bool boolValue;

            //SetBooleanValue
            System.Console.WriteLine("SetBooleanValue: = true ");
            if (tSDBPointTimeStampWorker != null)
            {
                boolValue = tSDBPointTimeStampWorker.SetPointValueByNameAndTimeStamp("test_string_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), true);
                System.Console.WriteLine("Результат: " + (boolValue ? "Успех" : "НЕ Успех"));
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }

            //SetDiscretValue
            System.Console.WriteLine("SetDiscretValue: = 10000 ");
            if (tSDBPointTimeStampWorker != null)
            {
                boolValue = tSDBPointTimeStampWorker.SetPointValueByNameAndTimeStamp("tsdb_integer_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), 10000L);
                System.Console.WriteLine("Результат: " + (boolValue ? "Успех" : "НЕ Успех"));
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }


            //SetFloatValue
            System.Console.WriteLine("SetFloatValue: = 10.111 ");
            if (tSDBPointTimeStampWorker != null)
            {
                boolValue = tSDBPointTimeStampWorker.SetPointValueByNameAndTimeStamp("test_float_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), 10.111F);
                System.Console.WriteLine("Результат: " + (boolValue ? "Успех" : "НЕ Успех"));
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }

            //SetStringValue
            System.Console.WriteLine("SetStringValue: = \"Это новое строковое значение\"");
            if (tSDBPointTimeStampWorker != null)
            {
                boolValue = tSDBPointTimeStampWorker.SetPointValueByNameAndTimeStamp("test_string_2", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), "Это новое строковое значение");
                System.Console.WriteLine("Результат: " + (boolValue ? "Успех" : "НЕ Успех"));
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }


            //GetBooleanGoodValue
            System.Console.WriteLine("GetBooleanGoodValue для \"test_string_1\"");
            if (tSDBPointTimeStampWorker != null)
            {
                bool? getBoolResult = tSDBPointTimeStampWorker.GetPointValueByNameAndTimeStamp("test_string_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), PointDataType.Bool);
                System.Console.WriteLine("Результат GetBooleanGoodValue:  = " + getBoolResult.ToString());
            }
            else
            { 
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }


            //GetDiscretGoodValue            
            System.Console.WriteLine("GetDiscretGoodValue для tsdb_integer_1");
            if (tSDBPointTimeStampWorker != null)
            {
                long? getLongResult = tSDBPointTimeStampWorker.GetPointValueByNameAndTimeStamp("tsdb_integer_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), PointDataType.Integer);
                System.Console.WriteLine("Результат GetDiscretGoodValue = " + getLongResult.ToString());
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }


            //GetFloatGoodValue           
            System.Console.WriteLine("GetFloatGoodValue для test_float_1");
            if (tSDBPointTimeStampWorker != null)
            {
                float? getFloatResult = tSDBPointTimeStampWorker.GetPointValueByNameAndTimeStamp("test_float_1", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), PointDataType.Float);
                System.Console.WriteLine("Результат GetFloatGoodValue = " + getFloatResult.ToString());
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }


            //GetStringGoodValue
            System.Console.WriteLine("GetFloatGoodValue для test_string_2");
            if (tSDBPointTimeStampWorker != null)
            {
                string getStringResult = tSDBPointTimeStampWorker.GetPointValueByNameAndTimeStamp("test_string_2", new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), PointDataType.String);
                System.Console.WriteLine("Результат GetStringGoodValue = " + getStringResult);
            }
            else
            {
                System.Console.WriteLine("!!! Пустой объект \"tSDBPointTimeStampWorker\"");
            }

            System.Console.WriteLine("<<Press any key>>");
            System.Console.ReadKey();
        }
    }
}
