using System;


namespace Laba4_V_11
{
    public class ComplexNumber
    {
        private double _real;
        private double _imaginary;
        private ushort _phormat;
        /// <summary>
        /// Свойстов формата комплексного числа, где содержится проверка
        /// </summary>
        private ushort Phormat
        {
            set {
                if(value ==0 ||value == 1)
                {
                    _phormat = value;
                }
                else
                {
                    throw new ArgumentException("Принимает только 1 или 0");
                }
            }
            get => _phormat;
        }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="real">действительная часть комплексного числа</param>
        /// <param name="imaginary">мнимая часть комплексного числа</param>
        /// <param name="pr">принимает 0 или 1 (0-тригонометрическая форма, 1 - алгебраическая форма)</param>
        public ComplexNumber(double real, double imaginary, ushort pr =1 )
        {
            this._real = real;
            this._imaginary = imaginary;
            Phormat= pr;
        }
        /// <summary>
        /// сумирование двух комплексных чисел 
        /// </summary>
        /// <param name="c1">первое комплексное число</param>
        /// <param name="c2">второе комплексное число</param>
        /// <returns></returns>
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            if(c1 is not null && c2 is not null)
            {
                return new ComplexNumber(c1._real + c2._real, c1._imaginary + c2._imaginary);
            }
            else
            {
                throw new ArgumentNullException("Один из аргументов ноль");
            }
            
        }
        /// <summary>
        /// вычитание двух комплексных чисел 
        /// </summary>
        /// <param name="c1">первое комплексное число</param>
        /// <param name="c2">второе комплексное число</param>
        /// <returns></returns>
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is not null && c2 is not null)
            {
                return new ComplexNumber(c1._real - c2._real, c1._imaginary - c2._imaginary);
            }
            else
            {
                throw new ArgumentNullException("Один из аргументов ноль");
            }
        }
        /// <summary>
        /// умножение двух комплексных чисел
        /// </summary>
        /// <param name="c1">первое комплексное число</param>
        /// <param name="c2">второе комплексное число</param>
        /// <returns></returns>
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is not null && c2 is not null)
            {
                return new ComplexNumber(
                    c1._real * c2._real - c1._imaginary * c2._imaginary,
                    c1._real * c2._imaginary + c1._imaginary * c2._real
                    );
            }
            else
            {
                throw new ArgumentNullException("Один из аргументов ноль");
            }
        }
        /// <summary>
        /// деление двух комплексных чисел
        /// </summary>
        /// <param name="c1">первое комплексное число</param>
        /// <param name="c2">второе комплексное число</param>
        /// <returns></returns>
        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is not null && c2 is not null)
            {
                double denominator = c2._real * c2._real + c2._imaginary * c2._imaginary;
                if(denominator != 0)
                {
                    double realPart = (c1._real * c2._real + c1._imaginary * c2._imaginary) / denominator;
                    double imaginaryPart = (c1._imaginary * c2._real - c1._real * c2._imaginary) / denominator;
                    return new ComplexNumber(realPart, imaginaryPart);
                }
                else
                {
                    throw new DivideByZeroException("Деление на ноль невозможно");
                }
                
            }
            else
            {
                throw new ArgumentNullException("Один из аргументов ноль");
            }
        }
        /// <summary>
        /// вывод комплексного числа в алгебраической и тригонометрической формах
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            double moduleComplexNumber = Math.Sqrt(_real * _real + _imaginary * _imaginary);
            double angle = Math.Atan2(_imaginary, _real);
            return $"Алгебраическая: {_real} + {_imaginary}i \n Тригонометрическая: {moduleComplexNumber} * (cos({angle}) + i * sin({angle}))";//тригонометрическая форма
        }
    }
}
