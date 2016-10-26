using Foundation;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UIKit;

namespace TNPA.iOS
{
	partial class GrowRowTableCell : UITableViewCell
	{
		
		#region Computed Properties
		public UIImage Image {
			get { return CellImage.Image; }
			set { CellImage.Image = value; }
		}

		public string Title {
			get { return CellTitle.Text; }
			set { CellTitle.Text = value; }
		}

		public string Description {
			get { return CellDescription.Text; }
			set { CellDescription.Text = value; }
		}
		#endregion

		#region Constructors
		public GrowRowTableCell (IntPtr handle) : base (handle)
		{

        }

        #endregion

        string localPath;
        //Update image
        public async void UpdateCell(string image, int count)
        {
            //Load image from URL Async.
            Image = await Download(image, count);
        }

        public async Task<UIImage> Download(string pathImage, int count)
        {
            var httpClient = new HttpClient();
            byte[] imageBytes = await httpClient.GetByteArrayAsync(pathImage);
            await SaveBytesToFileAsync(imageBytes, count.ToString() + "team.jpg");
            return UIImage.FromFile(localPath);             
        }

        async Task SaveBytesToFileAsync(byte[] bytesToSave, string fileName)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string localFilename = fileName;
            localPath = Path.Combine(documentsPath, localFilename);

            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }

            using (FileStream fs = new FileStream(localPath, FileMode.Create, FileAccess.Write))
            {
                await fs.WriteAsync(bytesToSave, 0, bytesToSave.Length);
            }
        }
    }
}
