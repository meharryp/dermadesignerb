using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DermaDesigner
{
    /// <summary>
    /// A class to handle the saving and loading environment
    /// </summary>
    public class DSave
    {
        private static string CurrentFilename = "Untitled.ddproj";
        private static DPacker Packer = new DPacker();
        
        public static void SetEnvironment(string filename)
        {
            CurrentFilename = filename;
            Derma.GetWorkspace().Text = "DermaDesigner - " + Path.GetFileName(filename);
        }

        public static void SetDialogDefaults()
        {
            GetOpenDialog().FileName = Path.GetFileName(CurrentFilename);
            GetSaveDialog().FileName = Path.GetFileName(CurrentFilename);
        }
        public static string GetEnvironment()
        {
            return CurrentFilename;
        }
        
        public static OpenFileDialog GetOpenDialog()
        {
            return ((Main) Derma.GetWorkspace()).OpenDialog;
        }

        public static SaveFileDialog GetSaveDialog()
        {
            return ((Main)Derma.GetWorkspace()).SaveDialog;
        }

        public static void Save()
        {
            try
            {
                Packer.PackAllToFile(CurrentFilename);
            }catch(Exception e)
            {
                MessageBox.Show("Unable to save file\n" + e.Message, "Unable to save", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        public static void SaveAs(string filename)
        {
            SetEnvironment(filename);
            Save();
        }

        public static void ClearAll()
        {
            SetEnvironment("Untitled.ddproj");
            List<Panel> PList = new List<Panel>();
            PList.Concat(Derma.GetPanels());
            foreach(Panel P in PList)
            {
                try
                {
                    P.Remove();
                }catch
                {
                    // We don't care if it doesn't want to remove, the panel list will get cleared anyways.
                }
            }
            Derma.GetPanels().Clear();
            ResizeGrip.host = null;
            Derma.Repaint();
        }

        public static void Load(string filename)
        {
            try
            {
                Packer.ReadAllFromFile(filename);
            }catch(Exception e)
            {
                MessageBox.Show("Unable to load file\n" + e.Message, "Unable to load", MessageBoxButtons.OK,
                               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            SetEnvironment(filename);
            Derma.Repaint();
        }
    }
}
