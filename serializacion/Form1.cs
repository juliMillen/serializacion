using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serializacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Usuario> lstUsuarios = new List<Usuario>();
        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fS = null;
            try
            {
                fS = new FileStream("usuarios.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (fS.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    lstUsuarios = (List<Usuario>)formatter.Deserialize(fS);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el archivo");
            }
            finally
            {
                if (fS != null)
                {
                    fS.Close();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fS = null;
            try
            {
                fS = new FileStream("usuarios.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fS, lstUsuarios);
            }
            catch(IOException)
            {
                MessageBox.Show("Error en el archivo");
            }
            finally
            {
                if (fS != null)
                {
                    fS.Close();
                }
            }
        }
    }
}
