using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Configuration
{
    public partial class UserControl1 : UserControl
    {
        CVehicleConfiguration currentCV;
        CVehicleConfiguration newCV;
        DBVehicleConfiguration DBCV;
        public UserControl1()
        {
            InitializeComponent();
            currentCV = new CVehicleConfiguration();
            newCV = new CVehicleConfiguration();
            DBCV = new DBVehicleConfiguration();
           currentCV= DBCV.populateData(currentCV);
        }

        private void fillTableAdapter() {
          
            tblFuelBrandTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblFuelBrand);
            tblFuelOctaneTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblFuelOctane);
            tblPropellentTypeTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblPropellentType);

            tblVehicleMakeTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblVehicleMake);
            tblVehicleModelTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblVehicleModel);
            tblVehicleCapacityTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblVehicleCapacity);
            tblVehicleYearTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblVehicleYear);
            tblVehicleTypeTableAdapter.Fill(this.cONFEROCLIENTDataSet.tblVehicleType);

            tblTyreBrandTableAdapter.Fill(cONFEROCLIENTDataSet.tblTyreBrand);
            tblTyreModelTableAdapter.Fill(cONFEROCLIENTDataSet.tblTyreModel);
            tblTyreType.Fill(cONFEROCLIENTDataSet.tblTyreType);
            tblTyreSizeTableAdapter.Fill(cONFEROCLIENTDataSet.tblTyreSize);
            tblTyreWidthTableAdapter.Fill(cONFEROCLIENTDataSet.tblTyreWidth);
            tblTyreMaterialTableAdapter.Fill(cONFEROCLIENTDataSet.tblTyreMaterial);

            viewCurrentConfigurationTableAdapter.Fill(this.cONFEROCLIENTDataSetView.viewCurrentConfiguration);

        }
     

        private void UserControl1_Load(object sender, EventArgs e)
        {
            fillTableAdapter();
            //need to fill the textbox for rolling resistance also
          txbxRollingResistance.Text=  DBCV.getCurrentRollingResistance();
          txbxPassengerWeight.Text = DBCV.getWeight().ToString();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
     
        }

        

        private void txbxPassengerWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbxRollingResistance_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            getAllSelectedValues();
            DBCV.updateDatabase(currentCV, newCV);
            MessageBox.Show("Configuration updated");
        }

        private void getAllSelectedValues() {
            newCV.Propellentbrand = cbFuel.SelectedValue.ToString();
            newCV.Propellentoctane = cbOctane.SelectedValue.ToString();
            newCV.Propellenttype = cbFuelType.SelectedValue.ToString();
            newCV.Tyrebrand = cbTyreBrand.SelectedValue.ToString();
            newCV.Tyrematerial = cbTyreMaterial.SelectedValue.ToString();
            newCV.Tyremodel = cbTyreModel.SelectedValue.ToString();
            newCV.Tyrerollingresistance = txbxRollingResistance.Text;
            newCV.Tyresize = cbTyreSize.SelectedValue.ToString();
            newCV.Tyretype = cbTyreType.SelectedValue.ToString();
            newCV.Tyrewidth = cbTyreWidth.SelectedValue.ToString();
            newCV.Vehiclecapacity = cbCapacity.SelectedValue.ToString();
            newCV.Vehiclemake = cbMake.SelectedValue.ToString();
            newCV.Vehiclemodel =cbModel.SelectedValue.ToString();
            newCV.Vehicletype = cbType.SelectedValue.ToString();
            newCV.Vehicleyear = cbYear.SelectedValue.ToString();
            try
            {
                newCV.Weight = int.Parse(txbxPassengerWeight.Text.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
