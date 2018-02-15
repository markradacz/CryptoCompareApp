﻿using System;
using System.IO;
using System.Reflection;
using System.Linq;

namespace CryptoCompare.Helpers
{
	public static class ResourceManager
	{
		private static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
		{
			var resourceNames = assembly.GetManifestResourceNames();

			var resourcePaths = resourceNames
				.Where(x => x.EndsWith(resourceFileName, StringComparison.CurrentCultureIgnoreCase))
				.ToArray();

			if (!resourcePaths.Any())
			{
				throw new Exception(string.Format("Resource ending with {0} not found.", resourceFileName));
			}

			if (resourcePaths.Count() > 1)
			{
				throw new Exception(string.Format("Multiple resources ending with {0} found: {1}{2}", resourceFileName, Environment.NewLine, string.Join(Environment.NewLine, resourcePaths)));
			}

			return assembly.GetManifestResourceStream(resourcePaths.Single());
		}

		private static string GetEmbeddedResourceString(Assembly assembly, string resourceFileName)
		{
			var stream = GetEmbeddedResourceStream(assembly, resourceFileName);

			using (var streamReader = new StreamReader(stream))
			{
				return streamReader.ReadToEnd();
			}
		}


		public static string GetMockData(Assembly assembly, String name)
		{
			var dataIdentifier = assembly.GetName().Name + ".Services.Mocks." + name;
			var data = ""; 

			foreach (var resource in assembly.GetManifestResourceNames())
			{
				if (resource.StartsWith(dataIdentifier))
				{
					data = GetEmbeddedResourceString(assembly, resource);
				}
			}

			return data;
		}
	}
}

