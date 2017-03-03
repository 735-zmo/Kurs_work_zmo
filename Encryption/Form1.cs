using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption
{
    public partial class Form1 : Form
    {
        private string fn = string.Empty;

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Текст|*.txt";
            saveFileDialog1.Title = "Сохранить документ";

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Текст|*.txt";
            openFileDialog1.Title = "Открыть документ";
            openFileDialog1.Multiselect = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fn = string.Empty;
            SaveDocument();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenDocument()
        {
            openFileDialog1.FileName = string.Empty;

            // отобразить диалог Открыть
            if (openFileDialog1.ShowDialog() ==
                                DialogResult.OK)
            {
                fn = openFileDialog1.FileName;

                try
                {
                    // считываем данные из файла
                    System.IO.StreamReader sr =
                        new System.IO.StreamReader(fn);

                    string strf = sr.ReadToEnd();

                    if (strf.Length == 0)
                    {
                        MessageBox.Show("Файл пуст!\n", "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }

                    if (strf.Length >= 3000)
                    {
                        MessageBox.Show("Превышено максимальное количество символов в файле\n", "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        return;
                    }

                    for (int i = 0; i < strf.Length; i++)
                    {
                        if ((strf[i] != '0') && (strf[i] != '1'))
                        {
                            MessageBox.Show("Файл содержит недопустимые символы или текст записан в несколько строк. Повторите попытку с файлом, содержащим только символы '0' и '1', записанными в одну строку!", "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    textBox1.Text = strf;
                    textBox1.SelectionStart = textBox1.TextLength;

                    sr.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ошибка чтения файла.\n" +
                        exc.ToString(), "Ошибка!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        private int SaveDocument()
        {
            
                // отобразить диалог Сохранить
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   fn = saveFileDialog1.FileName;
                }
                else 
                {
                   return 0;
                }

                // сохранить файл
            
                System.IO.FileInfo fi =
                new System.IO.FileInfo(fn);
                System.IO.StreamWriter sw = fi.CreateText();
                sw.Write(textBox2.Text);
                sw.Close();
                    
                return 0;           
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Поле \"Исходная последовательность\" не может быть пустым!", "Ошибка!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if ((textBox1.Text[i] != '0') && (textBox1.Text[i] != '1'))
                {
                    MessageBox.Show("Поле \"Исходная последовательность\" может содержать только символы: '0' и '1'!", "Ошибка!", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (radioButton1.Checked == true)
            {
                string a_1 = textBox1.Text;

                string a_12 = a_1;

                StringBuilder a = new StringBuilder(a_1);

                StringBuilder b = new StringBuilder(a_12);

                b[0] = a[0];

                for (int i = 1; i < a.Length - 1; i++)
                {
                    if (a[i] == a[i - 1])
                    {
                        b[i] = '1';
                    }
                    else
                    {
                        b[i] = '0';
                    }

                }

                string a_2 = b.ToString();

                textBox2.Text = a_2;
           
            }
            else if (radioButton2.Checked == true)
            {
                string a_1 = textBox1.Text;

                string a_12 = a_1;

                StringBuilder a = new StringBuilder(a_1);

                StringBuilder b = new StringBuilder(a_12);
                b[0] = a[0];

                for (int i = 1; i < a.Length; i++)
                {
                    if ((a[i] == '0') && (b[i - 1] == '1') || (a[i] == '1') && (b[i - 1] == '0'))
                    {
                        b[i] = '0';
                    }

                    if ((a[i] == '0') && (b[i - 1] == '0') || ((a[i] == '1') && (b[i - 1] == '1')))
                    {
                        b[i] = '1';
                    }
                    
                    string a_2 = b.ToString();

                    textBox2.Text = a_2;
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // цукуыавапавпавпавпавпавпавпвапаврпопопооооооооооооооо
            OpenDocument();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        
        }
    }