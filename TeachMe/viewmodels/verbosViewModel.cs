using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMvvm;

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
        }

        #endregion
    }
}
