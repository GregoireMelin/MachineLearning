using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projettaquin
{

    static class Program
    {
        // utilisation de deux instances sur les deux questions
        public static Entrepot entrepot { get; set; }
        public static Chariot[] tab_chariot { get; set; }
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Question_3(15,25,25));
      
        }
    }
}
