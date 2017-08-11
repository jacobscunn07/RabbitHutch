using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace RabbitHutch.Application.Helpers
{
	public static class BasicPropertiesExtensions
	{
		public static IDictionary<string, string> GetHeadersDictionary(this IBasicProperties basicProperties)
		{
			var dict = new Dictionary<string, string>();
			if (basicProperties.Headers != null)
			{
				foreach (var header in basicProperties.Headers)
				{
                    var bytes = header.Value == null ? Encoding.UTF8.GetBytes(string.Empty) : (byte[])header.Value;
					dict.Add(header.Key, Encoding.UTF8.GetString(bytes));
				}
			}
			return dict;
		}
	}
}
