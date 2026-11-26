using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cw4_layuot.Pages
{
    public class Form1Model : PageModel
    {
        public string Result { get; set; } ="";
        public void OnGet()
        {
            // tutaj jest wyświetlanie pustego formularza

        }
        public void OnPost()
        {
            //przetwarzanie danych z formularza
            var count = Request.Form["count"];
            int resultCount = Convert.ToInt32(count);
            List<int> numbers = new();
            for (int i = 0; i < resultCount; i++)
            {
                numbers.Add(i * 2);
            }
            Result = String.Join(" ",numbers);
        }
    }
}
