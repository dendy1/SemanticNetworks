using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SemanticNetworksLibrary.Semantic_Network;

namespace SemanticNetworksLibrary.Misc
{
    public class Utils
    {
        public static void EnableDoubleBuffer(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                control,
                new object[] { true });
        }

        public static SizeF CalculateWidth(Font font, Graphics graphics, int numOfLines, string text)
        {
            SizeF sizeFull = graphics.MeasureString(text, font,
                      new SizeF(
                       float.PositiveInfinity,
                       float.PositiveInfinity),
                      StringFormat.
                       GenericTypographic);

            float width = sizeFull.Width / numOfLines;
            float averageWidth = sizeFull.Width / text.Length;
            int charsFitted;
            int linesFilled;

            SizeF needed = graphics.MeasureString(text, font,
                      new SizeF(width,
                        float.
                         PositiveInfinity),
                      StringFormat.
                       GenericTypographic,
                      out charsFitted,
                      out linesFilled);

            while (linesFilled > numOfLines)
            {
                width += averageWidth;
                needed = graphics.MeasureString(text, font,
                        new SizeF(width,
                           float.PositiveInfinity),
                        StringFormat.GenericTypographic,
                        out charsFitted, out linesFilled);
            }

            return needed;
        }

        public static IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                .Concat(controls)
                .Where(c => c.GetType() == type);
        }
    }
}
