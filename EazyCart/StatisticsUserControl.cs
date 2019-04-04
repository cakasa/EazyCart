using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using System.Windows.Media;
using Business;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
using Data.Models;

namespace EazyCart
{
    /// <summary>
    /// This user control is responsible for displaying various reports based on user preference.
    /// </summary>
    public partial class StatisticsUserContol : UserControl
    {
        private ProductBusiness productBusiness;
        private ReceiptBusiness receiptBusiness;

        private Brush reportBarColoredBrush;
        private Brush reportGraphLabelBrush;
        private Brush reportValueLabelBrush;
        private FontFamily reportFontFamily;
        private readonly System.Drawing.Color enabledButtonColor = System.Drawing.Color.FromArgb(44, 62, 80);
        private readonly System.Drawing.Color disabledButtonColor = System.Drawing.Color.FromArgb(127, 140, 141);

        private string[] hourLabels;
        private string[] dayLabels;
        private string[] monthLabels;

        private List<string> salesReports;
        private List<string> inventoryReports;
        private List<string> orderReports;

        public StatisticsUserContol()
        {
            InitializeComponent();
        }

        private void StatisticsUserContol_Load(object sender, EventArgs e)
        {
            this.UpdateUserControl();
        }

        // The following methods are responsible for updating information when it is changed.
        /// <summary>
        /// Updates the user control every time it is loaded.
        /// </summary>
        private void UpdateUserControl()
        {
            var eazyCartContext = new EazyCartContext();
            this.productBusiness = new ProductBusiness(eazyCartContext);
            this.receiptBusiness = new ReceiptBusiness(eazyCartContext);

            Color reportBarColor = Color.FromRgb(44, 62, 80);           
            this.reportBarColoredBrush = new SolidColorBrush(reportBarColor);
            this.reportGraphLabelBrush = Brushes.Black;
            this.reportValueLabelBrush = Brushes.GhostWhite;
            this.reportFontFamily = new FontFamily("Segoe UI");

            this.InitializeDefaultLabels();
            this.InitializeReportTypes();

            this.fileNameTextBox.Text = "EazyCartChart";
            this.reportCategoryComboBox.SelectedIndex = 0;
            this.exportReportButton.Enabled = false;
            this.exportReportButton.BackColor = disabledButtonColor;
            this.reportChart.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Initializes the default values for the generic labels.
        /// </summary>
        private void InitializeDefaultLabels()
        {
            this.hourLabels = new string[]
            {
                "0:00 - 2:59",
                "3:00 - 5:59",
                "6:00 - 8:59",
                "9:00 - 11:59",
                "12:00 - 14:59",
                "15:00 - 17:59",
                "18:00 - 20:59",
                "21:00 - 23:59"
            };

            this.monthLabels = new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };

            // Get how many days there are in a month and initialize labels.
            DateTime currentDateTime = new DateTime();
            int monthDays = DateTime.DaysInMonth(currentDateTime.Year, currentDateTime.Month);
            this.dayLabels = new string[monthDays];
            for (int day = 1; day < monthDays; day++)
            {
                this.dayLabels[day - 1] = day.ToString();
            }
        }

        /// <summary>
        /// Initializes all report types and assigns them to their corresponding category
        /// </summary>
        private void InitializeReportTypes()
        {
            this.salesReports = new List<string>()
            {
                "Sales Report"
            };

            this.inventoryReports = new List<string>()
            {
                "Product Quantity in Inventory",
                "Number of Products Sorted by Supplier",
                "Number of Products Sorted by Category",
                "Number of Products Sorted by Country",
                "Products by Profit for a Single Unit"
            };

            this.orderReports = new List<string>()
            {
                "Number of Orders for a Period",
                "Average Number of Different Products in an Order for a Period",
                "Number of Orders Featuring Discount for a Period"
            };
        }

        /// <summary>
        /// The event is triggered when the item in the report Category comboBox has been changed.
        /// Inserts the report types of that category into the Type of report comboBox. Also manages
        /// whether the period comboBox is enabled.
        /// </summary>
        /// <example>
        /// The inventory category has 5 types of reports. When it is selected, a method will populate
        /// the type of report comboBox with these 5 reports.
        /// See the <see cref="FillReportTypeComboBox(int)"> method.
        /// </example>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.reportCategoryComboBox.SelectedIndex != 0)
            {
                this.reportTypeComboBox.Enabled = true;
                int categoryIndex = this.reportCategoryComboBox.SelectedIndex;
                this.FillReportTypeComboBox(categoryIndex);
            }
            else
            {
                this.reportTypeComboBox.SelectedIndex = 0;
                this.reportPeriodComboBox.SelectedIndex = 0;
                this.reportTypeComboBox.Enabled = false;
            }
            ModifyPeriodComboBox();
        }

        /// <summary>
        /// This event triggers when the type of report comboBox
        /// index has been changed.
        /// </summary>
        private void ReportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifyPeriodComboBox();
        }

        /// <summary>
        /// This method is responsible for filling the types of reports
        /// which suit a given category.
        /// </summary>
        /// <param name="categoryIndex"></param>
        private void FillReportTypeComboBox(int categoryIndex)
        {
            var dataSource = new List<string>();
            dataSource.Add("Select Type of Report");

            // The category index corresponds to the category of the report.
            switch (categoryIndex)
            {
                case 1:
                    {
                        dataSource.AddRange(this.salesReports);
                        break;
                    }
                case 2:
                    {
                        dataSource.AddRange(this.inventoryReports);
                        break;
                    }
                case 3:
                    {
                        dataSource.AddRange(this.orderReports);
                        break;
                    }
            }

            this.reportTypeComboBox.DataSource = dataSource;
        }

        /// <summary>
        /// Manages whether the period comboBox is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyPeriodComboBox()
        {
            // THe period comboBox is only enabled when the selected category is
            // 'Sales Reports' or 'Order Reports'
            int selectedCategoryIndex = this.reportCategoryComboBox.SelectedIndex;
            int selectedTypeIndex = this.reportTypeComboBox.SelectedIndex;
            if (selectedTypeIndex == 0)
            {
                this.reportPeriodComboBox.Enabled = false;
            }
            else if (selectedCategoryIndex  == 1 || selectedCategoryIndex == 3)
            {
                this.reportPeriodComboBox.Enabled = true;
            }
            else
            {
                this.reportPeriodComboBox.Enabled = false;
            }
            this.reportPeriodComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// This event is triggered when the 'Generate Report' button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            // Renew the information.
            var eazyCartContext = new EazyCartContext();
            this.productBusiness = new ProductBusiness(eazyCartContext);
            this.receiptBusiness = new ReceiptBusiness(eazyCartContext);

            int categoryIndex = this.reportCategoryComboBox.SelectedIndex;
            int typeIndex = this.reportTypeComboBox.SelectedIndex;
            int periodIndex = this.reportPeriodComboBox.SelectedIndex;

            // Validate whether appropriate values have been selected, then
            // proceed to generate the report.
            if (categoryIndex == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select a report category");
                return;
            }
            else if (typeIndex == 0)
            {
                System.Windows.Forms.MessageBox.Show("Please select a report type");
                return;
            }
            else if ((categoryIndex == 1 || categoryIndex == 3) && (periodIndex == 0))
            {
                System.Windows.Forms.MessageBox.Show("Please select a period");
                return;
            }
            else this.GetReportNumber(categoryIndex, typeIndex, periodIndex);
        }

        /// <summary>
        /// Gets the index, which the report corresponds to. Used by another method
        /// to get the appropriate type of report. 
        /// See <see cref="ChooseReportToGenerate(int, int)"/> method.
        /// /// </summary>
        /// <example>
        /// 'Sales report' has an index of 1 and that is the index this method will get.
        /// </example>
        /// <param name="categoryIndex">Index of the category of the report</param>
        /// <param name="typeIndex">Index of the type of report</param>
        /// <param name="periodIndex">Index of the period of the report</param>
        private void GetReportNumber(int categoryIndex, int typeIndex, int periodIndex)
        {
            int reportNumber = 0;
            if (categoryIndex == 1)
            {
                reportNumber = typeIndex;
            }
            else if (categoryIndex == 2)
            {
                reportNumber = typeIndex + salesReports.Count();
            }
            else
            {
                reportNumber = typeIndex + salesReports.Count() + inventoryReports.Count();
            }

            this.ChooseReportToGenerate(reportNumber, periodIndex);
        }

        /// <summary>
        /// This method calls a method, responsible for generating that specific
        /// type of report.
        /// </summary>
        /// <param name="reportNumber"></param>
        /// <param name="periodIndex"></param>
        private void ChooseReportToGenerate(int reportNumber, int periodIndex)
        {
            // Choose the report to generate
            switch (reportNumber)
            {
                case 1:
                    {
                        this.GenerateSalesReport(periodIndex);
                        break;
                    }
                case 2:
                    {
                        this.GenerateProductsQuantityInInventoryReport();
                        break;
                    }
                case 3:
                    {
                        this.GenerateProductsBySupplierReport();
                        break;
                    }
                case 4:
                    {
                        this.GenerateProductsByCategoryReport();
                        break;
                    }
                case 5:
                    {
                        this.GenerateProductsByCountryReport();
                        break;
                    }
                case 6:
                    {
                        this.GenerateProductsByNetProfitForSingleUnit();
                        break;
                    }
                case 7:
                    {
                        this.GenerateOrdersNumber(periodIndex);
                        break;
                    }
                case 8:
                    {
                        this.GenerateAverageNumberOfDifferentProducts(periodIndex);
                        break;
                    }
                case 9:
                    {
                        this.GenerateOrdersFeaturingDiscounts(periodIndex);
                        break;
                    }
            }
            
            // If everything is successful, the extract button will get enabled and
            // the report will become visible.
            this.exportReportButton.Enabled = true;
            this.exportReportButton.BackColor = enabledButtonColor;
            this.reportChart.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Generate the 'Orders Featuring Discount' reports, based on the 
        /// given period.
        /// </summary>
        /// <example
        /// <param name="periodIndex">Index of the period the report should be generated for</param>
        private void GenerateOrdersFeaturingDiscounts(int periodIndex)
        {
            DateTime currentDateTime = default(DateTime);
            bool isMoneyReport = false;
            if (periodIndex == 1)
            {               
                decimal[] ordersFeaturingDiscountByHour = this.receiptBusiness
                                                                .GetDailyDiscountOrders(currentDateTime)
                                                                .Select(x => (decimal)x)
                                                                .ToArray();
                string[] labels = this.hourLabels;
                this.GenerateReport(ordersFeaturingDiscountByHour, labels, "Hour", "Number of orders featuring discount", 0, isMoneyReport);
            }
            else if (periodIndex == 2)
            {
                decimal[] ordersFeaturingDiscountByDay = this.receiptBusiness
                                                                .GetMonthlyDiscountOrders(currentDateTime)
                                                                .Select(x => (decimal)x)
                                                                .ToArray();
                string[] labels = this.dayLabels;
                this.GenerateReport(ordersFeaturingDiscountByDay, labels, "Day", "Number of orders featuring discount", 0, isMoneyReport);
            }
            else if (periodIndex == 3)
            {
                decimal[] ordersFeaturingDiscountByMonth = this.receiptBusiness
                                                                  .GetYearlyDiscountOrders(currentDateTime)
                                                                  .Select(x => (decimal)x)
                                                                  .ToArray();
                string[] labels = this.monthLabels;
                this.GenerateReport(ordersFeaturingDiscountByMonth, labels, "Month", "Number of orders featuring discount", 0, isMoneyReport);
            }
        }

        /// <summary>
        /// Generate the 'Average Number of different products' reports, 
        /// based on the given period.
        /// </summary>
        /// <example
        /// <param name="periodIndex">Index of the period the report should be generated for</param>
        private void GenerateAverageNumberOfDifferentProducts(int periodIndex)
        {
            DateTime currentDateTime = DateTime.Now;
            bool isMoneyReport = false;
            if (periodIndex == 1)
            {
                decimal[] averageNumberOfDifferentProductsByHour = 
                    this.receiptBusiness.GetDailyAverageAmountOfDifferentProducts(currentDateTime);

                string[] labels = this.hourLabels;
                this.GenerateReport(averageNumberOfDifferentProductsByHour, labels, "Hour", "Average number of different products", 0, isMoneyReport);
            }
            else if (periodIndex == 2)
            {
                decimal[] averageNumberOfDifferentProductsByDay = 
                    this.receiptBusiness.GetMonthlyAverageAmountOfDifferentProducts(currentDateTime);

                string[] labels = this.dayLabels;
                this.GenerateReport(averageNumberOfDifferentProductsByDay, labels, "Day", "Average number of different products", 0, isMoneyReport);
            }
            else if (periodIndex == 3)
            {
                decimal[] averageNumberOfDifferentProductsByMonth = 
                    this.receiptBusiness.GetYearlyAverageAmountOfDifferentProducts(currentDateTime);
                string[] labels = this.monthLabels;
                this.GenerateReport(averageNumberOfDifferentProductsByMonth, labels, "Month", "Average number of different products", 0, isMoneyReport);
            }
        }

        /// <summary>
        /// Generate the 'Number of Orders' reports, based on the given period.
        /// </summary>
        /// <example
        /// <param name="periodIndex">Index of the period the report should be generated for</param>
        private void GenerateOrdersNumber(int periodIndex)
        {
            DateTime currentDateTime = DateTime.Now;
            bool isMoneyReport = false;
            if (periodIndex == 1)
            {
                decimal[] totalOrdersByHour = this.receiptBusiness
                                                    .GetDailyOrders(currentDateTime)
                                                    .Select(x=> (decimal)x)
                                                    .ToArray();
                string[] labels = this.hourLabels;
                this.GenerateReport(totalOrdersByHour, labels, "Hour", "Number of orders", 0, isMoneyReport);
            }
            else if (periodIndex == 2)
            {
                decimal[] totalOrdersByDay = this.receiptBusiness
                                                    .GetMonthlyOrders(currentDateTime)
                                                    .Select(x => (decimal)x)
                                                    .ToArray();
                string[] labels = this.dayLabels;
                this.GenerateReport(totalOrdersByDay, labels, "Day", "Number of orders", 0, isMoneyReport);
            }
            else if (periodIndex == 3)
            {
                decimal[] totalOrdersByMonth = this.receiptBusiness
                                                    .GetYearlyOrders(currentDateTime)
                                                    .Select(x => (decimal)x)
                                                    .ToArray();
                string[] labels = this.monthLabels;
                this.GenerateReport(totalOrdersByMonth, labels, "Month", "Number of orders", 0, isMoneyReport);
            }
        }

        /// <summary>
        /// Generate the 'Products By Net Profit for Single Unit' report.
        /// </summary>
        private void GenerateProductsByNetProfitForSingleUnit()
        {
            var netProfitByProduct = this.productBusiness.GetNetProfitByProduct();
            bool isMoneyReport = true;

            // Get the labels and the values for the items in the report
            string[] labels = new string[netProfitByProduct.Count()];
            decimal[] netProfit = new decimal[netProfitByProduct.Count()];
            int index = 0;
            foreach (var netProfitProductPair in netProfitByProduct)
            {
                labels[index] = netProfitProductPair.Key;
                netProfit[index] = netProfitProductPair.Value;
                index++;
            }

            // If there are more labels, that can fit on the screen, rotate 
            // the labels so that they fit in the space, provided.
            int labelRotation = 0;
            if (netProfitByProduct.Count > 30)
            {
                labelRotation = 45;
            }

            this.GenerateReport(netProfit, labels, "Product", "Net Profit", labelRotation, isMoneyReport);
        }

        /// <summary>
        /// Generate the 'Products By Country Report'.
        /// </summary>
        private void GenerateProductsByCountryReport()
        {
            var productCountByCountry = this.productBusiness.GetCountOfProductsByCountry();
            bool isMoneyReport = false;

            // Get the labels and the values for the items in the report
            string[] labels = new string[productCountByCountry.Count()];
            decimal[] productCount = new decimal[productCountByCountry.Count()];
            int index = 0;
            foreach (var productQuantityPair in productCountByCountry)
            {
                labels[index] = productQuantityPair.Key;
                productCount[index] = productQuantityPair.Value;
                index++;
            }

            // If there are more labels, that can fit on the screen, rotate 
            // the labels so that they fit in the space, provided.
            int labelRotation = 0;
            if (productCountByCountry.Count > 30)
            {
                labelRotation = 45;
            }

            this.GenerateReport(productCount, labels, "Country", "Number of products", labelRotation, isMoneyReport);
        }

        /// <summary>
        /// Generate the 'Products By Category Report'.
        /// </summary>
        private void GenerateProductsByCategoryReport()
        {
            var productCountByCategory = this.productBusiness.GetCountOfProductsByCategory();
            bool isMoneyReport = false;

            // Get the labels and the values for the items in the report
            string[] labels = new string[productCountByCategory.Count()];
            decimal[] productCount = new decimal[productCountByCategory.Count()];
            int index = 0;
            foreach (var productQuantityPair in productCountByCategory)
            {
                labels[index] = productQuantityPair.Key;
                productCount[index] = productQuantityPair.Value;
                index++;
            }

            // If there are more labels, that can fit on the screen, rotate 
            // the labels so that they fit in the space, provided.
            int labelRotation = 0;
            if (productCountByCategory.Count > 30)
            {
                labelRotation = 45;
            }

            this.GenerateReport(productCount, labels, "Category", "Number of products", labelRotation, isMoneyReport);
        }

        /// <summary>
        /// Generate the 'Products By Supplier' Report.
        /// </summary>
        private void GenerateProductsBySupplierReport()
        {
            var productCountBySupplier = this.productBusiness.GetCountOfProductsBySuppliers();
            bool isMoneyReport = false;

            // Get the labels and the values for the items in the report
            string[] labels = new string[productCountBySupplier.Count()];
            decimal[] productCount = new decimal[productCountBySupplier.Count()];
            int index = 0;
            foreach (var supplierCountPair in productCountBySupplier)
            {
                labels[index] = supplierCountPair.Key;
                productCount[index] = supplierCountPair.Value;
                index++;
            }

            // If there are more labels, that can fit on the screen, rotate 
            // the labels so that they fit in the space, provided.
            int labelRotation = 0;
            if (productCountBySupplier.Count > 30)
            {
                labelRotation = 45;
            }

            this.GenerateReport(productCount, labels, "Supplier", "Number of products", labelRotation, isMoneyReport);
        }

        /// <summary>
        /// Generate the 'Generate Product Quantity in Inventory' Report.
        /// </summary>
        private void GenerateProductsQuantityInInventoryReport()
        {
            var allProductQuantities = this.productBusiness.GetAllQuantities();
            bool isMoneyReport = false;

            // Get the labels and the values for the items in the report
            string[] labels = new string[allProductQuantities.Count()];
            decimal[] quantities = new decimal[allProductQuantities.Count()];
            int index = 0;
            foreach (var productQuantityPair in allProductQuantities)
            {
                labels[index] = productQuantityPair.Key;
                quantities[index] = productQuantityPair.Value;
                index++;
            }

            // If there are more labels, that can fit on the screen, rotate 
            // the labels so that they fit in the space, provided.
            int labelRotation = 0;
            if (allProductQuantities.Count > 30)
            {
                labelRotation = 45;
            }

            this.GenerateReport(quantities, labels, "Product", "Quantity", labelRotation, isMoneyReport);
        }

        /// <summary>
        /// /// <summary>
        /// Generate the 'Sales Report' reports, based on the given period.
        /// </summary>
        /// <example
        /// <param name="periodIndex">Index of the period the report should be generated for</param>
        private void GenerateSalesReport(int periodIndex)
        {
            DateTime currentDateTime = DateTime.Now;
            bool isMoneyReport = true;
            if (periodIndex == 1)
            {
                decimal[] totalRevenueByHours = this.receiptBusiness.GetDailyRevenue(currentDateTime);
                string[] labels = this.hourLabels;
                this.GenerateReport(totalRevenueByHours, labels, "Hour", "Revenue", 0, isMoneyReport);
            }
            else if (periodIndex == 2)
            {
                decimal[] totalRevenueByDays = this.receiptBusiness.GetMonthlyRevenue(currentDateTime);
                string[] labels = this.dayLabels;
                this.GenerateReport(totalRevenueByDays, labels, "Day", "Revenue", 0, isMoneyReport);
            }
            else if (periodIndex == 3)
            {
                decimal[] totalRevenueByDays = this.receiptBusiness.GetYearlyRevenue(currentDateTime);
                string[] labels = this.monthLabels;
                this.GenerateReport(totalRevenueByDays, labels, "Month", "Revenue", 0, isMoneyReport);
            }
        }

        /// <summary>
        /// Generate a report, filled with values, passed by parameters.
        /// </summary>
        /// <param name="values">The values to include in the report.</param>
        /// <param name="labels">The labels to use for the xAxis</param>
        /// <param name="xAxisTitle">The title of the xAxis</param>
        /// <param name="yAxisTitle">The title of the yAxis</param>
        /// <param name="labelRotation">Value, indicating whether the report is about calculating money or quantity</param>
        private void GenerateReport(decimal[] values, string[] labels, string xAxisTitle, string yAxisTitle, int labelRotation, bool isMoneyReport)
        {
            this.reportChart.Series = new SeriesCollection();

            if(isMoneyReport)
            {
                InitializeMoneySeries();
            }
            else
            {
                InitializeCountSeries();
            }

            this.InitializeAxes(xAxisTitle, labels, yAxisTitle, labelRotation);

            // Fill the chart with the given values.
            foreach (var value in values)
            {
                this.reportChart.Series[0].Values.Add(value);
            }
        }

        /// <summary>
        /// Initialize generic money series for a report.
        /// </summary>
        private void InitializeMoneySeries()
        {
            this.reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = this.reportBarColoredBrush,
                LabelPoint = value => string.Format($"$ {value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = this.reportValueLabelBrush
            });
        }

        /// <summary>
        /// Initialize generic count series for a report.
        /// </summary>
        private void InitializeCountSeries()
        {
            this.reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = this.reportBarColoredBrush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = this.reportValueLabelBrush
            });
        }

        /// <summary>
        /// Initialize X- and Y-axis by given parameters.
        /// </summary>
        /// <param name="axisXTitle">The title of the X-Axis.</param>
        /// <param name="axisXLabels">The labels, used to indicate the values in the X-Title</param>
        /// <param name="axisYTitle">The title of the Y-Axis.</param>
        /// <param name="labelsRotation">The rotation of the labels.</param>
        private void InitializeAxes(string axisXTitle, string[] axisXLabels, string axisYTitle, int labelsRotation)
        {
            // Initialize both axes.
            this.reportChart.AxisX.Clear();
            this.reportChart.AxisX.Add(new Axis
            {
                Title = axisXTitle,
                Separator = new Separator { Step = 1, IsEnabled = false },
                Labels = axisXLabels,
                FontSize = 15,
                FontFamily = this.reportFontFamily,
                Foreground = this.reportGraphLabelBrush,
                LabelsRotation = labelsRotation
            });

            this.reportChart.AxisY.Clear();
            this.reportChart.AxisY.Add(new Axis
            {
                Title = axisYTitle,
                FontSize = 15,
                FontFamily = this.reportFontFamily,
                Foreground = this.reportGraphLabelBrush
            });
        }

        /// <summary>
        /// This event triggers when the 'Export Report' Button is clicked.
        /// Proceeds to save a PNG image of the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportReportButton_Click(object sender, EventArgs e)
        {
            // Validate the fileName
            string fileName = this.fileNameTextBox.Text;
            if(string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(fileName))
            {
                System.Windows.Forms.MessageBox.Show("Invalid name of file.");
                return;
            }

            // Select a path and if it is correct, proceed to export the file.
            FolderBrowserDialog folderBrowserDialog;
            using (folderBrowserDialog = new FolderBrowserDialog())
            {
                var result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    string path = folderBrowserDialog.SelectedPath + "\\" + fileName + ".png";
                    try
                    {
                        this.SaveToPng(reportChart, path);
                        System.Windows.Forms.MessageBox.Show($"Image was successfully saved at {path}");
                    }
                    catch
                    {
                        System.Windows.Forms.MessageBox.Show("Image could NOT be saved. Something went wrong.");
                    }
                }
            }
        }

        /// <summary>
        /// This method encodes the chart into a PNG image and exports it
        /// into the given path.
        /// </summary>
        /// <param name="visual">The visual element to encode</param>
        /// <param name="path">The path to save the visual element to</param>
        private void SaveToPng(FrameworkElement visual, string path)
        {
            var encoder = new PngBitmapEncoder();

            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(path))
            {
                encoder.Save(stream);
            }
        }
    }
}
