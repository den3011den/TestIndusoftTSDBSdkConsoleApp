using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Indusoft.TSDB.TSDBSDK;

namespace TestIndusoftTSDBSdkConsoleApp
{
    public class TSDBSDKLogger : ISDKLogger
    {

        private enum LogLevel
        {
            INFO,
            DEBUG,
            WARNING,
            ERROR
        }

        private string _logDirectory;

        private long _logRotateSize;

        private string _filename;

        public bool IsDebugEnabled
        {
            get
            {
                return true;
            }
            set
            {
                value.ToString();
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return true;
            }
            set
            {
                value.ToString();
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return true;
            }
            set
            {
                value.ToString();
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return true;
            }
            set
            {
                value.ToString();
            }
        }

        public TSDBSDKLogger()
        {
        }

        public TSDBSDKLogger(string logDirectory, long logRotateSize)
            : this()
        {
            _logDirectory = logDirectory;
            _logRotateSize = logRotateSize;
            _filename = Path.Combine(_logDirectory, "SDKLog.log");
        }

        private void Log(string message, LogLevel level)
        {
            try
            {
                if (File.Exists(_filename) && Convert.ToDecimal(new FileInfo(_filename).Length) > (decimal)(_logRotateSize * 1024 * 1024))
                {
                    if (File.Exists(_filename + ".1"))
                    {
                        File.Delete(_filename + ".1");
                    }

                    File.Move(_filename, _filename + ".1");
                }

                WriteLine(string.Format("{0}:{1}\n({2}) {3}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff\t"), level, WindowsIdentity.GetCurrent()?.Name, message));
            }
            catch
            {
            }
        }

        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_filename, append, Encoding.UTF8))
                {
                    if (text != "")
                    {
                        streamWriter.WriteLine(text);
                    }
                };
            }
            catch
            {
                throw;
            }
        }

        public void Debug(Exception ex)
        {
            Log(ex.ToString(), LogLevel.DEBUG);
        }

        public void Debug(string message)
        {
            Log(message, LogLevel.DEBUG);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Log(string.Format(format, args), LogLevel.DEBUG);
        }

        public void Error(Exception ex)
        {
            Log(ex.ToString(), LogLevel.ERROR);
        }

        public void Error(string message)
        {
            Log(message, LogLevel.ERROR);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Log(string.Format(format, args), LogLevel.ERROR);
        }

        public void Info(Exception ex)
        {
            Log(ex.ToString(), LogLevel.INFO);
        }

        public void Info(string message)
        {
            Log(message, LogLevel.INFO);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Log(string.Format(format, args), LogLevel.INFO);
        }

        public void Warn(Exception ex)
        {
            Log(ex.ToString(), LogLevel.WARNING);
        }

        public void Warn(string message)
        {
            Log(message, LogLevel.WARNING);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Log(string.Format(format, args), LogLevel.WARNING);
        }
    }
}
