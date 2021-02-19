#region Using derectives

using System;
using System.IO;
using System.Threading;

#endregion

namespace Lab_no19
{
	public sealed class ConcurrentFile
	{
		private readonly string _filePath;
		private readonly object _syncObject = new object();

		public ConcurrentFile(string path)
		{
			_filePath = path ?? throw new ArgumentNullException(nameof(path));

			if (!File.Exists(_filePath)) throw new FileNotFoundException(nameof(path));
		}

		public void Write(string text)
		{
			var isLockRequired = false;

			try
			{
				Monitor.Enter(_syncObject, ref isLockRequired);
				using var stream = new StreamWriter(_filePath, true);
				stream.WriteLine(text);
			}
			finally
			{
				if (isLockRequired) Monitor.Exit(_syncObject);
			}
		}

		public string Read()
		{
			var isLockRequired = false;

			try
			{
				Monitor.Enter(_syncObject, ref isLockRequired);
				var result = File.ReadAllLines(_filePath);

				return String.Join(Environment.NewLine, result);
			}
			finally
			{
				if (isLockRequired) Monitor.Exit(_syncObject);
			}
		}
	}
}