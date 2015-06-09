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

        public Vector<type> operator +(Vector<type> addend)
        {
            if (this.getSize() != addend.getSize())
            {
                return null;
            }
            type[] temp_vector = new type[this.size];
            for (int i = 0; i < this.getSize(); i++)
            {
                temp_vector[i] = (dynamic)this.getValue(i) + addend.getValue(i);
            }
            Vector<type> return_vector = new Vector<type>(this.getSize());
            return_vector.setValues(temp_vector);
            return return_vector;
        }

        public Vector<type> operator -(Vector<type> addend)
        {
            if (this.getSize() != addend.getSize())
            {
                return null;
            }
            type[] temp_vector = new type[this.size];
            for (int i = 0; i < this.getSize(); i++)
            {
                temp_vector[i] = (dynamic)this.getValue(i) - addend.getValue(i);
            }
            Vector<type> return_vector = new Vector<type>(this.getSize());
            return_vector.setValues(temp_vector);
            return return_vector;
        }

        public Vector<type> scale(double scalar)
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


    }
}
