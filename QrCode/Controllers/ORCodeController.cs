using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QrCode.Controllers
{
    public class ORCodeController : Controller
    {
        // GET: ORCode
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetORImage(string content)
        {
            string timeStr = DateTime.Now.ToFileTime().ToString();
            Bitmap bitmap = QRCodeOp.QRCodeEncoderUtil(content);

            string fileName = Server.MapPath("~") + "Content\\Images\\QRImages\\" + timeStr + ".jpg";

            if (!Directory.Exists(Path.Combine(Server.MapPath("~"), "\\Content\\Images\\QRImages\\")))
            {
                Directory.CreateDirectory(Path.Combine(Server.MapPath("~"), "\\Content\\Images\\QRImages\\"));
            }

            bitmap.Save(fileName);//保存位图
            string imageUrl = "/Content/Images/QRImages/" + timeStr + ".jpg";//显示图片  
            return Content(imageUrl);
        }

        public ActionResult GetORImageContent(string imageName)
        {
            string fileUrl = Server.MapPath("~") + "Content\\Images\\QRImages\\" + imageName;
            Bitmap bitMap = new Bitmap(fileUrl);
            string content = QRCodeOp.QRCodeDecodeUtil(bitMap);

            return Content(content);
        }

    }
}