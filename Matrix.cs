using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraLib
{
    class Matrix<type>
    {
        private type[,] matrix;
        private int rows;
        private int columns; 

        public Matrix()
        {
            this.rows = 1;
            this.columns = 1;
            matrix = new type[rows, columns];
        }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            matrix = new type[rows, columns];
        }

        public Matrix(type[,] matrix)
        {
            this.matrix = matrix;
            this.rows = matrix.GetLength(0);
            this.columns = matrix.GetLength(1);
        }

        public int getRows()
        {
            return this.rows;
        }

        public int getColumns()
        {
            return this.columns;
        }

        public type getValue(int row, int column)
        {
            return this.matrix[row, column];
        }

        public void setValue(int row, int column, type value)
        {
            this.matrix[row, column] = value;
        }

        public Vector<type> getRow(int row)
        {
            Vector<type> temp_vector = new Vector<type>(matrix.GetLength(1));
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                temp_vector.setValue(this.getValue(row, i), i);
            }

            return temp_vector;
        }
        
        public Vector<type> getColumn(int column)
        {
            Vector<type> temp_vector = new Vector<type>(matrix.GetLength(1));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                temp_vector.setValue(this.getValue(i, column), i);
            }

            return temp_vector;
        }

        public void setRow(Vector<type> vector, int row)
        {
            if (vector.getSize() != this.getColumns())
            {
                return;
            }
            for (int i = 0; i < this.getColumns(); i++)
            {
                this.matrix[row, i] = vector.getValue(i);
            }
        }

        public void setColumn(Vector<type> vector, int column)
        {
            if (vector.getSize() != this.getRows())
            {
                return;
            }
            for (int i = 0; i < this.getRows(); i++)
            {
                this.matrix[i, column] = vector.getValue(i);
            }
        }

        public Matrix<type> operator +(Matrix<type> augend, Matrix<type> added)
        {
            if ((augend.getRows() != added.getRows()) && (augend.getColumns() != added.getColumns()))
            {
                return null;
            }

            for (int r = 0; r < augend.getRows(); r++)
            {
                for (int c = 0; c < augend.getColumns(); c++)
                {
                    augend.setValue(r, c, (dynamic)augend.getValue(r, c) + added.getValue(r, c));
                }
            }

            return augend;
        }

        public Matrix<type> operator -(Matrix<type> minuend, Matrix<type> subtrahend)
        {
            if ((minuend.getRows() != subtrahend.getRows()) && (minuend.getRows() != subtrahend.getColumns()))
            {
                return null;
            }

            for (int r = 0; r < minuend.getRows(); r++)
            {
                for (int c = 0; c < minuend.getColumns(); c++)
                {
                    minuend.setValue(r, c, (dynamic)minuend.getValue(r, c) - subtrahend.getValue(r, c));
                }
            }

            return minuend;
        }

        public Matrix<type> transpose()
        {
            Matrix<type> temp_matrix = new Matrix<type>(this.getColumns(), this.getRows());
            for (int r = 0; r < temp_matrix.getRows(); r++)
            {
                for (int c = 0; c < temp_matrix.getColumns(); c++)
                {
                    temp_matrix.setValue(r, c, this.getValue(c, r));
                }
            }

            return temp_matrix;
        }

        public Matrix<type> switchRows(int row1, int row2)
        {
            Vector<type> temp_vector = this.getRow(row1);
            this.setRow(this.getRow(row2), row1);
            this.setRow(temp_vector, row2);

            return this;
        }

        //WIP
        public Matrix<type> toRowEchelon()
        {
            Vector<type> current_row;
            Vector<type> temp_row;
            for (int i = 0; i < this.getRows(); i++)
            {
                current_row = this.getRow(i);
                type pivot = this.getValue(i, i);
                for (int j = i+1; j < this.getRows(); j++)
                {
                    temp_row = this.getRow(j);
                    type scalar = (dynamic)current_row.getValue(i) / temp_row.getValue(i);
                    temp_row.scale(scalar);
                    temp_row -= current_row;
                    this.setRow(temp_row, j);
                }
            }

            return this;
        }

        public override string ToString()
        {
            String return_string = "";
            for (int r = 0; r < this.getRows(); r++)
            {
                return_string += this.getRow(r).ToString() + '\n';
            }

            return return_string;
        }
    }
}
