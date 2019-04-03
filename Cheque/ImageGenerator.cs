using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cheque
{
    public class ImageGenerator
    {
        public static void RenderHTML(string html, string outputPath, Rectangle crop)
        {

            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.DocumentText = html;
            wb.Refresh();
            while (wb.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            wb.Width = wb.Document.Body.ScrollRectangle.Width;
            wb.Height = wb.Document.Body.ScrollRectangle.Height;
            using (Bitmap bitmap = new Bitmap(wb.Width, wb.Height))
            {
                wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
                wb.Dispose();
                Rectangle rect = new Rectangle(crop.Left, crop.Top, wb.Width - crop.Width - crop.Left, wb.Height - crop.Height - crop.Top);
                Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
                cropped.Save(outputPath, ImageFormat.Png);
            }
        }
    }
}
