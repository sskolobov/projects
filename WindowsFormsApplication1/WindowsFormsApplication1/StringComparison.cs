using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace StringSimilarity
{
    public partial class StringComparison : Form
    {
        public StringComparison()
        {
            InitializeComponent();
        }

        public static string PercentSimilarity(string str1, string str2)
        {
            if (str1 == "" || str2== "")
            {
                return "Одна из строк пуста!";
            }
            int diff;
            int[,] m = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                m[i, 0] = i;
            for (int j = 0; j <= str2.Length; j++)
                m[0, j] = j;
            for (int i = 1; i <= str1.Length; i++)
            {
                for (int j = 1; j <= str2.Length; j++)
                {
                    diff = (str1[i - 1].ToString().ToLower() == str2[j - 1].ToString().ToLower()) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                             m[i, j - 1] + 1),
                                             m[i - 1, j - 1] + diff);
                }
            }
            return (100 - ((100 * m[str1.Length, str2.Length]) / Math.Max(str1.Length, str2.Length))).ToString() + "%";
        }

        private void btn_Similarity_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Text format (*.txt)|*.txt";
            fd.Title = "Выберите файл для сравнения";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("Файл выбран", "Работа с файлами", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StreamReader sr = new StreamReader(fd.FileName, Encoding.Default);
                    StreamWriter sw = new StreamWriter(Path.GetDirectoryName(fd.FileName) +
                        Path.GetFileNameWithoutExtension(fd.FileName) + "Similarity" + Path.GetExtension(fd.FileName),
                        false, Encoding.Default);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arrStr = line.Split(',');
                        arrStr[0] = arrStr[0].Trim();
                        arrStr[1] = arrStr[1].Trim();
                        sw.WriteLine(PercentSimilarity(arrStr[0], arrStr[1]));
                    }
                    sr.Close();
                    sw.Close();
                    if (MessageBox.Show("Сравнение слов в файле завершено.", "Работа с файлами", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Process.Start(Path.GetDirectoryName(fd.FileName) +
                        Path.GetFileNameWithoutExtension(fd.FileName) + "Similarity" + Path.GetExtension(fd.FileName));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Работа с файлами", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}