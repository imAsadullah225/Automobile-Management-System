using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MetroFramework;
using System.IO;
using System.Drawing.Imaging;

namespace AutomobileManagementSys
{
    public partial class ManagementSysForm : Form
    {
        //---Start Management Form Constructors---\\

        public ManagementSysForm()
        {
            InitializeComponent();
            yearGenerator();
            cylindersNumbers();
            displayVendorsComobox();
            selectImage_Button.IconVisible = true;
            saveImage_Button.IconVisible = true;
        }

        #region class VehicleRegistration

        public class vehicleRegistration
        {
            protected string stockNo { get; set; }
            protected string mileage { get; set; }
            protected string year { get; set; }
            protected string color { get; set; }
            protected string vendor { get; set; }
            protected string model { get; set; }
            protected string fuelType { get; set; }
            protected string bodyType { get; set; }
            protected string transmission { get; set; }
            protected string cylinders { get; set; }
            protected string engineNo { get; set; }
            protected string chasisNo { get; set; }
            protected string purchaseDate { get; set; }
            protected string purchaseCountry { get; set; }
            protected string purchasedFrom { get; set; }
            protected string purchasedAmount { get; set; }
            protected string titleNumber { get; set; }
            protected string plateCity { get; set; }
            protected string plateState { get; set; }
            protected string titleHolder { get; set; }
            protected string contactNo { get; set; }
            protected ManagementSysForm managementForm;
        }

        public class vehicleBasicInformation : vehicleRegistration
        {
            public vehicleBasicInformation(string _stockNo,
                string _mileage, string _year, string _color, string _vendor, string _model, string _fuelType,
                string _bodyType, string _tranmission, string _cylinders,
                string _enginNo, string _chasisNo, ManagementSysForm _managementForm)
            {
                this.stockNo = _stockNo;
                this.mileage = _mileage;
                this.year = _year;
                this.color = _color;
                this.vendor = _vendor;
                this.model = _model;
                this.fuelType = _fuelType;
                this.bodyType = _bodyType;
                this.transmission = _tranmission;
                this.cylinders = _cylinders;
                this.engineNo = _enginNo;
                this.chasisNo = _chasisNo;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo);
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\CarsRecords");
                string basicInfoPath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\BasicInfomation.txt";
                string modelList = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\List.txt";
                string carRecords = Environment.CurrentDirectory + "\\Database\\CarsRecords\\Records.txt";
                string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclePrintDetails.txt";

                if (!File.Exists(basicInfoPath))
                {
                    if (stockNo == "" || mileage == "" || year == "" || color == "" || vendor == "" || model == "" || fuelType == "" || bodyType == "" || transmission == "" || cylinders == "" || engineNo == "" || chasisNo == "")
                    {
                        MetroMessageBox.Show(managementForm, "Please fill in all Fields", "Blank Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(basicInfoPath);
                        sw.WriteLine("---------- Vehicle Information ----------" + Environment.NewLine);
                        sw.WriteLine("Stock No:             " + stockNo);
                        sw.WriteLine("Mileage:              " + mileage);
                        sw.WriteLine("Year:                 " + year);
                        sw.WriteLine("Color:                " + color);
                        sw.WriteLine("Vendor:               " + vendor);
                        sw.WriteLine("Model:                " + model);
                        sw.WriteLine("Fuel Type:            " + fuelType);
                        sw.WriteLine("Body Type:            " + bodyType);
                        sw.WriteLine("Transmission:         " + transmission);
                        sw.WriteLine("Cylinders:            " + cylinders);
                        sw.WriteLine("Engine No:            " + engineNo);
                        sw.WriteLine("Chasis No:            " + chasisNo);
                        sw.WriteLine("-----------------------------------------" + Environment.NewLine);
                        sw.Close();

                        MetroMessageBox.Show(managementForm, "Vehicle Basic Information Saved Sucessfully", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                        if (!File.Exists(VehiclePrintDetails))
                        {
                            string alltxt = File.ReadAllText(basicInfoPath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(alltxt);
                            swDetails.Close();
                        }
                        else
                        {
                            string allDetails = File.ReadAllText(VehiclePrintDetails);
                            string allBasic = File.ReadAllText(basicInfoPath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(allDetails);
                            swDetails.Write(allBasic);
                            swDetails.Close();
                        }
                        if (!File.Exists(carRecords))
                        {
                            //For car Records Text File
                            StreamWriter swRecord = new StreamWriter(carRecords);
                            swRecord.WriteLine(" Stock No | Mileage | Year | Color | Vendor | Model | Fuel Type | Body Type | Transmission | Cylinders | Engine No | Chasis No");
                            swRecord.WriteLine(stockNo + " | " + mileage + " | " + year + " | " + color + " | " + vendor + " | " + model + " | " + fuelType + " | " + bodyType + " | " + transmission + " | " + cylinders + " | " + engineNo + " | " + chasisNo);
                            swRecord.Close();
                        }
                        else
                        {
                            //For car Records Text File
                            string allRecord = File.ReadAllText(carRecords);

                            StreamWriter swRecord = new StreamWriter(carRecords);
                            swRecord.Write(allRecord);
                            swRecord.WriteLine(stockNo + " | " + mileage + " | " + year + " | " + color + " | " + vendor + " | " + model + " | " + fuelType + " | " + bodyType + " | " + transmission + " | " + cylinders + " | " + engineNo + " | " + chasisNo);
                            swRecord.Close();
                        }
                        if (!File.Exists(modelList))
                        {
                            //For Car Model List Text File
                            StreamWriter swList = new StreamWriter(modelList);
                            swList.WriteLine(model);
                            swList.Close();
                        }
                        else
                        {
                            //For Car Model List Text File
                            string allList = File.ReadAllText(modelList);

                            StreamWriter swList = new StreamWriter(modelList);
                            swList.Write(allList);
                            swList.WriteLine(model);
                            swList.Close();
                        }
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "Sorry this Stock No. is already in used try another", "Stock in Used", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        public class vehicleFeatures : vehicleRegistration
        {
            public vehicleFeatures(string _stockNo, string _model, string _vendor, ManagementSysForm _managementForm, Panel currentPanel)
            {
                this.stockNo = _stockNo;
                this.model = _model;
                this.vendor = _vendor;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo);
                string vehicleFeaturesPath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclesFeatures.txt";
                string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclePrintDetails.txt";

                BunifuCustomLabel[] vehicleFeature_Label = currentPanel.Controls.OfType<BunifuCustomLabel>().ToArray();
                BunifuCheckbox[] vehicleFeature_Checkbox = currentPanel.Controls.OfType<BunifuCheckbox>().ToArray();

                if (vendor == "" || model == "" || stockNo == "")
                {
                    MetroMessageBox.Show(managementForm, "Please first fill Cars Basic Informations", "Blanks Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    StreamWriter sw = new StreamWriter(vehicleFeaturesPath);
                    sw.WriteLine("---------- Vehicle Features ----------" + Environment.NewLine);
                    for (int i = 0; i < vehicleFeature_Label.Count(); i++)
                    {
                        if (vehicleFeature_Checkbox[i].Checked == true)
                        {
                            sw.WriteLine(vehicleFeature_Label[i].Text);
                        }
                    }
                    sw.WriteLine("-----------------------------------------" + Environment.NewLine);
                    sw.Close();
                    MetroMessageBox.Show(managementForm, "Vehicles Features Saved Sucessfully", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                    if (!File.Exists(VehiclePrintDetails))
                    {
                        string alltxt = File.ReadAllText(vehicleFeaturesPath);
                        StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                        swDetails.Write(alltxt);
                        swDetails.Close();
                    }
                    else
                    {
                        string allDetails = File.ReadAllText(VehiclePrintDetails);
                        string allBasic = File.ReadAllText(vehicleFeaturesPath);
                        StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                        swDetails.Write(allDetails);
                        swDetails.Write(allBasic);
                        swDetails.Close();
                    }
                }
            }
        }

        public class vehiclePictures : vehicleRegistration
        {
            public vehiclePictures(string _stockNo, string _model, string _vendor,PictureBox picBox, ManagementSysForm _managementForm)
            {
                this.stockNo = _stockNo;
                this.vendor = _vendor;
                this.model = _model;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo);
                string FilePath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\CarImage.jpg";
                SaveFileDialog saveFile = new SaveFileDialog();

                if (!File.Exists(FilePath) && picBox.Image != null)
                {
                    picBox.Image.Save(FilePath, ImageFormat.Jpeg);
                    MetroMessageBox.Show(managementForm, "Car Image Uploaded Sucessfully", "Image Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                }
                else if (model == "" || vendor == "" || stockNo == "")
                {
                    MetroMessageBox.Show(managementForm, "First Fills Car's Basic Information", "Image Uploading Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else if (picBox.Image == null)
                {
                    MetroMessageBox.Show(managementForm, "Please Select an Image", "Image Uploading Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "You've already uploaded an Image", "Image Uploading Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        public class vehiclePurchase : vehicleRegistration
        {
            public vehiclePurchase(string _stockNo, string _vendor, string _model, string _purchaseDate, string _purchaseCountry, string _purchasedFrom, string _purchasedAmount, ManagementSysForm _managementForm)
            {
                this.stockNo = _stockNo;
                this.vendor = _vendor;
                this.model = _model;
                this.purchaseDate = _purchaseDate;
                this.purchaseCountry = _purchaseCountry;
                this.purchasedFrom = _purchasedFrom;
                this.purchasedAmount = _purchasedAmount;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo);
                string vehiclePurchasePath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclePurchase.txt";
                string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclePrintDetails.txt";
                string carAmountPath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\carAmount.txt";

                if (!File.Exists(vehiclePurchasePath))
                {
                    if (stockNo == "" || vendor == "" || model == "")
                    {
                        MetroMessageBox.Show(managementForm, "First fill Car Basic Information", "Blanks Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else if (purchaseDate == "" || purchaseCountry == "" || purchasedFrom == "" || purchasedAmount == "")
                    {
                        MetroMessageBox.Show(managementForm, "Please Filled in all Fields", "Blanks Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(vehiclePurchasePath);
                        sw.WriteLine("-------- Vehicle Purchae Details --------" + Environment.NewLine);
                        sw.WriteLine("Purchase Date:             " + purchaseDate);
                        sw.WriteLine("Purchased Amount:          " + purchasedAmount);
                        sw.WriteLine("Purchase Country:          " + purchaseCountry);
                        sw.WriteLine("Purchased From:            " + purchasedFrom);
                        sw.WriteLine("-----------------------------------------" + Environment.NewLine);
                        sw.Close();

                        StreamWriter swAmount = new StreamWriter(carAmountPath);
                        swAmount.WriteLine(purchasedAmount);
                        swAmount.Close();

                        MetroMessageBox.Show(managementForm, "Car Purchased Details Saved Sucessfully", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                        if (!File.Exists(VehiclePrintDetails))
                        {
                            string alltxt = File.ReadAllText(vehiclePurchasePath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(alltxt);
                            swDetails.Close();
                        }
                        else
                        {
                            string allDetails = File.ReadAllText(VehiclePrintDetails);
                            string allBasic = File.ReadAllText(vehiclePurchasePath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(allDetails);
                            swDetails.Write(allBasic);
                            swDetails.Close();
                        }
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "Sorry this Stock No. is already in used try another", "Stock in Used", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        public class vehicleTitlePlate : vehicleRegistration
        {
            public vehicleTitlePlate(string _stockNo, string _vendor, string _model, string _titleNumber, string _plateCity, string _plateState, string _titleHolder, string _contactNo, ManagementSysForm _managementForm)
            {
                this.stockNo = _stockNo;
                this.vendor = _vendor;
                this.model = _model;
                this.titleNumber = _titleNumber;
                this.plateCity = _plateCity;
                this.plateState = _plateState;
                this.titleHolder = _titleHolder;
                this.contactNo = _contactNo;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo);
                string VehicleTitlePlatePath = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehicleTitlePlate.txt";
                string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor + "\\" + model + "\\" + stockNo + "\\VehiclePrintDetails.txt";

                if (!File.Exists(VehicleTitlePlatePath))
                {
                    if (stockNo == "" || vendor == "" || model == "" || purchaseDate == "" || purchaseCountry == "" || purchasedFrom == "" || purchasedAmount == "")
                    {
                        MetroMessageBox.Show(managementForm, "First fill Car Basic Information and Purchased Details", "Blanks Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else if (titleNumber == "" || plateCity == "" || plateState == "" || titleHolder == "" || contactNo == "")
                    {
                        MetroMessageBox.Show(managementForm, "Please Filled in all Fields", "Blanks Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(VehicleTitlePlatePath);
                        sw.WriteLine("------ Vehicle Title Plate Details ------" + Environment.NewLine);
                        sw.WriteLine("Plate No:             " + titleNumber);
                        sw.WriteLine("Plate City:           " + plateCity);
                        sw.WriteLine("Plate State:          " + plateState);
                        sw.WriteLine("Plate Title Holder:   " + titleHolder);
                        sw.WriteLine("Holder Contact No:    " + contactNo);
                        sw.WriteLine("-----------------------------------------" + Environment.NewLine);
                        sw.Close();

                        MetroMessageBox.Show(managementForm, "Car Title Plates Details Saved Sucessfully", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                        if (!File.Exists(VehiclePrintDetails))
                        {
                            string alltxt = File.ReadAllText(VehicleTitlePlatePath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(alltxt);
                            swDetails.Close();
                        }
                        else
                        {
                            string allDetails = File.ReadAllText(VehiclePrintDetails);
                            string allBasic = File.ReadAllText(VehicleTitlePlatePath);
                            StreamWriter swDetails = new StreamWriter(VehiclePrintDetails);
                            swDetails.Write(allDetails);
                            swDetails.Write(allBasic);
                            swDetails.Close();
                        }
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "Sorry this Stock No. is already in used try another", "Stock in Used", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }


        private void saveVehicle_Button_Click(object sender, EventArgs e)
        {
            if (carsWheels_TabControl.SelectedTab == carsWheels_tabPage1)
            {
                vehicleBasicInformation basicInfo = new vehicleBasicInformation(stockNo_Textbox.Text,
                    mileage_Textbox.Text,
                    year_ComboBox.Text,
                    color_ComboBox.Text,
                    vendor_ComboBox.Text,
                    model_Textbox.Text,
                    fuelType_ComboBox.Text,
                    bodyType_ComboBox.Text,
                    transmission_ComboBox.Text,
                    cylinders_ComboBox.Text,
                    engineNo_Textbox.Text,
                    chasisNo_Textbox.Text, this);
            }
            else if (carsWheels_TabControl.SelectedTab == carsWheels_tabPage2)
            {
                vehicleFeatures vehicleFeature = new vehicleFeatures(stockNo_Textbox.Text, model_Textbox.Text, vendor_ComboBox.Text, this, vehicleFeatures_Panel);

            }
            else if (carsWheels_TabControl.SelectedTab == carsWheels_tabPage4)
            {
                vehiclePurchase purchaseInfo = new vehiclePurchase(stockNo_Textbox.Text,
                    vendor_ComboBox.Text, model_Textbox.Text, purchasedDate_Picker.Value.ToLongDateString(), purchaseCountry_Textbox.Text,
                    purchasedFrom_ComboBox.Text, purchaseAmount_Textbox.Text, this);

                if (titlePlateStatus_ComboBox.SelectedIndex == 0)
                {
                    vehicleTitlePlate TitlePlateInfo = new vehicleTitlePlate(stockNo_Textbox.Text,
                        vendor_ComboBox.Text, model_Textbox.Text, titlePlateNumber_Textbox.Text,
                        titlePlateCity_Textbox.Text, titlePlateState_Textbox.Text, titlePlateHolder_Textbox.Text,
                        titlePlateContact_Textbox.Text, this);
                }
            }  
        }

        private void vendorRegistrationSave_Button_Click(object sender, EventArgs e)
        {
            vendorRegistration VendorReg = new vendorRegistration(vendorRegistrationName_Textbox.Text, 
                vendorRegistrationContact_Textbox.Text, 
                vendorRegistrationEmail_Textbox.Text, 
                vendorRegistrationFax_Textbox.Text, 
                vendorRegistrationCountry_Textbox.Text, 
                vendorRegistrationCity_Textbox.Text, 
                vendorRegistrationPoBox_Textbox.Text, 
                vendorRegistrationPostal_Textbox.Text, 
                vendorRegistrationAdress_Textbox.Text, this);
        }

        private void vendorRegistrationClear_Button_Click(object sender, EventArgs e)
        {
            vendorRegistrationName_Textbox.Text = "";
            vendorRegistrationContact_Textbox.Text = "";
            vendorRegistrationEmail_Textbox.Text = "";
            vendorRegistrationFax_Textbox.Text = "";
            vendorRegistrationCountry_Textbox.Text = "";
            vendorRegistrationCity_Textbox.Text = "";
            vendorRegistrationPoBox_Textbox.Text = "";
            vendorRegistrationPostal_Textbox.Text = "";
            vendorRegistrationAdress_Textbox.Text = "";
        }

        private void selectImage_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                carImage_pictureBox.Image = Image.FromFile(openFile.FileName);
                carImage_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void saveImage_Button_Click(object sender, EventArgs e)
        {
            vehiclePictures vehicleImage = new vehiclePictures(stockNo_Textbox.Text,
                model_Textbox.Text, vendor_ComboBox.Text, carImage_pictureBox, this);
        }

        private void printDocumentCarsWheels_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor_ComboBox.Text + "\\" + model_Textbox.Text + "\\" + stockNo_Textbox.Text + "\\VehiclePrintDetails.txt";

            if (File.Exists(VehiclePrintDetails))
            {
                string alltxt = File.ReadAllText(VehiclePrintDetails);
                e.Graphics.DrawString(alltxt, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }

        }

        private void savePrintVehicle_Button_Click(object sender, EventArgs e)
        {
            string VehiclePrintDetails = Environment.CurrentDirectory + "\\Database\\Cars\\" + vendor_ComboBox.Text + "\\" + model_Textbox.Text + "\\" + stockNo_Textbox.Text + "\\VehiclePrintDetails.txt";

            if (File.Exists(VehiclePrintDetails))
            {
                if (printPreviewCarsWheels.ShowDialog() == DialogResult.OK)
                {
                    printDocumentCarsWheels.Print();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void carInventoryImport_Button_Click(object sender, EventArgs e)
        {
            string carRecordsPath = Environment.CurrentDirectory + "\\Database\\CarsRecords\\Records.txt";

            if (File.Exists(carRecordsPath))
            {
                DataTable carsInventory_dataTable = new DataTable();

                string[] raw_txt = File.ReadAllLines(carRecordsPath);
                string[] data_col = null;
                int x = 0;

                foreach (string txt in raw_txt)
                {
                    data_col = txt.Split('|');

                    if (x == 0)
                    {
                        for (int i = 0; i <= data_col.Count() - 1; i++)
                        {
                            carsInventory_dataTable.Columns.Add(data_col[i]);
                        }
                        x++;
                    }
                    else
                    {
                        carsInventory_dataTable.Rows.Add(data_col);
                    }
                }

                carsInventory_dataGridView.DataSource = carsInventory_dataTable;
                inventory_Panel.Controls.Add(carsInventory_dataGridView);
            }
            else
            {
                MetroMessageBox.Show(this, "Sorry! Nothing to display", "No Records in Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        #endregion

        #region Customer Class

        public class customerRegistration
        {
            private string customerID;
            private string customerDate;
            private string customerCNIC;
            private string customerName;
            private string customerContact;
            private string customerCarStockNo;
            private string customerAddress;
            private string customerCarVendor;
            private string customerCarModel;
            private string Taxes;
            private string totalPrice;
            private ManagementSysForm managementForm;

            public customerRegistration(string _customerID, string _customerDate, string _customerCNIC, string _customerName,
                string _customerContact, string _customerCarStockNo, string _customerAddress, string _customerCarVendor, 
                string _customerCarModel,string _Taxes, string _totalPrice, ManagementSysForm _managementForm)
            {
                this.customerID = _customerID;
                this.customerDate = _customerDate;
                this.customerCNIC = _customerCNIC;
                this.customerName = _customerName;
                this.customerContact = _customerContact;
                this.customerCarStockNo = _customerCarStockNo;
                this.customerAddress = _customerAddress;
                this.customerCarVendor = _customerCarVendor;
                this.customerCarModel = _customerCarModel;
                this.Taxes = _Taxes;
                this.totalPrice = _totalPrice;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Customers\\" + customerID);
                string customerRegisterPath = Environment.CurrentDirectory + "\\Database\\Customers\\" + customerID + "\\CustomerInfo.txt";
                string CustomerRecordPath = Environment.CurrentDirectory + "\\Database\\Customers\\CustomerRecord.txt";

                if (!File.Exists(customerRegisterPath))
                {
                    if (customerID == "" || customerDate == "" || customerCNIC == "" || customerName == "" || customerContact == "" || customerCarStockNo == "" ||
                        customerAddress == "" || customerCarVendor == "" || customerCarModel == "" || totalPrice == "")
                    {
                        MetroMessageBox.Show(managementForm, "Please fill in all Fields", "Blank Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(customerRegisterPath);
                        sw.WriteLine("---------- Customer Information ----------" + Environment.NewLine);
                        sw.WriteLine("Customer ID:               " + customerID);
                        sw.WriteLine("Registration Date:         " + customerDate);
                        sw.WriteLine("Customer CNIC:             " + customerCNIC);
                        sw.WriteLine("Customer Name:             " + customerName);
                        sw.WriteLine("Contact No:                " + customerContact);
                        sw.WriteLine("Address:                   " + customerAddress);
                        sw.WriteLine("Car Vendor:                " + customerCarVendor);
                        sw.WriteLine("Car Model:                 " + customerCarModel);
                        sw.WriteLine("Car Taxes:                 " + Taxes);
                        sw.WriteLine("Car Total Price:           " + totalPrice);
                        sw.WriteLine("-----------------------------------------" + Environment.NewLine);
                        sw.Close();

                        MetroMessageBox.Show(managementForm, "Customer Information Saved Sucessfully", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);


                        if (!File.Exists(CustomerRecordPath))
                        {
                            //For Customer Records Text File
                            StreamWriter swRecord = new StreamWriter(CustomerRecordPath);
                            swRecord.WriteLine(" Customer ID | Date | CNIC | Customer Name | Contact No | Address | Car Vendor | Car Model | Car Taxes | Car Total Price ");
                            swRecord.WriteLine(customerID + " | " + customerDate + " | " + customerCNIC + " | " + customerName + " | " + customerContact + " | " + customerAddress + " | " + customerCarVendor + " | " + customerCarModel + " | " + Taxes + " | " + totalPrice);
                            swRecord.Close();
                        }
                        else
                        {
                            //For Customer Records Text File
                            string allRecord = File.ReadAllText(CustomerRecordPath);

                            StreamWriter swRecord = new StreamWriter(CustomerRecordPath);
                            swRecord.Write(allRecord);
                            swRecord.WriteLine(customerID + " | " + customerDate + " | " + customerCNIC + " | " + customerName + " | " + customerContact + " | " + customerAddress + " | " + customerCarVendor + " | " + customerCarModel + " | " + Taxes + " | " + totalPrice);
                            swRecord.Close();
                        }
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "Customer ID Already in used try another", "Duplicate Details", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        private void customerSave_Button_Click(object sender, EventArgs e)
        {
            customerRegistration customerReg = new customerRegistration(customerID_Textbox.Text,
                CustomerDate_Picker.Value.ToLongDateString(), customerCNIC_TextBox.Text, customerName_Textbox.Text,
                customerContact_Textbox.Text, customerCarStockNo_Textbox.Text, customerAddress_Textbox.Text, customerCar_Combox.Text,
                customerCarModel_Combox.Text, customerTax_Textbox.Text, customerCarPrice_Textbox.Text, this);
        }

        private void Customer_printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string customerRegisterPath = Environment.CurrentDirectory + "\\Database\\Customers\\" + customerID_Textbox.Text + "\\CustomerInfo.txt";

            if (File.Exists(customerRegisterPath))
            {
                string alltxt = File.ReadAllText(customerRegisterPath);
                e.Graphics.DrawString(alltxt, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void customerPrint_Button_Click(object sender, EventArgs e)
        {
            string customerRegisterPath = Environment.CurrentDirectory + "\\Database\\Customers\\" + customerID_Textbox.Text + "\\CustomerInfo.txt";

            if (File.Exists(customerRegisterPath))
            {
                if (Customer_printPreviewDialog.ShowDialog() == DialogResult.OK)
                {
                    Customer_printDocument.Print();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void customerRecordImport_Button_Click(object sender, EventArgs e)
        {
            string CustomerRecordPath = Environment.CurrentDirectory + "\\Database\\Customers\\CustomerRecord.txt";

            if (File.Exists(CustomerRecordPath))
            {
                DataTable customerRecord_dataTable = new DataTable();

                string[] raw_txt = File.ReadAllLines(CustomerRecordPath);
                string[] data_col = null;
                int x = 0;

                foreach (string txt in raw_txt)
                {
                    data_col = txt.Split('|');

                    if (x == 0)
                    {
                        for (int i = 0; i <= data_col.Count() - 1; i++)
                        {
                            customerRecord_dataTable.Columns.Add(data_col[i]);
                        }
                        x++;
                    }
                    else
                    {
                        customerRecord_dataTable.Rows.Add(data_col);
                    }
                }

                customerRecord_DataGrid.DataSource = customerRecord_dataTable;
                customerRecordGrid_Panel.Controls.Add(customerRecord_DataGrid);
            }
            else
            {
                MetroMessageBox.Show(this, "Sorry! Nothing to display", "No Records in Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        #endregion

        #region Vendor Class

        public class vendorRegistration
        {
            private string vendorName { get; set; }
            private string vendorContactNo { get; set; }
            private string vendorEmail { get; set; }
            private string vendorFax { get; set; }
            private string vendorCountry { get; set; }
            private string vendorCity { get; set; }
            private string vendorPoBox { get; set; }
            private string vendorPostal { get; set; }
            private string vendorAddress { get; set; }
            private ManagementSysForm managementForm;

            public vendorRegistration(string _vendorName, string _vendorContactNo, string _vendorEmail, string _vendorFax, string _vendorCountry, string _vendorCity, string _vendorPoBox, string _vendorPostal, string _vendorAddress, ManagementSysForm _managementForm)
            {
                this.vendorName = _vendorName;
                this.vendorContactNo = _vendorContactNo;
                this.vendorEmail = _vendorEmail;
                this.vendorFax = _vendorFax;
                this.vendorCountry = _vendorCountry;
                this.vendorCity = _vendorCity;
                this.vendorPoBox = _vendorPoBox;
                this.vendorPostal = _vendorPostal;
                this.vendorAddress = _vendorAddress;
                this.managementForm = _managementForm;

                Directory.CreateDirectory(Application.StartupPath + "\\Database\\VendorsRecords\\");
                string vendorsRecordsPath = Application.StartupPath + "\\Database\\VendorsRecords\\Records.txt";
                string vendorsListPath = Application.StartupPath + "\\Database\\VendorsRecords\\List.txt";

                Directory.CreateDirectory(Application.StartupPath + "\\Database\\Vendors\\" + vendorName);
                string vendorDetailsPath = Application.StartupPath + "\\Database\\Vendors\\" + vendorName + "\\VendorDetails.txt";

                if (vendorName != "" && vendorContactNo != "" && vendorEmail != "" && vendorFax != "" && vendorCountry != "" && vendorCity != "" && vendorPoBox != "" && vendorPostal != "" && vendorAddress != "")
                {
                    if (!File.Exists(vendorDetailsPath))
                    {
                        StreamWriter swDetails = new StreamWriter(vendorDetailsPath);
                        swDetails.WriteLine("------------ Vendor Details -------------" + Environment.NewLine);
                        swDetails.WriteLine("Vendor Name:               " + vendorName);
                        swDetails.WriteLine("Contact No:                " + vendorContactNo);
                        swDetails.WriteLine("Email:                     " + vendorEmail);
                        swDetails.WriteLine("Fax No:                    " + vendorFax);
                        swDetails.WriteLine("Country:                   " + vendorCountry);
                        swDetails.WriteLine("City:                      " + vendorCity);
                        swDetails.WriteLine("PO Box:                    " + vendorPoBox);
                        swDetails.WriteLine("Postal Code:               " + vendorPostal);
                        swDetails.WriteLine("Address:                   " + vendorAddress);
                        swDetails.WriteLine("-----------------------------------------" + Environment.NewLine);
                        swDetails.Close();

                        MetroMessageBox.Show(managementForm, "Sucessfully Vendor Details Save", "Details Saved", MessageBoxButtons.OK, MessageBoxIcon.Question, 125);

                        if (!File.Exists(vendorsRecordsPath))
                        {
                            StreamWriter swRecords = new StreamWriter(vendorsRecordsPath);
                            swRecords.WriteLine("Name| Contact No| Email| Fax No| Country| City| PO Box| Postal Code| Address");
                            swRecords.WriteLine(vendorName + "| " + vendorContactNo + "| " + vendorEmail + "| " + vendorFax + "| " + vendorCountry + "| " + vendorCity + "| " + vendorPoBox + "| " + vendorPostal + "| " + vendorAddress);
                            swRecords.Close();

                            StreamWriter swList = new StreamWriter(vendorsListPath);
                            swList.WriteLine(vendorName);
                            swList.Close();
                        }
                        else
                        {
                            string allSaveText;
                            string allSaveList;

                            allSaveText = File.ReadAllText(vendorsRecordsPath);

                            StreamWriter swRecords = new StreamWriter(vendorsRecordsPath);
                            swRecords.Write(allSaveText);
                            swRecords.WriteLine(vendorName + "| " + vendorContactNo + "| " + vendorEmail + "| " + vendorFax + "| " + vendorCountry + "| " + vendorCity + "| " + vendorPoBox + "| " + vendorPostal + "| " + vendorAddress);
                            swRecords.Close();

                            StreamReader srList = new StreamReader(vendorsListPath);
                            allSaveList = srList.ReadToEnd();
                            srList.Close();

                            StreamWriter swList = new StreamWriter(vendorsListPath);

                            swList.Write(allSaveList);
                            swList.WriteLine(vendorName);
                            swList.Close();
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(managementForm, "This Vendor is Already Register", "Error in Saving Vendor Details", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(managementForm, "Please Fills all Required Fields", "Blank Fields Left", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        private void vendorRecordImport_Button_Click(object sender, EventArgs e)
        {
            string VendorsRecordsPath = Application.StartupPath + "\\Database\\VendorsRecords\\Records.txt";

            if (File.Exists(VendorsRecordsPath))
            {
                DataTable vendorsRecord_dataTable = new DataTable();

                string[] raw_txt = File.ReadAllLines(VendorsRecordsPath);
                string[] data_col = null;
                int x = 0;

                foreach (string txt in raw_txt)
                {
                    data_col = txt.Split('|');

                    if (x == 0)
                    {
                        for (int i = 0; i <= data_col.Count() - 1; i++)
                        {
                            vendorsRecord_dataTable.Columns.Add(data_col[i]);
                        }
                        x++;
                    }
                    else
                    {
                        vendorsRecord_dataTable.Rows.Add(data_col);
                    }
                }

                vendorRecord_DataGridView.DataSource = vendorsRecord_dataTable;
                vendorRecordGrid_Panel.Controls.Add(vendorRecord_DataGridView);
            }
            else
            {
                MetroMessageBox.Show(this, "Sorry! Nothing to display", "No Records in Database", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void Vendor_printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string vendorDetailsPath = Environment.CurrentDirectory + "\\Database\\Vendors\\" + vendorRegistrationName_Textbox.Text + "\\VendorDetails.txt";

            if (File.Exists(vendorDetailsPath))
            {
                string alltxt = File.ReadAllText(vendorDetailsPath);
                e.Graphics.DrawString(alltxt, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        private void vendorRegistrationPrint_Button_Click(object sender, EventArgs e)
        {
            string vendorDetailsPath = Environment.CurrentDirectory + "\\Database\\Vendors\\" + vendorRegistrationName_Textbox.Text + "\\VendorDetails.txt";

            if (File.Exists(vendorDetailsPath))
            {
                if (vendor_printPreviewDialog.ShowDialog() == DialogResult.OK)
                {
                    Vendor_printDocument.Print();
                }
            }
            else
            {
                MetroMessageBox.Show(this, "First Save all Detail then Print", "Error noting To Print", MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
        }

        #endregion

        //Total Price
        public void totalPrice(object sender, EventArgs e)
        {
            string basicInfoPath = Environment.CurrentDirectory + "\\Database\\Cars\\" + customerCar_Combox.Text + "\\" + customerCarModel_Combox.Text + "\\" + customerCarStockNo_Textbox.Text + "\\carAmount.txt";
            
            if (File.Exists(basicInfoPath))
            {
                StreamReader sr = new StreamReader(basicInfoPath);

                string carAmount = sr.ReadLine();
                sr.Close();

                if (customerTax_Textbox.Text == "")
                {
                    customerCarPrice_Textbox.Text = Convert.ToDouble(carAmount).ToString();
                }
                else
                {
               customerCarPrice_Textbox.Text =  (Convert.ToDouble(customerTax_Textbox.Text) + Convert.ToDouble(carAmount)).ToString();
                }
            }
            else
            {
                customerCarPrice_Textbox.Text = "Invalid Car Details";
            }
        }

        //---Start Form Boarder Buttons Functions---\\

        int mouseX = 0;
        int mouseY = 0;
        int ToMove;

        private void allowDrageDown(object sender, MouseEventArgs e)
        {
            ToMove = 1;
            mouseX = e.X + 250;
            mouseY = e.Y;
        }

        private void allowDrageMove(object sender, MouseEventArgs e)
        {
            if (ToMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);
            }
        }

        private void allowDrageUp(object sender, MouseEventArgs e)
        {
            ToMove = 0;
        }

        private void CloseManagementForm(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeManagementForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaximizedManagementForm(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                Maximize_PicBox.BackgroundImage = Properties.Resources.Maximizeds_Icon;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                Maximize_PicBox.BackgroundImage = Properties.Resources.Restored_Icon;
            }
        }

        private void CloseMouseHover(object sender, EventArgs e)
        {
            Close_PicBox.BackgroundImage = Properties.Resources.Close_96px_Hover_;
        }

        private void CloseMouseLeave(object sender, EventArgs e)
        {
            Close_PicBox.BackgroundImage = Properties.Resources.Close_96px;
        }

        private void MinimizeMouseHover(object sender, EventArgs e)
        {
            Minimize_PicBox.BackgroundImage = Properties.Resources.Minimized_Icon_Hover_;
        }

        private void MinimizeMouseLeave(object sender, EventArgs e)
        {
            Minimize_PicBox.BackgroundImage = Properties.Resources.Minimized_Icon;
        }

        private void MaximizeMouseHover(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Maximize_PicBox.BackgroundImage = Properties.Resources.Maximizeds_Icon_Hover_;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                Maximize_PicBox.BackgroundImage = Properties.Resources.Restored_Icon_Hover_;
            }
        }

        private void MaximizeMouseleave(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Maximize_PicBox.BackgroundImage = Properties.Resources.Restored_Icon;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Maximize_PicBox.BackgroundImage = Properties.Resources.Maximizeds_Icon;
            }
        }
        //---End Form Boarder Buttons Functions---\\



        //---Start Side Menu Buttons Functions---\\


        public void panelDisplay(string panelName)
        {
            Panel[] display = new Panel[] { home_Panel, carsWheel_Panel, carsInventory_Panel, customersRegistration_Panel, customerRecord_Panel, vendorsRegistration_Panel, vendorsRecord_Panel, Statistics_Panel };

            for (int i = 0; i < 7; i++)
            {
                display[i].Visible = display[i].Name == panelName;
            }
        }

        private void Home_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("home_Panel");
        }

        private void CarsAndWheels_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("carsWheel_Panel");
        }

        private void CarsInventory_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("carsInventory_Panel");
        }

        private void CustomerRegistration_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("customersRegistration_Panel");
        }

        private void CustomerRecords_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("customerRecord_Panel");
        }

        private void VendorRegistration_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("vendorsRegistration_Panel");
        }

        private void VendorRecord_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("vendorsRecord_Panel");
        }

        private void Statistics_BTN_Click(object sender, EventArgs e)
        {
            panelDisplay("Statistics_Panel");
        }
        

        //---End Side Menu Buttons Function--\\



        //---Start  Methods/ Events---\\

        public void keyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void yearGenerator()      //Add last 10 Years according to Current Year Automatically
        {
            for (int i = 9; i >= 0; i--)
            {
                year_ComboBox.Items.Add(Convert.ToInt32(DateTime.Now.Year.ToString()) - i);
            }
        }

        public void cylindersNumbers()
        {
            for (int i = 1; i <= 60; i++)
            {
                cylinders_ComboBox.Items.Add(i);
            }
        }

        private void titlePlateStatus_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (titlePlateStatus_ComboBox.SelectedIndex == 0)
            {
                titlePlateNumber_Textbox.Enabled = true;
                titlePlateCity_Textbox.Enabled = true;
                titlePlateState_Textbox.Enabled = true;
                titlePlateHolder_Textbox.Enabled = true;
                titlePlateContact_Textbox.Enabled = true;
            }
        }

        private void ManagementSysForm_Load(object sender, EventArgs e)
        {
        }


        public void displayVendorsComobox()
        {
            string path = Application.StartupPath + "\\Database\\VendorsRecords\\List.txt";

            if (!File.Exists(path))
            {
                vendor_ComboBox.Text = "No Vendor Record";
                purchasedFrom_ComboBox.Text = "No Vendor Record";
                customerCar_Combox.Text = "No Vendor Record";
            }
            else
            {
                string[] allText = File.ReadAllLines(path);

                foreach (var lines in allText)
                {
                   vendor_ComboBox.Items.Add(lines);
                   purchasedFrom_ComboBox.Items.Add(lines);
                   customerCar_Combox.Items.Add(lines);
                }

            }
        }

        private void logOut_Button_Click(object sender, EventArgs e)
        {
            multiForms multiForm = new multiForms();
            this.Hide();
            multiForm.Closed += (s, args) => this.Close();
            multiForm.Show();
        }

        private void RefreshApplication(object sender, EventArgs e)
        {
            ManagementSysForm msf = new ManagementSysForm();
            this.Hide();
            msf.Closed += (s, args) => this.Close();
            msf.Show();
        }

        private void customerIDGenerator_Buttom_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            customerID_Textbox.Text = "CTM-" + randomNumber.ToString() + "-" + (randomNumber * 7).ToString();
        }

        //Customer ModelCombobox Event
        public void displayModelCombobox(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Database\\Cars\\" + customerCar_Combox.Text + "\\List.txt";

        a: if (customerCarModel_Combox.Items.Count > 0)
            {
                customerCarModel_Combox.Items.RemoveAt(0);
                goto a;
            }

            if (!File.Exists(path))
            {
                customerCarModel_Combox.Text = "No Model Record";
            }
            else
            {
                string[] allText = File.ReadAllLines(path);

                foreach (var lines in allText)
                {
                    customerCarModel_Combox.Items.Add(lines);
                }
            }
        }

        //---End  Methods/ Events---\\
    }
}
