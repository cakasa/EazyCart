using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using Data.Models;
using System.Windows.Media;
using Business;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace EazyCart
{
    public partial class StatisticsUserContol : UserControl
    {
        private ProductBusiness productBusiness;
        private ReceiptBusiness receiptBusiness;
        private System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(44, 62, 80);
        private System.Windows.Media.Brush brush;

        public StatisticsUserContol()
        {
            InitializeComponent();
        }

        private void StatisticsUserContol_Load(object sender, EventArgs e)
        {
            reportCategoryComboBox.SelectedIndex = 0;
            productBusiness = new ProductBusiness();
            receiptBusiness = new ReceiptBusiness();
            brush = new System.Windows.Media.SolidColorBrush(color);
        }

        private void ReportCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportCategoryComboBox.SelectedIndex != 0)
            {
                reportTypeComboBox.Enabled = true;
                int categoryIndex = reportCategoryComboBox.SelectedIndex;
                FillReportTypeComboBox(categoryIndex);
            }
            else
            {
                reportTypeComboBox.SelectedIndex = 0;
                reportPeriodComboBox.SelectedIndex = 0;
                reportTypeComboBox.Enabled = false;
            }
        }

        private void FillReportTypeComboBox(int categoryIndex)
        {
            var dataSource = new List<string>();
            dataSource.Add("Select type of report");
            switch (categoryIndex)
            {
                case 1:
                    {
                        dataSource.Add("Sales report");
                        break;
                    }
                case 2:
                    {
                        dataSource.Add("Product quantity in inventory");
                        dataSource.Add("Number of products sorted by supplier");
                        dataSource.Add("Number of products sorted by category");
                        dataSource.Add("Number of products sorted by country");
                        dataSource.Add("Products by profit for a single unit");
                        break;
                    }
                case 3:
                    {
                        dataSource.Add("Number of orders for a period");
                        dataSource.Add("Average number of different products in an order for a period");
                        dataSource.Add("Number of orders featuring discount for a period");
                        break;
                    }
            }

            reportTypeComboBox.DataSource = dataSource;
        }

        private void ReportTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reportTypeComboBox.SelectedIndex == 0)
            {
                reportPeriodComboBox.Enabled = false;
            }
            else if (reportCategoryComboBox.SelectedIndex == 1 || reportCategoryComboBox.SelectedIndex == 3)
            {
                reportPeriodComboBox.Enabled = true;
            }           
            else
            {
                reportPeriodComboBox.Enabled = false;               
            }
            reportPeriodComboBox.SelectedIndex = 0;
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            int categoryIndex = reportCategoryComboBox.SelectedIndex;
            int typeIndex = reportTypeComboBox.SelectedIndex;
            int periodIndex = reportPeriodComboBox.SelectedIndex;

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
            else GetReportNumber(categoryIndex, typeIndex, periodIndex);
        }

        private void GetReportNumber(int categoryIndex, int typeIndex, int periodIndex)
        {
            int reportNumber = 0;
            if(categoryIndex == 1)
            {
                reportNumber = typeIndex;
            }
            else if(categoryIndex == 2)
            {
                reportNumber = typeIndex + 1;
            }
            else
            {
                reportNumber = typeIndex + 6;
            }

            GenerateReport(reportNumber, periodIndex);
        }

        private void GenerateReport(int reportNumber, int periodIndex)
        {
            switch (reportNumber)
            {
                case 1:
                    {
                        GenerateSalesReport(periodIndex);
                        break;
                    }
                case 2:
                    {
                        GenerateProductsQuantityInInventoryReport();
                        break;
                    }
                case 3:
                    {
                        GenerateProductsBySupplierReport();
                        break;
                    }
                case 4:
                    {
                        GenerateProductsByCategoryReport();
                        break;
                    }
                case 5:
                    {
                        GenerateProductsByCountryReport();
                        break;
                    }
                case 6:
                    {
                        GenerateProductsByNetProfitForSingleUnit();
                        break;
                    }
                case 7:
                    {
                        GenerateOrdersNumber(periodIndex);
                        break;
                    }
                case 8:
                    {
                        GenerateAverageNumberOfDifferentProducts(periodIndex);
                        break;
                    }
                case 9:
                    {
                        GenerateOrdersFeaturingDiscounts(periodIndex);
                        break;
                    }
            }
        }

        private void GenerateOrdersFeaturingDiscounts(int periodIndex)
        {
            if(periodIndex == 1)
            {
                GenerateDailyOrdersFeaturingDiscounts();
            }
            else if(periodIndex == 2)
            {
                GenerateMonthlyOrdersFeaturingDiscounts();
            }
            else if(periodIndex == 3)
            {
                GenerateYearlyOrdersFeaturingDiscounts();
            }
        }

        private void GenerateYearlyOrdersFeaturingDiscounts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] ordersFeaturingDiscountByMonth = receiptBusiness.GetYearlyDiscountOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Month", labels, "Number of orders featuring discount", 0);

            foreach (var numberOfOrders in ordersFeaturingDiscountByMonth)
            {
                reportChart.Series[0].Values.Add(numberOfOrders);
            }
        }

        private void GenerateMonthlyOrdersFeaturingDiscounts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] dailyNumberOfOrdersWithDiscount = receiptBusiness.GetMonthlyDiscountOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[dailyNumberOfOrdersWithDiscount.Length];
            for (int i = 0; i < dailyNumberOfOrdersWithDiscount.Length; i++)
            {
                labels[i] = string.Format($"{i + 1}");
            }

            InitializeAxes("Day", labels, "Number of orders featuring discount", 0);
            foreach (var numberOfOrders in dailyNumberOfOrdersWithDiscount)
            {
                reportChart.Series[0].Values.Add(numberOfOrders);
            }
        }

        private void GenerateDailyOrdersFeaturingDiscounts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] hourlyNumberOfOrdersWithDiscount = receiptBusiness.GetDailyDiscountOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Hour", labels, "Number of orders featuring discount", 0);
            foreach (var numberOfOrders in hourlyNumberOfOrdersWithDiscount)
            {
                reportChart.Series[0].Values.Add(numberOfOrders);
            }
        }

        private void GenerateAverageNumberOfDifferentProducts(int periodIndex)
        {
            if (periodIndex == 1)
            {
                GenerateDailyAverageNumberOfDifferentProducts();
            }
            else if (periodIndex == 2)
            {
                GenerateMonthlyAverageNumberOfDifferentProducts();
            }
            else if (periodIndex == 3)
            {
                GenerateYearlyMonthlyAverageNumberOfDifferentProducts();
            }
        }

        private void GenerateYearlyMonthlyAverageNumberOfDifferentProducts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] averageNumberOfDifferentProductInOrders = receiptBusiness.GetYearlyAverageAmountOfDifferentProducts(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Month", labels, "Average number of products", 0);

            foreach (var averageNumberOfProducts in averageNumberOfDifferentProductInOrders)
            {
                reportChart.Series[0].Values.Add(averageNumberOfProducts);
            }
        }

        private void GenerateMonthlyAverageNumberOfDifferentProducts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] averageNumberOfDifferentProductInOrders = receiptBusiness.GetMonthlyverageAmountOfDifferentProducts(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[averageNumberOfDifferentProductInOrders.Length];
            for (int i = 0; i < averageNumberOfDifferentProductInOrders.Length; i++)
            {
                labels[i] = string.Format($"{i + 1}");
            }

            InitializeAxes("Day", labels, "Average number of products", 0);
            foreach (var averageNumberOfProducts in averageNumberOfDifferentProductInOrders)
            {
                reportChart.Series[0].Values.Add(averageNumberOfProducts);
            }
        }

        private void GenerateDailyAverageNumberOfDifferentProducts()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] averageNumberOfDifferentProductInOrders = receiptBusiness.GetDailyAverageAmountOfDifferentProducts(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Hour", labels, "Average number of products", 0);
            foreach (var averageNumberOfProducts in averageNumberOfDifferentProductInOrders)
            {
                reportChart.Series[0].Values.Add(averageNumberOfProducts);
            }
        }

        private void GenerateOrdersNumber(int periodIndex)
        {
            if(periodIndex == 1)
            {
                GenerateDailyOrdersNumber();
            }
            else if(periodIndex == 2)
            {
                GenerateWMonthlyOrdersNumber();
            }
            else if(periodIndex == 3)
            {
                GenerateYearlyOrdersNumber();
            }
        }

        private void GenerateYearlyOrdersNumber()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] totalOrdersByMonth = receiptBusiness.GetYearlyOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Month", labels, "Number of orders", 0);

            foreach (var totalRevenue in totalOrdersByMonth)
            {
                reportChart.Series[0].Values.Add(totalRevenue);
            }
        }

        private void GenerateWMonthlyOrdersNumber()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] dailyNumberOfOrders = receiptBusiness.GetMonthlyOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[dailyNumberOfOrders.Length];
            for (int i = 0; i < dailyNumberOfOrders.Length; i++)
            {
                labels[i] = string.Format($"{i + 1}");
            }

            InitializeAxes("Day", labels, "Number of orders", 0);
            foreach (var numberOfOrders in dailyNumberOfOrders)
            {
                reportChart.Series[0].Values.Add(numberOfOrders);
            }
        }

        private void GenerateDailyOrdersNumber()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            int[] hourlyNumberOfOrders = receiptBusiness.GetDailyOrders(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Hour", labels, "Number of orders", 0);
            foreach (var numberOfOrders in hourlyNumberOfOrders)
            {
                reportChart.Series[0].Values.Add(numberOfOrders);
            }
        }

        private void GenerateProductsByNetProfitForSingleUnit()
        {
            reportChart.Series = new SeriesCollection();

            Dictionary<string, decimal> netProfitByProduct = productBusiness.GetNetProfitByProduct();

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                LabelPoint = value => string.Format($"$ {value.Y:f2}"),
                FontSize = 15,
                Fill = brush,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[netProfitByProduct.Count()];
            int index = 0;
            foreach (var netProfit in netProfitByProduct)
            {
                labels[index] = netProfit.Key;
                index++;
            }

            int labelsRotation = 0;
            if (netProfitByProduct.Count > 30) labelsRotation = 45;
            InitializeAxes("Product", labels, "Net Profit", labelsRotation);
            foreach (var productProfitPair in netProfitByProduct)
            {
                reportChart.Series[0].Values.Add(productProfitPair.Value);
            }
        }

        private void GenerateProductsByCountryReport()
        {
            reportChart.Series = new SeriesCollection();

            Dictionary<string, int> productCountByCountry = productBusiness.GetCountOfProductsByCountry();

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                Fill = brush,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[productCountByCountry.Count()];
            int index = 0;
            foreach (var productQuantity in productCountByCountry)
            {
                labels[index] = productQuantity.Key;
                index++;
            }

            int labelsRotation = 0;
            if (productCountByCountry.Count > 30) labelsRotation = 45;
            InitializeAxes("Country", labels, "Number of products", labelsRotation);
            foreach (var countryProductPair in productCountByCountry)
            {
                reportChart.Series[0].Values.Add(countryProductPair.Value);
            }
        }

        private void GenerateProductsByCategoryReport()
        {
            reportChart.Series = new SeriesCollection();

            Dictionary<string, int> productCountByCategory = productBusiness.GetCountOfProductsByCategory();

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                Fill = brush,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[productCountByCategory.Count()];
            int index = 0;
            foreach (var productQuantity in productCountByCategory)
            {
                labels[index] = productQuantity.Key;
                index++;
            }

            int labelsRotation = 0;
            if (productCountByCategory.Count > 30) labelsRotation = 45;
            InitializeAxes("Category", labels, "Number of products", labelsRotation);
            foreach (var categoryProductsPair in productCountByCategory)
            {
                reportChart.Series[0].Values.Add(categoryProductsPair.Value);
            }
        }

        private void GenerateProductsBySupplierReport()
        {
            reportChart.Series = new SeriesCollection();

            Dictionary<string, int> productCountBySupplier = productBusiness.GetCountOfProductsBySuppliers();

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<int>(),
                DataLabels = true,
                LabelPoint = value => string.Format($"{value.Y}"),
                FontSize = 15,
                Fill = brush,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[productCountBySupplier.Count()];
            int index = 0;
            foreach (var supplierCountPair in productCountBySupplier)
            {
                labels[index] = supplierCountPair.Key;
                index++;
            }

            int labelsRotation = 0;
            if (productCountBySupplier.Count > 30) labelsRotation = 45;
            InitializeAxes("Supplier", labels, "Number of products", labelsRotation);
            foreach (var supplierCountPair in productCountBySupplier)
            {
                reportChart.Series[0].Values.Add(supplierCountPair.Value);
            }
        }

        private void GenerateProductsQuantityInInventoryReport()
        {
            reportChart.Series = new SeriesCollection();

            Dictionary<string, decimal> allProductQuantities= productBusiness.GetAllQuantities();

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                LabelPoint = value => string.Format($"{value.Y:f1}"),
                Fill = brush,
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[allProductQuantities.Count()];
            int index = 0;
            foreach(var productQuantity in allProductQuantities)
            {
                labels[index] = productQuantity.Key;
                index++;
            }

            int labelsRotation = 0;
            if (allProductQuantities.Count > 30) labelsRotation = 45;
            InitializeAxes("Product", labels, "Quantity", labelsRotation);
            foreach (var productQuantity in allProductQuantities)
            {
                reportChart.Series[0].Values.Add(productQuantity.Value);
            }
        }

        // Generate Sales Report
        private void GenerateSalesReport(int periodIndex)
        {
            if (periodIndex == 1)
            {
                GenerateDailySalesReport();
            }
            else if (periodIndex == 2)
            {
                GenerateMonthlySalesReport();
            }
            else if (periodIndex == 3)
            {
                GenerateYearlySalesReport();
            }
        }

        private void GenerateDailySalesReport()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] totalRevenueByHours = productBusiness.GetDailyRevenue(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => "$ " + string.Format($"{value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Hour", labels, "Revenue", 0);
            foreach (var totalRevenue in totalRevenueByHours)
            {
                reportChart.Series[0].Values.Add(totalRevenue);
            }
        }

        private void GenerateMonthlySalesReport()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] totalRevenueByDays = productBusiness.GetMonthlyRevenue(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => "$ " + string.Format($"{value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[totalRevenueByDays.Length];
            for (int i = 0; i < totalRevenueByDays.Length; i++)
            {
                labels[i] = string.Format($"{i + 1}");
            }

            InitializeAxes("Day", labels, "Revenue", 0);
            foreach (var totalRevenue in totalRevenueByDays)
            {
                reportChart.Series[0].Values.Add(totalRevenue);
            }
        }

        private void GenerateYearlySalesReport()
        {
            reportChart.Series = new SeriesCollection();
            DateTime currentDateTime = DateTime.Now;

            decimal[] totalRevenueByMonths = productBusiness.GetYearlyRevenue(currentDateTime);

            reportChart.Series.Add(new ColumnSeries
            {
                Title = "",
                Values = new ChartValues<decimal>(),
                DataLabels = true,
                Fill = brush,
                LabelPoint = value => string.Format($"$ {value.Y:f2}"),
                FontSize = 15,
                LabelsPosition = BarLabelPosition.Parallel,
                Foreground = System.Windows.Media.Brushes.GhostWhite
            });

            string[] labels = new string[]
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

            InitializeAxes("Month", labels, "Revenue", 0);

            foreach (var totalRevenue in totalRevenueByMonths)
            {
                reportChart.Series[0].Values.Add(totalRevenue);
            }
        }

        private void InitializeAxes(string axisXTitle, string[] axisXLabels, string axisYTitle, int labelsRotation)
        {
            reportChart.AxisX.Clear();
            reportChart.AxisX.Add(new Axis
            {
                Title = axisXTitle,
                Separator = new Separator { Step = 1, IsEnabled = false },
                Labels = axisXLabels,
                FontSize = 15,
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                Foreground = System.Windows.Media.Brushes.Black,
                LabelsRotation = labelsRotation
            });

            reportChart.AxisY.Clear();
            reportChart.AxisY.Add(new Axis
            {
                Title = axisYTitle,
                FontSize = 15,
                FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
                Foreground = System.Windows.Media.Brushes.Black
            });         
        }

        private void ExportReportButton_Click(object sender, EventArgs e)
        {
            SaveToPng(reportChart, "chart.png");
            System.Windows.Forms.MessageBox.Show("Image was successfully saved");
        }

       private void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            EncodeVisual(visual, fileName, encoder);
        }

        private static void EncodeVisual(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }
    }
}
