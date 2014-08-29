using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMvvm;
using System.Data.OleDb;
using System.Data;
using System.Windows;

namespace TeachMe.viewmodels
{
    class verbosViewModel : ObservableObject, IDataErrorInfo
    {
        private Dictionary<String, List<String>> dictionary;

        public verbosViewModel()
        {
            rellenarDictionary(dictionary);
        }

        #region Commandss

        public void rellenarDictionary(Dictionary<String, List<String>> dictionary)
        {
            string[] array = new string[3];

            List<String> hola = new List<string>();

            hola.Add("hello");
            hola.Add("hi");
            hola.Add("hallo");
            

            dictionary.Add("hola", hola);



            //Leer fichero
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [Hoja1$]";

            //Cadena para excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source=' ../verbs/irregularverbs.xlsx ';Extended Properties=Excel 12.0;";

            try
            {
                conexion = new OleDbConnection(cadenaConexionArchivoExcel);
                conexion.Open();
                dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion);
                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Hoja1");
                conexion.Close();

                foreach(DataRow d in dataSet.Tables[0].Rows)
                {
                    MessageBox.Show(d[0].ToString());
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
            }

        }

        #endregion
    }
}
