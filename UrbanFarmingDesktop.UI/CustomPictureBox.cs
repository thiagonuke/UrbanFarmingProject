using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFarmingDesktop.UI
{
    public class CustomPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            // Desabilita a borda
            this.SetStyle(ControlStyles.UserPaint, true);
            base.OnPaint(pe);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            // Remove o foco
            this.Parent.Focus();
            base.OnGotFocus(e);
        }
    }
}
