using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class AlertSettingsModel : PageModel
    {
        // Vlastnosti vázané na formulář
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string AlertToggle { get; set; }

        [BindProperty]
        public string AlertMessage { get; set; }

        // Tato vlastnost slouží k zobrazování stavové zprávy na stránce
        public string StatusMessage { get; set; }

        public void OnGet()
        {
            // Případně načtěte aktuální nastavení z Alert.txt, pokud je třeba
        }

        public IActionResult OnPost()
        {
            // Ověříme zadané heslo pomocí metody z AlertHelpers
            if (!AlertHelpers.ValidatePassword(Password))
            {
                StatusMessage = "Nesprávné heslo!";
                return Page();
            }

            // Vytvoříme instanci modelu Alert s nastavením z formuláře
            Alert alert = new Alert
            {
                IsEnabled = AlertToggle == "true",
                Text = AlertMessage
            };

            // Uložíme nastavení do souboru Alert.txt
            bool success = AlertHelpers.SaveAlert(alert);
            if (success)
            {
                StatusMessage = "Nastavení uloženo.";
            }
            else
            {
                StatusMessage = "Chyba při ukládání nastavení!";
            }
            return Page();
        }
    }
}