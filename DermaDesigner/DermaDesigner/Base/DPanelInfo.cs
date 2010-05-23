using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Used to store panel info to serialize

namespace DermaDesigner
{
    class DPanelInfo
    {
        public Dictionary<string, byte[]> Data;

        public void Insert(string key, byte[] data)
        {
            Data.Add(key,data);
        }
    }
}
