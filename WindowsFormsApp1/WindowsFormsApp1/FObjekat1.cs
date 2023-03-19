using System;
using System.Windows.Forms;
using Domen;
using Sesija;

namespace WindowsFormsApp1
{
    public partial class FObjekat1 : Form
    {
        public FObjekat1()
        {
            InitializeComponent();
        }
        private void FObjekat1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Broker.DajSesiju().VratiSveObjekte();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    Objekat1 objekat = new Objekat1
                    {
                        id = int.Parse(textBox1.Text),
                        atribut1 = textBox2.Text,
                    };
                    try
                    {
                        int rezultat = Broker.DajSesiju().UbaciObjekatUBazu(objekat);
                        if (rezultat > 0)
                        {
                            MessageBox.Show("Uspesno ste dodali");
                        }
                        else
                        {
                            MessageBox.Show("Niste uspesno dodali");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Postoji problem", ex.Message);
                    }
                    dataGridView1.DataSource = Broker.DajSesiju().VratiSveObjekte();
                }
            }
            if (radioButton2.Checked)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    Objekat1 objekat = new Objekat1
                    {
                        id = int.Parse(textBox1.Text),
                        atribut1 = textBox2.Text,
                    };
                    try
                    {
                        int rezultat = Broker.DajSesiju().IzmeniObjekat(objekat);
                        if (rezultat > 0)
                        {
                            MessageBox.Show("Uspesno ste izmenili");
                        }
                        else
                        {
                            MessageBox.Show("Niste uspesno izmenili");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Postoji problem", ex.Message);
                    }
                    dataGridView1.DataSource = Broker.DajSesiju().VratiSveObjekte();
                }
            }
            if (radioButton3.Checked)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    try
                    {
                        int rezultat = Broker.DajSesiju().IzbrisiObjekat(int.Parse(textBox1.Text));
                        if (rezultat > 0)
                        {
                            MessageBox.Show("Uspesno ste izbrisali");
                        }
                        else
                        {
                            MessageBox.Show("Niste uspesno izbrisali");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Postoji problem", ex.Message);
                    }
                    dataGridView1.DataSource = Broker.DajSesiju().VratiSveObjekte();
                }
            }
        }
    }
}