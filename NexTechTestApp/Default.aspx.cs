using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using NexTechCore;
using NexTechInfrastructure;
using System.Diagnostics;
using System.Data;

namespace NexTechTestApp
{
    public partial class _Default : Page
    {

        static List<Article> originalArticles;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtSearchTerm.Focus();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedField = ddlField.SelectedValue;
            string searchTerm = txtSearchTerm.Text.Trim().ToLower();
            PropertyInfo piSelectedField = typeof(Article).GetProperty(selectedField);
            List<PropertyInfo> props = new List<PropertyInfo>();
            List<Article> articles = new List<Article>();

            //if the user didn't provide a value, show an error message
            if (!string.IsNullOrEmpty(searchTerm))
            {
                //if the selected field to search is set to all, look at every property of the team, otherwise only look at the requested property
                if (selectedField == "All")
                {
                    props.AddRange((typeof(Article).GetProperties()).ToList());
                }
                else
                {
                    props.Add(piSelectedField);
                }

                foreach (PropertyInfo p in props)
                {
                    articles.AddRange(originalArticles.Where(t => (p.GetValue(t)?.ToString()?.ToLower())?.Contains(searchTerm) ?? false).ToList());
                }

                //using distinct incase a team has the same value in multiple fields
                grdArticles.DataSource = articles.Distinct().OrderBy(t => t.Title);
                grdArticles.DataBind();
            }
            else
            {
                lblError.Text = "Please enter a search term that containes letters or numbers";
                lblError.Visible = true;
            }
            btnSearch.Enabled = true;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchTerm.Text = "";
            ddlField.SelectedValue = "All";
            grdArticles.DataSource = originalArticles;
            grdArticles.DataBind();
            txtSearchTerm.Focus();
            btnReset.Enabled = true;
        }


        protected void btnGetArticles_Click(object sender, EventArgs e)
        {
            btnGetArticles.Enabled = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //try accessing the web api, if there is an issue, show an error message to the user
            try
            {
                originalArticles = HackerNewsService.GetNewArticles();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
            finally
            {
                //if we were not able to get articles, we still want the button to be enabled so the user can try again
                btnGetArticles.Enabled = true;
            }

            grdArticles.DataSource = originalArticles;
            grdArticles.DataBind();

            stopwatch.Stop();
            lblTime.Text = "Article Retrive Took: " + stopwatch.Elapsed.ToString();
            lblTime.Visible = true;

            //now that we have content, enable searching
            btnSearch.Enabled = true;
            btnReset.Enabled = true;
        }

        protected void grdArticles_DataBound(object sender, EventArgs e)
        {
            lblResults.Text = "Total Results: " + grdArticles.Rows.Count;
            lblResults.Visible = true;
        }
    }
}