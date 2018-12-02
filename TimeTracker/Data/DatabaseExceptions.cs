using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Data
{
    public class DatabaseExceptions
    {
        public static void ValidateConnectionString(string _dbString)
        {
            if (String.IsNullOrEmpty(_dbString))
            {
                ArgumentException exception = new ArgumentException("Connection string is empty");
                throw exception;
            }
        }
    }
}
