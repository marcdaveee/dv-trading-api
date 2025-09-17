using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvTrading.Application.DTOs.Common.Response
{
    public class DbTransactionResult<T>
    {        
        public bool IsSuccessful { get; set; }      
        
        public ApiStatusCode StatusCode { get; set; }

        public T? Data { get; set; }

        public string? Message {  get; set; }
    } 


    public enum ApiStatusCode
    {

        OK = 200,
        NotFound = 404,
        Unauthorized = 401,
        ServerError = 500,

    }
}
