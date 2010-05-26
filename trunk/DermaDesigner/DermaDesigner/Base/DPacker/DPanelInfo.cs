using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

// Used to store panel info to serialize

namespace DermaDesigner {
	[Serializable]
	public class DPanelInfo {
		public Dictionary<string, byte[]> Data;

		public DPanelInfo() {
			Data = new Dictionary<string, byte[]>();
		}
		public void Insert(string key, byte[] data) {
			Data.Add(key, data);
		}

		public string GetString(string key) {
			try {
				return Encoding.UTF8.GetString(Data[key]);
			} catch {
				return null;
			}
		}

		public int? GetInt(string key) {
			try {

				return BitConverter.ToInt32(Data[key], 0);

			} catch {
				return null;
			}
		}

		public bool? GetBool(string key) {
			try {
				return BitConverter.ToBoolean(Data[key], 0);
			} catch {
				return null;
			}
		}

		public char? GetChar(string key) {
			try {
				return BitConverter.ToChar(Data[key], 0);
			} catch {
				return null;
			}
		}

		public double? GetDouble(string key) {
			try {
				return BitConverter.ToDouble(Data[key], 0);
			} catch {
				return null;
			}
		}

		public float? GetFloat(string key) {
			try {
				return BitConverter.ToSingle(Data[key], 0);
			} catch {
				return null;
			}
		}

		public byte[] GetBytes(string key) {
			try {
				return Data[key];
			} catch {
				return null;
			}
		}

		public object GetObject(string key, Type RequestedType) {
			if (RequestedType == typeof(int)) {
				return GetInt(key);
			} else if (RequestedType == typeof(bool)) {
				return GetBool(key);
			} else if (RequestedType == typeof(string)) {
				return GetString(key);
			} else if (RequestedType == typeof(char)) {
				return GetChar(key);
			} else if (RequestedType == typeof(double)) {
				return GetDouble(key);
			} else if (RequestedType == typeof(float)) {
				return GetFloat(key);
			} else if (RequestedType == typeof(List<string>)) {
				return DPacker.DeSerializeStringList(Data[key]);
			}
			return null;
		}
	}
}