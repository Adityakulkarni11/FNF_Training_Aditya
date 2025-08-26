using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchWord
{
    public partial class WordSearch : System.Web.UI.Page
    {

        public static Dictionary<string, string> wordList = new Dictionary<string, string>()
        {
            { "fun", "" },
            { "hello", "" },
            { "world", "" }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var word=txtSearchWord.Text.Trim().ToLower();
            if (wordList.ContainsKey(word))
            {
                Response.Redirect($"AddTranslation.aspx?Word={word}");
            }
            else
            {
                lblMessage.Text = $"{word} word is not present in the application. Please try another word.";
            }
        }
    }
}