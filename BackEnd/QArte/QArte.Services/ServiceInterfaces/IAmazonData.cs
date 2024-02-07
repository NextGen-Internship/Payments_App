using System;
namespace QArte.Services.ServiceInterfaces
{
	public interface IAmazonData
	{
		string AccessKey { get;}
		string SecretKey { get; }
		string UserName { get; }
		string BucketName { get; }
		string Region { get; }
	}
}

