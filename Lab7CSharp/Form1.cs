using System.Windows.Forms;

namespace LR7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                comboBox1.Items.Add(textBox1.Text);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Введіть текст елементу.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Items.RemoveAt(comboBox1.Items.Count - 1);
            }
            else
            {
                MessageBox.Show("Немає елементів для видалення.");
            }
        }


        // Завдання друге

        private Bitmap originalImage;
        private Bitmap grayscaleImage;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openDlg.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (grayscaleImage == null)
            {
                MessageBox.Show("Спочатку потрібно перетворити зображення.");
                return;
            }

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                grayscaleImage.Save(saveDlg.FileName);
                MessageBox.Show("Зображення збережено.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Будь ласка, відкрийте зображення спочатку.");
                return;
            }

            grayscaleImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    int grayValue = (int)((originalColor.R + originalColor.G + originalColor.B) / 3);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);

                    grayscaleImage.SetPixel(x, y, grayColor);
                }
            }

            pictureBox1.Image = grayscaleImage;
        }

        // Завдання третє
        private Figure[] figures;
        private Random rand = new Random();
        private Bitmap bmp;
        private void button6_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            figures = new Figure[n];

            bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(20, pictureBox2.Width - 40);
                int y = rand.Next(20, pictureBox2.Height - 40);
                Color color = Color.FromName(comboBox3.SelectedItem.ToString());
                string text = textBox3.Text;

                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Square":
                        figures[i] = new Square(x, y, color, text, int.Parse(textBox4.Text));
                        break;
                    case "Rectangle":
                        figures[i] = new Rectangle(x, y, color, text, int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                        break;
                    case "Ellipse":
                        figures[i] = new Ellipse(x, y, color, text, int.Parse(textBox7.Text), int.Parse(textBox8.Text));
            break;
                    case "Rhombus":
                        figures[i] = new Rhombus(x, y, color, text, int.Parse(textBox9.Text));
                        break;
                }
                figures[i].Draw(g);
            }
            pictureBox2.Image = bmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            figures = new Figure[n];

            if (bmp == null)
                bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(20, pictureBox2.Width - 40);
                int y = rand.Next(20, pictureBox2.Height - 40);
                Color color = Color.FromName(comboBox3.SelectedItem.ToString());
                string text = textBox3.Text;

                switch (comboBox2.SelectedItem.ToString())
                {
                    case "Square":
                        figures[i] = new Square(x, y, color, text, int.Parse(textBox4.Text));
                        break;
                    case "Rectangle":
                        figures[i] = new Rectangle(x, y, color, text, int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                        break;
                    case "Ellipse":
                        figures[i] = new Ellipse(x, y, color, text, int.Parse(textBox7.Text), int.Parse(textBox8.Text));
                        break;
                    case "Rhombus":
                        figures[i] = new Rhombus(x, y, color, text, int.Parse(textBox9.Text));
                        break;
                }
                figures[i].Draw(g);
            }
            pictureBox2.Image = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            bmp = null;

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }
    }
}
