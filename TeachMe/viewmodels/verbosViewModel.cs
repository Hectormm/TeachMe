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
using System.IO;

namespace TeachMe.viewmodels
{
    class verbosViewModel : ObservableObject, IDataErrorInfo
    {
        private Dictionary<String, List<String>> dictionary;

        public verbosViewModel()
        {
            dictionary = new Dictionary<String, List<String>>();
            dictionary = rellenarDictionary(dictionary);

            MessageBox.Show(dictionary.Count.ToString());

            verboAlAzar(dictionary);

            /* foreach (KeyValuePair<string, List<String>> result in dictionary)
           {
               Console.WriteLine(string.Format("Key-{0}:Value-{1}", result.Key, result.Value));
               MessageBox.Show("Key: " + result.Key);

               foreach(string a in result.Value)
               {
                   MessageBox.Show(a);
               }
           }*/
           
        }

        #region Validation

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get { return IsValid(propertyName); }
        }

        private bool validarNombre = false;
        private bool validarDescripcion = false;

        private string IsValid(string propertyName)
        {
            if (propertyName == "Nombre")
            {
                if (validarNombre)
                {
                    if (!this.nombre.Equals("be"))
                    {
                        Color = "Red";
                        return "El campo Nombre no puede estar vacío.";
                    }
                    Color = "Green";
                    
                }
                else
                {
                    validarNombre = !validarNombre;
                }
            }
            return null;
        }

        public bool IsValid()
        {
            bool correcto = this.nombre.Equals("be");
            if (!correcto)
            {
                RaisePropertyChanged("Nombre");
                RaisePropertyChanged("Color");
            }
            return correcto;
        }

        #endregion

        #region Properties

        private string nombre;
        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                RaisePropertyChanged("Nombre");
            }
        }

        private string color = "White";

        public String Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }

        #endregion

        #region Commandss

        public Dictionary<String, List<String>> rellenarDictionary(Dictionary<String, List<String>> dictionary)
        {
            List<String> verbosIngles = new List<string>();
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + @"..\..\verbs\irregularverbs.txt");

            while((line = file.ReadLine()) != null)
            {
                verbosIngles = new List<string>();

                string[] palabras = new string[4];

                palabras = line.Split('\t');

                verbosIngles.Add(palabras[1]);
                verbosIngles.Add(palabras[2]);
                verbosIngles.Add(palabras[3]);

                dictionary.Add(palabras[0], verbosIngles);
            }

            return dictionary;

        }

        public void verboAlAzar(Dictionary<String, List<String>> dictionary)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, dictionary.Count+1);

            int i = 1;
            foreach (KeyValuePair<string, List<String>> result in dictionary)
           {
                if(i == randomNumber)
                {
                    nombre = result.Value.Last();
                }

               i++;
           }
        }

        #endregion
    }
}
