using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvelopeAnalyzer
{
    public class Envelope : IComparer<Envelope>
    {
        #region Properties

        public double Weight
        {
            get
            {
                return _weight;    
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be more than 0");
                else
                {
                    _weight = value;
                }
            }   
        }
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Height must be more than 0");
                else
                {
                    _height = value;
                }
            }

        }

        #endregion

        #region Fields

        private double _weight;
        private double _height;

        #endregion

        #region Constructors

        public Envelope(double weight,double height)
        {
            try
            {
                Weight = weight;
                Height = height;
                SetBiggerSizeAsWeight();
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            

        }

        #endregion

        #region Methods

        private void SetBiggerSizeAsWeight()
        {
            if(this.Height > this.Weight)
            {
                double temp = this._height;
                this._height = this._weight;
                this._weight = temp;
            }
                
        }
        public int Compare(Envelope x, Envelope y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException();

            int result = 0;
            bool isFirstHeightBiggerSecondHeight = x.Height > y.Height;
            bool isFirstWeightBiggerSecondWeight = x.Weight > y.Weight;
         
            if (isFirstHeightBiggerSecondHeight && isFirstWeightBiggerSecondWeight)
            {
                result = 1;
            }
            else
            { 
                if (x.Equals(y))
                {
                    result = 0;
                }
                else
                {
                    result = -1;
                }
            }

            return result;

        }
        public override bool Equals(object obj)
        {
            bool isEnvelopesEqual = false;

            if (obj is Envelope secondEnvelope)
            {
                isEnvelopesEqual = this.Height == secondEnvelope.Height && this.Weight == secondEnvelope.Weight;
            }
            else
            {
                throw new ArgumentNullException();
            }

            return isEnvelopesEqual;
        }
        /// <summary>
        /// Method checks if we can put one of the envelopes in the another
        /// </summary>
        /// <param name="envelope">second envelope</param>
        /// <returns>Return true, if we can put one of the envelopes in the second</returns>
        public bool IsCanPutInEnvelope(Envelope envelope)
        {
            bool result;
            
            if (Compare(this,envelope) > 0) //check first is bigger than second
            {
                result = true;
            }
            else
            {
                if(Compare(envelope,this) > 0) //check second is bigger than first
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        #endregion
    }
}
