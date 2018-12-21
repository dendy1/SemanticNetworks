using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SemanticNetworksLibrary.Misc
{
    public class MyToolTip : ToolTip
    {
        public Image BackGroundImage { get; set; }
        public MyToolTip(Image BackGroundImage)
        {
            this.OwnerDraw = true;
            this.Popup += OnPopup;
            this.Draw += OnDraw;
            this.BackGroundImage = BackGroundImage;
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawImage(BackGroundImage, 0, 0);
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = BackGroundImage.Size;
        }
    }
}
