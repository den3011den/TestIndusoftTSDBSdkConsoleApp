using Enums;
using Indusoft.TSDB.Common;
using Indusoft.TSDB.SDK.Abstracts;
using Indusoft.TSDB.SDK.Clients;
using Indusoft.TSDB.SDK.Entities;
using Indusoft.TSDB.TSDBSDK;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIndusoftTSDBSdkConsoleApp
{
    public class TSDBPointTimeStampWorker
    {

        private TSDBServer tSDBServer;
        private TSDBSDKLogger sDKLogger = new TSDBSDKLogger();
        private TSDBServerConnection tSDBServerConnection;
        IDataClient dataClient;

        public TSDBPointTimeStampWorker()
        {
            tSDBServer = new TSDBServer();
            tSDBServer.ServerURL = ConfigurationManager.AppSettings["TSDBServerURL"];
            tSDBServer.Login = ConfigurationManager.AppSettings["TSDBLogin"];
            tSDBServer.Password = ConfigurationManager.AppSettings["TSDBPassword"];
            tSDBServer.ServerName = ConfigurationManager.AppSettings["TSDBServerName"];

            try
            {
                tSDBServerConnection = new TSDBServerConnection(tSDBServer.ServerName, tSDBServer.ServerURL, tSDBServer.Login, tSDBServer.Password, sDKLogger);
            }

            catch (Exception ex)
                {
                    throw new Exception("Error: Cannot create connection to TSDB server with parameters:\n" +
                            "Server URL     = \"" + tSDBServer.ServerURL + "\"\n" +
                            "Server name    = \"" + tSDBServer.ServerName + "\"\n" +
                            "Server login   = \"" + tSDBServer.Login + "\"\n" +
                            "Server password = \"" + tSDBServer.Password + "\"\n" +
                            "Error message: " + ex.Message);
                }


            

            dataClient = tSDBServerConnection.DataClient;
        }


        public dynamic GetPointValueByNameAndTimeStamp(string pointName, DateTime timeStamp, PointDataType pointDataType)
        {
            try
            {
                if (tSDBServerConnection.IsServiceAvailable())
                    if (tSDBServerConnection.TagExist(pointName))
                    {

                        var dataPoint3 = dataClient.GetTagDataPoint(pointName, timeStamp);
                        if (dataPoint3.IsSuccess)
                        {
                            switch (pointDataType)
                            {
                                case PointDataType.Bool:
                                    {
                                        if (dataPoint3.Value.ValueString != null)
                                        {
                                            bool tryVаr;
                                            Boolean.TryParse(dataPoint3.Value.ValueString, out tryVаr);
                                            if (tryVаr)
                                                return Boolean.Parse(dataPoint3.Value.ValueString);
                                            else
                                                return null;
                                        }
                                        else
                                            return null;
                                        break;
                                    }
                                case PointDataType.Float:
                                    return dataPoint3.Value.ValueFloat;
                                    break;
                                case PointDataType.Integer:
                                    return dataPoint3.Value.ValueLong;
                                    break;
                                case PointDataType.String:
                                    if (dataPoint3.Value.ValueString != null)
                                        return dataPoint3.Value.ValueString;
                                    else
                                        return "";
                                    break;
                                default:
                                    return (object)dataPoint3.Value;
                                    break;
                            }
                        }
                        else
                        {
                            throw new Exception("Error while reading data for tag \"" + pointName + "\" for timestam " + timeStamp.ToString() + "\n" +
                                "Error mess: Code: " + dataPoint3.Error.ErrorCode.ToString() + " ->> " + dataPoint3.Error.Message);
                        }
                    }
                    else
                    {
                        throw new Exception("Error: cannot find tag \"" + pointName + "\"");
                    }
                else
                    throw new Exception("Error: server not available\n" +
                            "Server URL  = \"" + tSDBServer.ServerURL + "\"\n" +
                            "Server name = \"" + tSDBServer.ServerName + "\"\n" +
                            "Server login = \"" + tSDBServer.Login + "\"\n" +
                            "Server password = \"" + tSDBServer.Password + "\"");
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing method \"GetPointValueByNameAndTimeStamp\" with object of class \"TSDBPointTimeStampWorker\"\n" +
                    "Error message: " + ex.Message);
            }

        }

        public bool SetPointValueByNameAndTimeStamp(string pointName, DateTime timeStamp, dynamic pointValue)
        {
            try
            {
                if (tSDBServerConnection.IsServiceAvailable())
                    if (tSDBServerConnection.TagExist(pointName))
                    {

                        bool resultVar = false;

                        if (pointValue is long)
                        {
                            DataPoint<long> dataPoint2 = new DataPoint<long>();
                            dataPoint2.Value = pointValue;
                            Tag<long> tag = new Tag<long>();
                            dataPoint2.QualityMark = Indusoft.TSDB.BusinessLogic.Entities.QualityMark.Good;
                            dataPoint2.TimeStamp = timeStamp;
                            dataPoint2.Annotation = "Хорошее значение";
                            tag.Name = pointName;
                            tag.DataPoints = new List<DataPoint<long>>();
                            tag.DataPoints.Add(dataPoint2);
                            resultVar = dataClient.SetData(tag).Value;
                        }
                        else
                            if (pointValue is float)
                        {
                            DataPoint<float> dataPoint2 = new DataPoint<float>();
                            dataPoint2.Value = pointValue;
                            Tag<float> tag = new Tag<float>();
                            dataPoint2.QualityMark = Indusoft.TSDB.BusinessLogic.Entities.QualityMark.Good;
                            dataPoint2.TimeStamp = timeStamp;
                            dataPoint2.Annotation = "Хорошее значение";
                            tag.Name = pointName;
                            tag.DataPoints = new List<DataPoint<float>>();
                            tag.DataPoints.Add(dataPoint2);
                            resultVar = dataClient.SetData(tag).Value;
                        }
                        else
                                if (pointValue is string)
                        {
                            DataPoint<string> dataPoint2 = new DataPoint<string>();
                            dataPoint2.Value = pointValue;
                            Tag<string> tag = new Tag<string>();
                            dataPoint2.QualityMark = Indusoft.TSDB.BusinessLogic.Entities.QualityMark.Good;
                            dataPoint2.TimeStamp = timeStamp;
                            dataPoint2.Annotation = "Хорошее значение";
                            tag.Name = pointName;
                            tag.DataPoints = new List<DataPoint<string>>();
                            tag.DataPoints.Add(dataPoint2);
                            resultVar = dataClient.SetData(tag).Value;
                        }
                        else
                                    if (pointValue is bool)
                        {
                            DataPoint<string> dataPoint2 = new DataPoint<string>();
                            dataPoint2.Value = pointValue.ToString();
                            Tag<string> tag = new Tag<string>();
                            dataPoint2.QualityMark = Indusoft.TSDB.BusinessLogic.Entities.QualityMark.Good;
                            dataPoint2.TimeStamp = timeStamp;
                            dataPoint2.Annotation = "Хорошее значение";
                            tag.Name = pointName;
                            tag.DataPoints = new List<DataPoint<string>>();
                            tag.DataPoints.Add(dataPoint2);
                            resultVar = dataClient.SetData(tag).Value;

                        }
                        return resultVar;
                    }
                    else
                    {
                        throw new Exception("Error: cannot find tag \"" + pointName + "\"");
                    }
                else
                    throw new Exception("Error: server not available\n" +
                            "Server URL  = \"" + tSDBServer.ServerURL + "\"\n" +
                            "Server name = \"" + tSDBServer.ServerName + "\"\n" +
                            "Server login = \"" + tSDBServer.Login + "\"\n" +
                            "Server password = \"" + tSDBServer.Password + "\"");
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing method \"SetPointValueByNameAndTimeStamp\" with object of class \"TSDBPointTimeStampWorker\"\n" +
                    "Error message: " + ex.Message);
            }

        }

        public bool CheckPointExist(string pointName)
        {
            try
            {
            return (tSDBServerConnection.TagExist(pointName));
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing method \"CheckPointExist\" with object of class \"TSDBPointTimeStampWorker\"\n" +
                    "Error message: " + ex.Message);
            }
        }
    }
}
