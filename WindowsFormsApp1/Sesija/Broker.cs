using System;
using System.Collections.Generic;
using Domen;
using System.Data;
using System.Data.OleDb;

namespace Sesija
{
    public class Broker
    {
        private static Broker instanca;
        private OleDbConnection konekcija;
        private OleDbCommand komanda;
        private Broker()
        {
            this.konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\NiD\Documents\Database4.accdb");
            this.komanda = konekcija.CreateCommand();

        }
        public static Broker DajSesiju()
        {
            if (instanca == null)
            {
                instanca = new Broker();
            }
            return instanca;
        }
        public List<Objekat1> VratiSveObjekte()
        {
            List<Objekat1> objekti = new List<Objekat1>();
            try
            {
                komanda.CommandText = "select id, atribut1 from Objekti";
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                OleDbDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Objekat1 objekat = new Objekat1
                    {
                        id = (int)citac["id"],
                        atribut1 = citac["atribut1"].ToString()
                    };
                    objekti.Add(objekat);

                }
                return objekti;
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }

            }
        }
        public int UbaciObjekatUBazu(Objekat1 objekat)
        {
            try
            {
                komanda.CommandText = String.Format("insert into Objekti values({0},'{1}')", objekat.id, objekat.atribut1);
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }
        public int IzmeniObjekat(Objekat1 objekat)
        {
            try
            {
                komanda.CommandText = "Update Objekti Set atribut1='" + objekat.atribut1 + "' Where id=" + objekat.id + "";
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
        public int IzbrisiObjekat(int id)
        {
            try
            {
                komanda.CommandText = "Delete from Objekti where id=" + id;
                komanda.CommandType = CommandType.Text;
                konekcija.Open();
                return komanda.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }
    }
}
