using System;
using Microsoft.Extensions.Configuration;
using QArte.Services.ServiceInterfaces;

namespace QArte.Services.Services
{
	public class AmazonData:IAmazonData
	{
        private IConfiguration _configuration;

        public AmazonData(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string AccessKey => _configuration["Amazon:AccessKey"];

        public string SecretKey => _configuration["Amazon:SecretKey"];

        public string UserName => _configuration["Amazon:UserName"];

        public string BucketName => _configuration["Amazon:BucketName"];

        public string Region => _configuration["Amazon:Region"];
    }
}

