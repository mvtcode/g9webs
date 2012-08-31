using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G9.Core;
using G9.Entity;

namespace Website.admin
{
    public partial class UploadImage : System.Web.UI.Page
    {
        private string _PathImage;
        private string _FolderImage;
        private string _thumbs;
        protected void Page_Load(object sender, EventArgs e)
        {
            var objAdmin = (AdminInfo)Session[Constant.SessionNameAccountAdmin];
            if (objAdmin == null)
            {
                Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }

            string sType = Request.QueryString["type"];
            if(sType=="product")
            {
                _PathImage = Config.PathProduct + "/";
                _FolderImage = Server.MapPath(Config.PathProduct);
            }
            else
            {
                _PathImage = Config.ImagePath + "/";
                _FolderImage = Server.MapPath(Config.ImagePath);
                
            }

            _thumbs = Config.PathImgThumbs;
            if (!System.IO.Directory.Exists(_FolderImage))
            {
                System.IO.Directory.CreateDirectory(_FolderImage);
            }

            if (!Directory.Exists(_FolderImage + "\\" + _thumbs))
            {
                Directory.CreateDirectory(_FolderImage + "\\" + _thumbs);
            }

            if (!IsPostBack)
            {
                ShowFile();
                string sURL = Request.QueryString["URL"];
                if (sURL.ToLower().StartsWith("http://") || sURL.ToLower().StartsWith("https://"))
                {
                    TB_URL.Text = sURL;
                }
                //BT_Cancel.Attributes.Add("onclick","javascript:return winclose();");
                BT_Select.Attributes.Add("onclick", "javascript:return CheckURL();");
                TB_URL.Attributes.Add("onkeypress", "javascript:TB_URL_Keypress(event);");
            }
        }
        protected void BT_Upload_Click(object sender, EventArgs e)
        {
            if (File_Upload.PostedFile != null)
            {
                HttpPostedFile myFile = File_Upload.PostedFile;
                int nFileLen = myFile.ContentLength;
                if (nFileLen > 0)
                {
                    //if(nFileLen>10240) file quá lớn (>10MB)!

                    byte[] myData = new byte[nFileLen];
                    myFile.InputStream.Read(myData, 0, nFileLen);
                    string strFilename = Path.GetFileName(myFile.FileName);
                    string sf = strFilename.ToUpper();
                    if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".BMP") || sf.EndsWith(".GIF"))
                    {
                        //WriteToFile(_FolderImage + "\\" + strFilename, ref myData);
                        string sName = DateTime.Now.ToString("ddMMyyyy_HHmmssfff");
                        WriteToFile(_FolderImage + "\\" + sName + strFilename.Substring(strFilename.Length - 4, 4), ref myData);
                        ImageResize(myData, _FolderImage + "\\" + _thumbs + "\\" + sName + strFilename.Substring(strFilename.Length - 4, 4), 120, 120, 90);
                    }
                    //else
                    //{
                    //    //ko lưu file định dạng khác
                    //}

                }
                ShowFile();
            }
        }

        public static void ImageResize(byte[] data, string desPath, int thumbWidth, int thumbHeight, long quality)
        {
            Stream stream = new MemoryStream(data);
            var sourceBitmap = new Bitmap(stream);

            //fix chiều dài, rộng ko bị méo ảnh!
            int h = sourceBitmap.Height;
            int w = sourceBitmap.Width;
            //var iDelta=(thumbWidth/w>thumbHeight/h)?thumbHeight/h:thumbWidth/w;
            float iDelta;
            if ((float)thumbWidth / w > (float)thumbHeight / h)
            {
                iDelta = (float)thumbHeight / h;
            }
            else
            {
                iDelta = (float)thumbWidth / w;
            }

            thumbWidth = Convert.ToInt32(iDelta * w);
            thumbHeight = Convert.ToInt32(iDelta * h);
            //

            var thumbBitmap = new Bitmap(thumbWidth, thumbHeight);
            var g = Graphics.FromImage(thumbBitmap);

            try
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, thumbWidth, thumbHeight);
                g.DrawImage(sourceBitmap, 0, 0, thumbWidth, thumbHeight);

                var info = ImageCodecInfo.GetImageEncoders();
                var param = new EncoderParameters(1);
                param.Param[0] = new EncoderParameter(Encoder.Quality, quality);

                thumbBitmap.Save(desPath, info[1], param);
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                sourceBitmap.Dispose();
                thumbBitmap.Dispose();
                g.Dispose();
            }
        }

        private void WriteToFile(string strPath, ref byte[] Buffer)
        {
            FileStream newFile = new FileStream(strPath, FileMode.Create);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
        }

        private void ShowFile()
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(_FolderImage);
            string sHTML = "";
            foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
            {
                string sf = f.FullName.ToUpper();
                if (sf.EndsWith(".JPG") || sf.EndsWith(".PNG") || sf.EndsWith(".BMP") || sf.EndsWith(".GIF"))
                {
                    sHTML += "<div class=\"apDiv\" >";
                    sHTML += "<div><img alt=\"\" width=\"100%\" src=\"" + _PathImage + _thumbs + "/" + f.Name + "\" onclick=\"javascript:SelectImage('" + f.Name + "','" + _PathImage + _thumbs + "/" + f.Name + "');\"/>";
                    //sHTML += "<div style=\"text-align:center\">" + f.Name.ToString() + "</div>";
                    //sHTML += "<div style=\"text-align:center\">" + f.Length.ToString() + "</div>";
                    sHTML += "</div></div>";
                }
            }
            if (sHTML.Length > 0)
            {
                FileContent.InnerHtml = "<div class=\"divContent\">" + sHTML + "</div>";
            }
        }
    }
}
