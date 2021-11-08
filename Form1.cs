using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> _Buffer = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void update()
        {
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox1.Items.Add(crrfile);
            }
        }

        //Загрузка файлов и папок  - кнопка "Перейти"
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += '\\';
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox1.Items.Add(crrfile);
            }

        }

        //двойной щелчок по элементу listBox
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Path.GetExtension(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString())) == "")
            {
                textBox1.Text = Path.Combine(textBox1.Text + '\\' + listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(textBox1.Text);


                foreach (DirectoryInfo crrDir in dir.GetDirectories())
                {
                    listBox1.Items.Add(crrDir);
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo crrfile in files)
                {
                    listBox1.Items.Add(crrfile);
                }
            }
            else
            {
                try
                {
                    Process.Start(Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString()));
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("Формат не поддерживается");
                }
            }
        }
        //загрузка файлов и папок - кнопка "Назад"
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '\\')
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            else if (textBox1.Text[textBox1.Text.Length - 1] != '\\')
            {
                while (textBox1.Text[textBox1.Text.Length - 1] != '\\')
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                }
            }
            listBox1.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] dirs = dir.GetDirectories();

            foreach (DirectoryInfo crrDir in dirs)
            {
                listBox1.Items.Add(crrDir);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo crrfile in files)
            {
                listBox1.Items.Add(crrfile);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }



        private void clearMenuItem3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }







        private void label1_Click(object sender, EventArgs e)//Документы
        {
            textBox1.Text = "C:\\Users\\Anetcod\\Documents\\"; button1_Click(sender, e);

        }

        private void label2_Click(object sender, EventArgs e)//Видео
        {
            textBox1.Text = "C:\\Users\\Anetcod\\Videos"; button1_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)//Dropbox
        {
            textBox1.Text = "C:\\Users\\rusta\\Dropbox\\"; button1_Click(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Users\\"; button1_Click(sender, e);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "C:"; button1_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "D:"; button1_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Users\\rusta\\Music"; button1_Click(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Users\\rusta\\3D Objects\\"; button1_Click(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Users\\rusta\\Favorites"; button1_Click(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Users\\rusta\\Downloads"; button1_Click(sender, e);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)//создать текстовый документ
        {

            File.Create("C:\\Users\\rusta\\Documents\\");
            File.Create("C:\\Users\\rusta\\Favorites\\");
            File.Create("C:\\Users\\rusta\\Downloads\\");
            File.Create("C:\\Users\\rusta\\Music\\");
            File.Create("C:\\Users\\rusta\\3D Objects\\");
            File.Create("C:\\Users\\rusta\\Dropbox\\");
            File.Create("C:\\Users\\");
            File.Create("C:\\Users\\rusta\\Videos\\");
            string file = null;
            File.SetAttributes(file, FileAttributes.Normal);
            File.Create("new_file.txt");

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)//удалить текстовый документ
        {
            if (listBox1.SelectedItem.ToString() != null)
            { remove(textBox1.Text + '\\' + listBox1.SelectedItem.ToString()); }
            else
            {
                remove(textBox1.Text);
            }
            update();

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
           var Form2 = new Form2();
            Form2.Show();
            Directory.CreateDirectory("C:\\Users\\rusta\\Documents\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Documents\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Favorites\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Downloads\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Music\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\3D Objects\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Dropbox\\");
            Directory.CreateDirectory("C:\\Users\\");
            Directory.CreateDirectory("C:\\Users\\rusta\\Videos\\");
        }

        public void remove_file(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                MessageBox.Show("This is a not file");
            }

            System.IO.File.Delete(path);
        }

        private void remove_folder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                remove_folder(di.FullName);

                di.Delete();
            }
            dir.Delete(true);
        }

        public void remove(string path)
        {
            if (System.IO.File.Exists(path))
            {
                remove_file(path);
            }

            else if (System.IO.Directory.Exists(path))
            {
                remove_folder(path);
            }
        }

        private void rename(string path, string name, string new_name)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Move(Path.Combine(path, name), Path.Combine(path, new_name));
            }

            else if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Move(Path.Combine(path, name), Path.Combine(path, new_name));
            }
            

        }

        public void buffer_clear()
        {
            _Buffer.Clear();
        }

        public void copy(string path)
        {
            buffer_clear();

            if (System.IO.File.Exists(path))
            {
                _Buffer.Add(path);
            }

            else if (System.IO.Directory.Exists(path))
            {
                foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
                {
                    _Buffer.Add(file.ToString());
                }
            }
        }

        public void paste(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return;
            }

            else if (System.IO.Directory.Exists(path))
            {
                foreach (string _ in _Buffer)
                {
                    string[] __ = _.Split('\\');

                    System.IO.File.Copy(_, path + "\\" + __[__.Length - 1]);
                }
            }
            update();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e){}

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button3.Visible = true;
            listBox1.Visible = false;
            treeView1.Visible = false;
            textBox1.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }


        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            { copy(textBox1.Text + '\\' + listBox1.SelectedItem.ToString()); }
            else
            {
                copy(textBox1.Text);
            }
            update();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            { paste(textBox1.Text + '\\' + listBox1.SelectedItem.ToString());}
            else
            {
                paste(textBox1.Text);
            }
            update();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox2.Visible = false;
            button3.Visible = false;
            listBox1.Visible = true;
            treeView1.Visible = true;
            textBox1.Visible = true;
            button2.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            rename(textBox1.Text, listBox1.SelectedItem.ToString(), textBox2.Text);
            update();
        }
    }
}
