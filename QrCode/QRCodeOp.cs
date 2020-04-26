using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace QrCode
{
    public class QRCodeOp
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="qrCodeContent"></param>
        /// <returns></returns>
        public static Bitmap QRCodeEncoderUtil(string qrCodeContent)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeVersion = 0;
            Bitmap bitmap  = qrCodeEncoder.Encode(qrCodeContent, Encoding.UTF8);

            return bitmap;
        }

        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static string QRCodeDecodeUtil(Bitmap bitmap)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();
            string decodeString = decoder.decode(new QRCodeBitmapImage(bitmap), Encoding.UTF8);

            return decodeString;
        }

    }
}