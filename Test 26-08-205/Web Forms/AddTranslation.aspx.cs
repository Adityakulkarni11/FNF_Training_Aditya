using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchWord
{
    public partial class AddTranslation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string word = Request.QueryString["word"];
            lblWord.Text = $"Word: {word}";
            if (!IsPostBack)
            {
                var wordList = WordSearch.wordList;

                var displayList = new List<object>();
                foreach (var entry in wordList)
                {
                    displayList.Add(new { Word = entry.Key, Translation = entry.Value });
                }

                Words.DataSource = displayList;
                Words.DataBind();
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string word = Request.QueryString["Word"];
            string translation = txtTranslation.Text.Trim();

            WordSearch.wordList[word] = translation;

            var wordList = WordSearch.wordList;

            var displayList = new List<object>();
            foreach (var str in wordList)
            {
                displayList.Add(new 
                {
                    Word = str.Key,
                    Translation = str.Value
                });
            }
            Words.DataSource = displayList;
            Words.DataBind();
        }
    }
}