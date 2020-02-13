using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SudokuTable tab = new SudokuTable(); tab.makeNewSudoku();
            
            DataTable sudokuData = CreateDataTableFromList(tab.getTable());
            sudokuView.DataContext = sudokuData.DefaultView; // Binding of DataGrid to DataTable
        }

        // Creating DataTable of table to display
        private DataTable CreateDataTableFromList(List<int> tb)
        { // expects list of 81 ints defining sudoku
            DataTable dt = new DataTable("SudokuView");
            for(int i=0;i<9;i++) dt.Columns.Add("c"+i, typeof (int));
            DataRow dtr;
            for (int r = 0; r<9; r++)
            {
                dtr=dt.NewRow();
                for (int c=0; c<9; c++) dtr[c]=tb[r*9+c];
                dt.Rows.Add(dtr);
            }

            //int g = (int) (dt.Rows[0][4]);
            //dt.Rows[0][4]=18;
            return dt;
        }
    }
}
