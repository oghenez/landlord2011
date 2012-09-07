using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Landlord2.UI
{
    public partial class UCBase : UserControl
    {
        private IPalette _palette;
        public UCBase()
        {
            // To remove flicker we use double buffering for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);

            // Cache the current global palette setting
            _palette = KryptonManager.CurrentGlobalPalette;

            // Hook into palette events
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // We want to be notified whenever the global palette changes
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            InitializeComponent();
        }

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unhook from the palette events
                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                // Unhook from the static events, otherwise we cannot be garbage collected
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            // Unhook events from old palette
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // Cache the new IPalette that is the global palette
            _palette = KryptonManager.CurrentGlobalPalette;

            // Hook into events for the new palette
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // Change of palette means we should repaint to show any changes
            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            // Palette indicates we might need to repaint, so lets do it
            Invalidate();
        }

        #region 使加载的控件居中
        protected void UCBase_Layout(object sender, LayoutEventArgs e)
        {       
            switch (Controls.Count)
            {
                case 0:
                    break;
                case 1://唯一加载控件
                    {
                        var control = Controls[0];
                        if (control.Dock != DockStyle.Fill)
                        {
                            int x = (Width - control.Width) / 2;
                            int y = (Height - control.Height) / 2;
                            x = (x > 0) ? x : 0;
                            y = (y > 0) ? y : 0;
                            control.SetBounds(x, y, control.Width, control.Height);
                        }
                    }
                    break;
                case 2://2个控件，第一个为菜单，第二个才是需要调整的
                    {
                        var control0 = Controls[0];
                        var control1 = Controls[1];
                        if (control1.Dock != DockStyle.Fill)
                        {
                            int x = (Width - control1.Width) / 2;
                            int y = (Height - control1.Height - control0.Height) / 2;
                            x = (x > 0) ? x : 0;
                            y = (y > 0) ? y : 0;
                            control1.SetBounds(x, y + control0.Height, control1.Width, control1.Height);
                        }
                    }
                    break;
                default:
                    {
                        KryptonMessageBox.Show("超过2个控件的加载");
                    }
                    break;
            }            
        } 
        #endregion

       
    }

    //自定义的双缓冲Panel
    public class DoubleBufferdPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferdPanel()
            : base()
        {
            //配置双缓冲
            base.SetStyle(ControlStyles.UserPaint |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.OptimizedDoubleBuffer |
                        ControlStyles.ResizeRedraw |
                        ControlStyles.SupportsTransparentBackColor, true);
            base.UpdateStyles();
        }
    }
}
