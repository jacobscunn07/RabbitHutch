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
					dict.Add(header.Key, Encoding.UTF8.GetString((byte[])header.Value));
				}
			}
			return dict;
		}
	}
}
