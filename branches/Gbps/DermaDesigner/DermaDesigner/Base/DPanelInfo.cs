using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

// Used to store panel info to serialize

namespace DermaDesigner
{
    [Serializable]
    public class DPanelInfo
    {
        public Dictionary<string, byte[]> Data;

        public DPanelInfo()
        {
            Data = new Dictionary<string, byte[]>();
        }
        public void Insert(string key, byte[] data)
        {
            Data.Add(key,data);
        }

    }
}
