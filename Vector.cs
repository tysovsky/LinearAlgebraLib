using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraLib
{
    class Vector<type>
    {
        private type[] vector;
        private int size;

        public Vector()
        {
            vector = new type[1];
        }
        public Vector(int size)
        {
            this.size = size;
            vector = new type[size];
        }

        public type getValue(int position)
        {
            return vector[position];
        }

        public void setValue(type value, int position)
        {
            vector[position] = value;
        }

        public void setValues(type[] values)
        {
            this.vector = values;
        }

        public Vector<type> operator +(Vector<type> augend, Vector<type> addend)
        {
            if (augend.getSize() != addend.getSize())
            {
                return null;
            }
            type[] temp_vector = new type[augend.size];
            for (int i = 0; i < augend.getSize(); i++)
            {
                temp_vector[i] = (dynamic)augend.getValue(i) + addend.getValue(i);
            }
            Vector<type> return_vector = new Vector<type>(augend.getSize());
            return_vector.setValues(temp_vector);
            return return_vector;
        }

        public Vector<type> operator -(Vector<type> minuend, Vector<type> subtrahend)
        {
            if (minuend.getSize() != subtrahend.getSize())
            {
                return null;
            }
            type[] temp_vector = new type[minuend.size];
            for (int i = 0; i < minuend.getSize(); i++)
            {
                temp_vector[i] = (dynamic)minuend.getValue(i) - subtrahend.getValue(i);
            }
            Vector<type> return_vector = new Vector<type>(minuend.getSize());
            return_vector.setValues(temp_vector);
            return return_vector;
        }

        public Vector<type> scale(type scalar)
        {
            for(int i = 0; i < this.getSize(); i++)
            {
                this.setValue((dynamic)this.getValue(i)*scalar, i);
            }

            return this;
        }

        public type dotProduct(Vector<type> vector)
        {
            if (vector.getSize() != this.getSize())
            {
                return default(type);
            }
            type return_value = default(type);
            for (int i = 0; i < this.getSize(); i++)
            {
                return_value += (dynamic)this.getValue(i) + vector.getValue(i);
            }
            return return_value;
        }

        public int getSize()
        {
            return this.size;
        }

        public override string ToString()
        {
            //return base.ToString();
            String return_string = "";
            for (int i = 0; i < this.getSize(); i++)
            {
                return_string += this.getValue(i);
            }
            return return_string;
        }


    }
}
