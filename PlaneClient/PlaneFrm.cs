using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlaneClient
{

    public partial class PlaneFrm : Telerik.WinControls.UI.RadForm
    {
        phuongkhoa.PlaneService planeService = new phuongkhoa.PlaneService();
        public PlaneFrm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlaneFrm_Load(object sender, EventArgs e)
        {
          List<phuongkhoa.Plane> planes = planeService.GetAll().ToList();
            gvplane.DataSource = planes;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<phuongkhoa.Plane> planes = planeService.Search(keyword).ToList();
            gvplane.DataSource = planes;
        }

        private void gvplane_SelectionChanged(object sender, EventArgs e)
        {

            if (gvplane.SelectedRows.Count > 0)
            {
                int Id = int.Parse(gvplane.SelectedRows[0].Cells["Id"].Value.ToString());
                phuongkhoa.Plane plane = planeService.GetDetails(Id);
                if (plane != null)
                {
                    txtId.Text = plane.Id.ToString();
                    txtBrand.Text = plane.Brand;
                    txtName.Text = plane.Name;
                    txtPrice.Text = plane.Price.ToString();
                    txtSize.Text = plane.Size.ToString();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            phuongkhoa.Plane newPlane = new phuongkhoa.Plane()
            {
                Id = int.Parse(txtId.Text.Trim()),
                Brand = txtBrand.Text.Trim(),
                Name = txtName.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Size = int.Parse(txtSize.Text.Trim())
            };
            bool result = planeService.Update(newPlane);
            if(result)
            {
                List<phuongkhoa.Plane> planes = planeService.GetAll().ToList();
                gvplane.DataSource = planes;
            }
            else
            {
                MessageBox.Show("Please Again");
            }
        }

        private void Btnadd_Click(object sender, EventArgs e)
        {
            phuongkhoa.Plane newPlane = new phuongkhoa.Plane()
            {
                Id = 0,
                Brand = txtBrand.Text.Trim(),
                Name = txtName.Text.Trim(),
                Price = int.Parse(txtPrice.Text.Trim()),
                Size = int.Parse(txtSize.Text.Trim())
            };
            bool result = planeService.AddNew(newPlane);
            if (result)
            {
                List<phuongkhoa.Plane> planes = planeService.GetAll().ToList();
                gvplane.DataSource = planes;
            }
            else { MessageBox.Show("Sorry please again"); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chaa8c1 muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int id = int.Parse(txtId.Text);
                bool result = planeService.Delete(id);
                if (result)
                {
                    List<phuongkhoa.Plane> planes = planeService.GetAll().ToList();
                    gvplane.DataSource = planes;
                }
                else { MessageBox.Show("Sorry please again"); }
            }
        }
    }
}
