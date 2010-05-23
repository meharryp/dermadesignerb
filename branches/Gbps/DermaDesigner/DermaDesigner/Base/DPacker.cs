using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

// Manager for saving and loading DD states

namespace DermaDesigner
{
    public class DPacker : ISerializable
    {
        private List<DPanelInfo> PanelData;
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
        
        public static void PanelToInfo<T>(T Input) where T : Panel // Must be a Panel
        {
            Type InputType = Input.GetType();
            FieldInfo[] fields = InputType.GetFields();
            DPanelInfo ifo = new DPanelInfo();
            foreach(FieldInfo FInfo in fields)
            {
                object[] FInfoAttribs = FInfo.GetCustomAttributes(typeof (PackerAttrib), true);
                if (FInfoAttribs.Any())
                {
                    object val = FInfo.GetValue(Input);
                    Type t = val.GetType();
                    string key = FInfo.Name;
                    if (t == typeof(string))
                    {
                        ifo.Insert(key, Encoding.UTF8.GetBytes((string)val));
                    }else if(t == typeof(int))
                    {
                        ifo.Insert(key, new byte[]{Convert.ToByte(val)});
                    }
                }
            }
        }

    }
}
