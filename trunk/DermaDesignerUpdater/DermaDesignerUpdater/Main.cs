using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
namespace DermaDesignerUpdater {
	public partial class Main : Form {
		private Thread ZipThread;
		private string BuildVersion;
		public Main() {
			InitializeComponent();
		}
		private bool HasCompleted = false;
		public void ReadWholeArray(Stream stream, byte[] data) {
			int offset = 0;
			int remaining = data.Length;
			while (remaining > 0) {
				int read = stream.Read(data, offset, remaining);
				if (read <= 0)
					throw new EndOfStreamException
						(String.Format("End of stream reached with {0} bytes left to read", remaining));
				remaining -= read;
				offset += read;
			}
		}


		public void ProgressSet(int Val) {
			_ProgressBar.Value = Val;
		}

		public void TextSet(string Text) {
			_StatusLabel.Text = Text;
			_StatusLabel.Refresh();
		}

		public void TextSetError(Delegate_TextSet d, string error) {
			this.Invoke(d, "An error occurred :: " + error);
		}

		public void SetButtonState(bool Disabled) {
			_UpdateButton.Enabled = !Disabled;
			if (Disabled) {
				_UpdateButton.Text = "Updating...";
			} else {
				if (HasCompleted) {
					_UpdateButton.Text = "Run DermaDesigner";
				} else {
					_UpdateButton.Text = "Update Now";
				}
			}
		}

		public delegate void Delegate_ProgressSet(int Val);
		public delegate void Delegate_TextSet(string Text);
		public delegate void Delegate_SetButtonState(bool Disabled);

		public void StartDownload() {
			WebClient Client = new WebClient();
			Delegate_ProgressSet __ProgressSet = new Delegate_ProgressSet(ProgressSet);
			Delegate_TextSet __TextSet = new Delegate_TextSet(TextSet);
			Delegate_SetButtonState __SetButtonState = new Delegate_SetButtonState(SetButtonState);
			this.Invoke(__SetButtonState, true);
			this.Invoke(__ProgressSet, 10);
			this.Invoke(__TextSet, "Getting version info...");
			string err = GetBuildVersion();
			if (err != "") {
				TextSetError(__TextSet, err);
				this.Invoke(__SetButtonState, false);
				return;
			}
			this.Invoke(__ProgressSet, 30);
			this.Invoke(__TextSet, "Downloading zip file...");

			try {
				Client.DownloadFile("http://dermadesignerb.googlecode.com/svn/trunk/DermaDesigner/DermaDesigner/bin/Release/" + BuildVersion, ".$DSUpdateTmp");
			} catch {
				TextSetError(__TextSet, "Could not download file.");
				this.Invoke(__SetButtonState, false);
				return;
			}

			this.Invoke(__ProgressSet, 50);
			this.Invoke(__TextSet, "Unzipping zip file...");

			#region Unzipping Code
			try {
				Stream str = File.OpenRead(".$DSUpdateTmp");
				ZipInputStream s = new ZipInputStream(str);
				ZipEntry theEntry;
				while ((theEntry = s.GetNextEntry()) != null) {

					string directoryName = Path.GetDirectoryName(theEntry.Name);
					string fileName = Path.GetFileName(theEntry.Name);
					if (directoryName.Contains("_svn") || directoryName.Contains(".svn") || fileName.Contains("Updater.exe")) {
						continue;
					}
					// create directory
					if (directoryName.Length > 0) {
						Directory.CreateDirectory(directoryName);
					}

					if (fileName != String.Empty) {
						using (FileStream streamWriter = File.Create(theEntry.Name)) {

							int size = 2048;
							byte[] data = new byte[2048];
							while (true) {
								size = s.Read(data, 0, data.Length);
								if (size > 0) {
									streamWriter.Write(data, 0, size);
								} else {
									break;
								}
							}
						}
					}
				}
			} catch {
				TextSetError(__TextSet, "Could not unzip file.");
				this.Invoke(__SetButtonState, false);
			}
			#endregion Unzipping Code

			this.Invoke(__ProgressSet, 75);
			this.Invoke(__TextSet, "Deleting zip file...");

			try {
				File.Delete(".$DSUpdateTmp");
			} catch {
				TextSetError(__TextSet, "Could not delete file.");
				this.Invoke(__SetButtonState, false);
				return;

			}

			this.Invoke(__ProgressSet, 100);
			this.Invoke(__TextSet, "Completed Successfully!");
			HasCompleted = true;
			this.Invoke(__SetButtonState, false);
		}

		private string GetBuildVersion() {
			WebClient Client = new WebClient();
			Byte[] str = Client.DownloadData("http://dermadesignerb.googlecode.com/svn/trunk/DermaDesigner/DermaDesigner/bin/Release/");
			string HTML = Encoding.ASCII.GetString(str);
			Regex buildfinder = new Regex("Build([0-9][0-9][0-9]).zip");
			Match buildmatch = buildfinder.Match(HTML);
			if (buildmatch.Success == false) {
				return "Unable to find version info";
			}
			BuildVersion = buildmatch.Groups[0].Captures[0].Value;
			return "";
		}
		private void _UpdateButton_Click(object sender, EventArgs e) {
			if (HasCompleted == false) {
				if (ZipThread == null || ZipThread.IsAlive == false) {
					ZipThread = new Thread(StartDownload);
					ZipThread.Start();
				}
			} else {
				System.Diagnostics.Process.Start("DermaDesigner.exe");
				Environment.Exit(0);
			}
		}

	}
}
