using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using QRCoder;
using Image = System.Web.UI.WebControls.Image;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGenerate_OnClick(object sender, EventArgs e)
    {
        string Code = txtCode.Text;
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q);

        Image imgQrCode = new Image();
        imgQrCode.Height = 150;
        imgQrCode.Width = 150;

        using (Bitmap bitmap = qrCode.GetGraphic(20))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                imgQrCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
            }
           PHQRCode.Controls.Add(imgQrCode); 
        }

    }
}