namespace Methods.Models
{
    using System;
    
    public class Triangle
    {
        private double sideA;

        private double sideB;

        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.SideC = sideC;
        }

        public double SideA
        {
            get
            {
                return this.sideA;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The side of the triangle cannot be zero or negative " + value);
                }

                this.sideA = value;
            }
        }

        public double SideB
        {
            get
            {
                return this.sideB;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The side of the triangle cannot be zero or negative " + value);
                }

                this.sideB = value;
            }
        }

        public double SideC
        {
            get
            {
                return this.sideC;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("The side of the triangle cannot be zero or negative " + value);
                }

                this.sideC = value;
            }
        }

        internal double CalcTriangleArea()
        {
            var halfPerimeter = (this.SideA + this.SideB + this.SideC) / 2;
            var area =
                Math.Sqrt(halfPerimeter * (halfPerimeter - this.SideA) * (halfPerimeter - this.SideB) * (halfPerimeter - this.SideC));
            return area;
        }
    }
}
