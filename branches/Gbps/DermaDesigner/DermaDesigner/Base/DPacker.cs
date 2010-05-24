using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

// Manager for saving and loading DD states

namespace DermaDesigner
{
    public class DPacker
    {
        public List<DPanelInfo> PanelData;
        public DPacker()
        {
            PanelData = new List<DPanelInfo>();
        }

        public byte[] GetData()
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

        public void PackAllToFile(string filename)
        {
            List<Panel> panels = Derma.GetPanels();
            PanelData = new List<DPanelInfo>();
            foreach (Panel p in panels)
            {
                InsertPanelInfo(PanelToInfo(p));
            }
            FileStream Fstream = File.OpenWrite(filename);
            Byte[] Data = GetData();
            Fstream.Write(Data,0,Data.Length);
            Fstream.Close();
        }

        public void ReadAllFromFile(string filename)
        {
            FileStream Fstream = File.OpenRead(filename);
            Byte[] buffer = new byte[Fstream.Length];
            Fstream.Read(buffer, 0, buffer.Length);
            Fstream.Close();
            SetData(buffer);
            foreach (DPanelInfo ifo in PanelData)
            {
                PanelFromPanelInfo(ifo);
            }
            MatchParentsWithIdentitifiers();
        }

        /// <summary>
        /// Must be called directly after any PanelFromPanelInfo calls
        /// </summary>
        public static void MatchParentsWithIdentitifiers()
        {
            foreach(Panel p in Derma.GetPanels())
            {
                if (p.parentIdentifier != null)
                {
                    foreach(Panel p2 in Derma.GetPanels())
                    {
                        if (p.parentIdentifier == p2.varname)
                        {
                            p.SetParent(p2);
                            p.parentIdentifier = null;
                        }
                    }
                }
            }
            Derma.ResortPanelsByZ();
        }

        public static Panel PanelFromPanelInfo(DPanelInfo ifo)
        {
            string type = ifo.GetString("___type");
            if (type == null) return null;
            string ParentIndex = ifo.GetString("___parent");
            Panel p = Derma.New(type);
            FieldInfo[] fields = GetSaveableFields(p);
            foreach (FieldInfo FInfo in fields){
                Type CastType = FInfo.FieldType;
                object SavedProp = ifo.GetObject(FInfo.Name, CastType);
                if (SavedProp == null) continue;
                FInfo.SetValue(p,SavedProp);
            }
            if (ParentIndex != null)
            {
                p.parentIdentifier = ParentIndex;
            }
            return p;
        }

        private static FieldInfo[] GetSaveableFields<T>(T Input) where T : Panel
        {
            List<FieldInfo> WorkingTable = new List<FieldInfo>();
            FieldInfo[] fields = Input.GetType().GetFields();
            foreach (FieldInfo FInfo in fields)
            {
                object[] FInfoAttribs = FInfo.GetCustomAttributes(typeof (PackerAttrib), true); // Add if PackerAttrib is assigned
                object[] FInfoAttribs_CA = FInfo.GetCustomAttributes(typeof (CategoryAttribute), true); // Add if CategoryAttribute is assigned
                FInfoAttribs.Concat(FInfoAttribs_CA); // Put them all together
                if (!FInfoAttribs.Any()) continue;
                WorkingTable.Add(FInfo);
            }
            return WorkingTable.ToArray();
        }

        /// <summary>
        /// Convert a Panel to a DPanelInfo
        /// </summary>
        /// <typeparam name="T">Derives from Panel</typeparam>
        /// <param name="Input">Any object deriving from Panel</param>
        /// <returns></returns>
        public static DPanelInfo PanelToInfo<T>(T Input) where T : Panel // Must be a Panel
        {
            Type InputType = Input.GetType();
            FieldInfo[] fields = GetSaveableFields(Input);
            DPanelInfo ifo = new DPanelInfo();
            foreach(FieldInfo FInfo in fields)
            {
                object val = FInfo.GetValue(Input);
                Type t = val.GetType(); 
                string key = FInfo.Name;
                // If I need to add more, tell me @Gbps
                if (t == typeof(string))
                {
                    ifo.Insert(key, Encoding.UTF8.GetBytes((string)val));
                }
                else if (t == typeof(int))
                {
                    ifo.Insert(key, BitConverter.GetBytes((int)val));
                }
                else if(t== typeof(bool))
                {
                    ifo.Insert(key, BitConverter.GetBytes((bool)val));
                }
                else if (t == typeof(char))
                {
                    ifo.Insert(key, BitConverter.GetBytes((char)val));
                }
                else if (t == typeof(float))
                {
                    ifo.Insert(key, BitConverter.GetBytes((float)val));
                }
                else if (t == typeof(double))
                {
                    ifo.Insert(key, BitConverter.GetBytes((double)val));
                }
            }
            if (Input.hasParent && Input.parent)
            {
                ifo.Insert("___parent", Encoding.UTF8.GetBytes(Input.parent.varname));
            }
            ifo.Insert("___type", Encoding.UTF8.GetBytes(Input.GetType().Name));
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
