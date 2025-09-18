using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotnetFrameworkLib.Services;
using DotnetFrameworkLib.Entities;
using DotnetFrameworkLib.Utils;

namespace WebFormsApp
{
    public partial class LaptopManager : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();
            }
        }

        protected void AddLaptopButton_Click(object sender, EventArgs e)
        {
            //var laptopService = new LaptopService();
            var laptopService = ComponentFactory.GetComponent();
            var newLaptop = new Laptops
            {
                BrandName = txtBrand.Text,
                ModelName = txtModel.Text,
                Price = decimal.TryParse(txtPrice.Text, out var price) ? price : 0,
                SerialNumber = txtSerial.Text,
                EmpName = txtEmpName.Text
            };
            laptopService.AddLaptop(newLaptop);
            ClearInputs();
            RefreshGrid();
        }

        protected void LaptopGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            LaptopGridView.EditIndex = e.NewEditIndex;
            RefreshGrid();
        }

        protected void LaptopGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var laptopService = new LaptopService();
            var laptopService = ComponentFactory.GetComponent();
            int id = Convert.ToInt32(LaptopGridView.DataKeys[e.RowIndex].Value);
            GridViewRow row = LaptopGridView.Rows[e.RowIndex];

            string brand = ((TextBox)row.Cells[1].Controls[0]).Text;
            string model = ((TextBox)row.Cells[2].Controls[0]).Text;
            decimal price = decimal.TryParse(((TextBox)row.Cells[3].Controls[0]).Text, out var p) ? p : 0;
            string serial = ((TextBox)row.Cells[4].Controls[0]).Text;
            string empName = ((TextBox)row.Cells[5].Controls[0]).Text;

            var laptop = new Laptops
            {
                Id = id,
                BrandName = brand,
                ModelName = model,
                Price = price,
                SerialNumber = serial,
                EmpName = empName
            };
            laptopService.UpdateLaptop(laptop);

            LaptopGridView.EditIndex = -1;
            RefreshGrid();
        }

        protected void LaptopGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            LaptopGridView.EditIndex = -1;
            RefreshGrid();
        }

        protected void LaptopGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //var laptopService = new LaptopService();
            var laptopService = ComponentFactory.GetComponent();
            int id = Convert.ToInt32(LaptopGridView.DataKeys[e.RowIndex].Value);
            laptopService.RemoveLaptop(id);
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            //var laptopService = new LaptopService();
            var laptopService = ComponentFactory.GetComponent();
            LaptopGridView.DataSource = laptopService.GetAllLaptops();
            LaptopGridView.DataBind();
        }

        private void ClearInputs()
        {
            txtBrand.Text = "";
            txtModel.Text = "";
            txtPrice.Text = "";
            txtSerial.Text = "";
            txtEmpName.Text = "";
        }
    }
}
