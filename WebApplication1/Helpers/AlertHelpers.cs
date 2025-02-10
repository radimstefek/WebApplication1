/*using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Helpers
{
    public class AlertHelpers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
*/


using System;
using System.IO;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class AlertHelpers
    {
        // Nastavte zde správné heslo (pro demo použijeme "heslo123")
        private const string CorrectPassword = "heslo123";

        // Cesta k souboru Alert.txt (uloženému v kořenovém adresáři aplikace)
        private static readonly string AlertFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Alert.txt");

        public static (bool, string) GetAlertSettings()
        {
            try
            {
                if (File.Exists(AlertFilePath))
                {
                    string[] lines = File.ReadAllLines(AlertFilePath);
                    if (lines.Length >= 2 && bool.TryParse(lines[0], out bool isEnabled))
                    {
                        return (isEnabled, lines[1]);
                    }
                }
            }
            catch (Exception)
            {
                // Logujte chybu nebo proveďte další zpracování
            }
            return (false, string.Empty);
        }

        /// <summary>
        /// Ověří, zda zadané heslo odpovídá požadovanému.
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            return password == CorrectPassword;
        }

        /// <summary>
        /// Uloží nastavení alertu do souboru Alert.txt.
        /// První řádek bude obsahovat true/false (stav zapnutí alertu),
        /// druhý řádek text alertu.
        /// </summary>
        public static bool SaveAlert(Alert alert)
        {
            try
            {
                string content = $"{alert.IsEnabled}\n{alert.Text}";
                File.WriteAllText(AlertFilePath, content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
