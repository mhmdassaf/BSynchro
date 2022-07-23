using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSynchro.Common.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Code = (int)HttpStatusCode.OK;
            Flag = Flag.Pass;
            Message = string.Empty;
        }

        public Flag Flag { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public object? Result { get; set; }
    }
    [Flags]
    public enum Flag
    {
        Pass = 0,
        Fail = 1,
    }
}
