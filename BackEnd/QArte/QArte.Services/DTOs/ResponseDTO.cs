using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QArte.Services.DTOs
{
    public class Response<T>
    {
        public bool Succeed { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public int ID { get; set; }
        public string? picUrl { get; set; }
    }
}
//new