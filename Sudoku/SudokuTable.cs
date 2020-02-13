using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class SudokuTable
    {
        private List<int> stab; /* inner table of numbers */
        private Random rnd; /* random generator */

        /* constructor */
        public SudokuTable() { stab=new List<int>(81); makeBasicSudoku(); rnd = new Random(); }

        /* export table outside */
        public List<int> getTable() { return stab;  }

        /* fills predefined sudoku set */
        public void makeBasicSudoku()
        {
            for (int r = 0; r<9; r++)
                for (int c = 0; c<9; c++)
                    stab.Add((r*3+r/3+c)%9+1);
        }

        /* make new sudoku by mixing rows and columns  */
        public void makeNewSudoku()
        {
            for(int i=0;i<5;i++) { mixRows();  mixColumns();  }
        }

        /* exchange two rows from the same triplet other then randomly chosen row */
        private void mixRows()
        {
            int r1, r2, t, rx = rnd.Next(9); // random row

            switch(rx%3)
            {  // rows to exchange
                case 0: r1=rx+1; r2=rx+2; break;
                case 1: r1=rx-1; r2=rx+1; break;
                case 2: r1=rx-2; r2=rx-1; break;
                default: r1=0; r2=1; break; // just in case :)
            }

            for(int c=0;c<9;c++) { t=stab[r1*9+c]; stab[r1*9+c]=stab[r2*9+c]; stab[r2*9+c]=t; } //exchanging
        }

        /* exchange two columns from the same triplet other then randomly chosen column */
        private void mixColumns()
        {
            int c1, c2, t, cx = rnd.Next(9); // random col

            switch(cx%3)
            {  // cols to exchange
                case 0: c1=cx+1; c2=cx+2; break;
                case 1: c1=cx-1; c2=cx+1; break;
                case 2: c1=cx-2; c2=cx-1; break;
                default: c1=0; c2=1; break; // just in case :)
            }

            for(int r=0;r<9;r++) { t=stab[r*9+c1]; stab[r*9+c1]=stab[r*9+c2]; stab[r*9+c2]=t; } //exchanging
        }


    }
}
