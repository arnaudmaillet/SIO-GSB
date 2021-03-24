using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Contrôle de l'existence du serveur de base de données et de la base GSB
           
            if (Passerelle.testConnexion(out string message))
            {
                FrmConnexion unFrmConnexion = new FrmConnexion();
                Application.Run(unFrmConnexion);
            } else
            {
                MessageBox.Show(message, "L'application ne peut être lancée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
