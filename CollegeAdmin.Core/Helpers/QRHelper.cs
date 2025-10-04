using QRCoder;
using System.Drawing;
using System.IO;

namespace CollegeAdmin.Core.Helpers
{
    public static class QRHelper
    {
        public static byte[] GenerateQRCode(string content)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData); // <-- используем PngByteQRCode вместо QRCode
            return qrCode.GetGraphic(20);
        }
    }
}












