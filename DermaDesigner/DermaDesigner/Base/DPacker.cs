using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

// Manager for saving and loading DD states

namespace DermaDesigner
{
    public class DPacker : ISerializable
    {
        public List<DPanelInfo> PanelData;

        public DPacker()
        {
            PanelData = new List<DPanelInfo>();
        }

        public byte[] GetyData()
        {
            BinaryFormatter BFormat = new BinaryFormatter();
            MemoryStream MemStream = new MemoryStream();
            BFormat.Serialize(MemStream,PanelData);
            return MemStream.ToArray();
        }

        public bool SetData(byte[] dat)
        {
            try
            {
                BinaryFormatter BFormat = new BinaryFormatter();
                MemoryStream MemStream = new MemoryStream();
                MemStream.Write(dat, 0, dat.Length);
                MemStream.Seek(0, SeekOrigin.Begin);
                object deS = BFormat.Deserialize(MemStream);
                PanelData = (List<DPanelInfo>)deS;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        /// <summary>
        /// Convert a Panel to a DPanelInfo
        /// </summary>
        /// <typeparam name="T">Derives from Panel</typeparam>
        /// <param name="Input">Any object deriving from Panel</param>
        /// <param name="ParentIndex">Index of the parent returned from InsertPanelInfo. Pass null if none.</param>
        /// <returns></returns>

        public static DPanelInfo PanelToInfo<T>(T Input, int? ParentIndex) where T : Panel // Must be a Panel
        {
            Type InputType = Input.GetType();
            FieldInfo[] fields = InputType.GetFields();
            DPanelInfo ifo = new DPanelInfo();
            foreach(FieldInfo FInfo in fields)
            {
                object[] FInfoAttribs = FInfo.GetCustomAttributes(typeof (PackerAttrib), true); // Add if PackerAttrib is assigned
                object[] FInfoAttribs_CA = FInfo.GetCustomAttributes(typeof (CategoryAttribute), true); // Add if CategoryAttribute is assigned
                FInfoAttribs.Concat(FInfoAttribs_CA); // Put them all together
                if (!FInfoAttribs.Any()) continue;
                object val = FInfo.GetValue(Input);
                Type t = val.GetType(); 
                string key = FInfo.Name;
                // If I need to add more, tell me @Gbps
                if (t == typeof(string))
                {
                    ifo.Insert(key, Encoding.UTF8.GetBytes((string)val));
                }
                else if (t == typeof(int) || t == typeof(bool) || t == typeof(float) || t == typeof(double) || t == typeof(char))
                {
                    ifo.Insert(key, new byte[] {Convert.ToByte(val)});
                }
                if (ParentIndex != null)
                {
                    ifo.Insert("_parent",new byte[]{Convert.ToByte(ParentIndex)});
                }
            }
            return ifo;
        }

        /// <summary>
        /// Insert DPanelInfo into the DPacker object.
        /// </summary>
        /// <param name="ifo"></param>
        /// <returns>Index of added panel</returns>
        public int InsertPanelInfo(DPanelInfo ifo)
        {
            PanelData.Add(ifo);
            return PanelData.Count() - 1;
        }


    }
}
