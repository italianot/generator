using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4
{
    public partial class Form1 : Form
    {
        List<DirectionColorfulEmiter> emiters = new List<DirectionColorfulEmiter>();


        public Form1()
        {
            InitializeComponent();
            tbspeed.Image = new Bitmap(tbspeed.Width, tbspeed.Height);


            var rnd = new Random();
            for (var i = 0; i < 50; ++i)
            {
                emiters.Add(new DirectionColorfulEmiter
                {
                    ParticlesCount = 20,
                    Position = new Point(rnd.Next(tbspeed.Width), -20),
                    Spread = 25,
                    Direction = 240,
                    Life = 10,
                    Radius= 4 + rnd.Next(5)
                }) ;
            }
            tbDirection.Value = 240;
            tbSpread.Value =25;
            tbint.Value = 10;
            tbsize.Value = 6;
        }

        private void UpdateState()
        {
            foreach (var emiter in emiters)
            {
                emiter.UpdateState();
            }
        }

        private void Render(Graphics g)
        {
            foreach (var emiter in emiters)
            {
                emiter.Render(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();

            using (var g = Graphics.FromImage(tbspeed.Image))
            {
                g.Clear(Color.Black);
                Render(g);
            }
            tbspeed.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            foreach (var emiter in emiters)
            {
                emiter.Direction = tbDirection.Value;
            }
        }

        private void tbSpread_Scroll(object sender, EventArgs e)
        {
            foreach (var emiter in emiters)
            {
                emiter.Spread = tbSpread.Value;
            }
        }

        private void btnFromColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // и тут
                foreach (var emiter in emiters)
                {
                    emiter.FromColor = dialog.Color;
                }
                btnFromColor.BackColor = dialog.Color;
            }
        }

        private void btnToColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // и даже тут
                foreach (var emiter in emiters)
                {
                    emiter.ToColor = dialog.Color;
                }
                btnToColor.BackColor = dialog.Color;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            foreach (var emiter in emiters)
            {
                emiter.Speed = trackBar1.Value;
            }
        }

        private void tbint_Scroll(object sender, EventArgs e)
        {
            foreach (var emiter in emiters)
            {
                emiter.Life = tbint.Value;
            }
        }

        private void tbsize_Scroll(object sender, EventArgs e)
        {
            foreach (var emiter in emiters)
            {
                emiter.Radius = tbsize.Value;
            }
        }
    }
}
