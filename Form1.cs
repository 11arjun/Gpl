namespace component1
{
    public partial class Form1 : Form
    {
        private string _filePath = null;
        private bool _fileSaved = true;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
    Graphics g;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void run_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                Parser.parse(textBox1.Lines[i], g);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Gray);
            textBox2.Text = "";
            textBox1.Text = "";
            Parser.clear();

        }
        private bool saveFile()
        {
            string code = textBox1.Text;
            if (_filePath == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "gpl files (*.gpl)|*.gpl|All files (*.*)|*.*";
                saveFileDialog.Title = "Save GPL";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    _filePath = saveFileDialog.FileName;
                    using (StreamWriter sw = new StreamWriter(_filePath))
                        sw.WriteLine(code);
                    _fileSaved = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                    sw.WriteLine(code);
                _fileSaved = true;
                return true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            string command = textBox2.Text.ToLower().Split(',')[0];
            if (e.KeyCode == Keys.Enter)
            {
                switch (command)
                {
                    case "clear":
                        g.Clear(Color.Gray);
                        Parser.clear();
                        break;
                    case "reset":
                        g.Clear(Color.Gray);
                        Parser.clear();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        break;
                    case "run":
                        run_Click(sender, e);
                        break;
                    default:
                        MessageBox.Show("Unknown Command", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                e.SuppressKeyPress = true;
            }

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Save current file before proceeding?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!saveFile())
                        return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "gpl files (*.gpl)|*.gpl|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        textBox1.Text = reader.ReadToEnd();
                    }

                    _fileSaved = true;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_fileSaved)
            {
                DialogResult dialogResult = MessageBox.Show("Save current file before proceeding?", "Changes not saved", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (!saveFile())
                        return;
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            Application.Exit();
        }

        private void textProgramBox_TextChanged(object sender, EventArgs e)
        {
            _fileSaved = false;
        }

       
    }
}