using System;


namespace nl.hyperdata.music.core
{
    public abstract class ElementBase :  IElementBase
    { 
        public double Value { get; }

        protected ElementBase(double innervalue)
        {
            Value = innervalue;
        }

        public int CompareTo(IElementBase other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return CompareTo(other.Value);
        }

        public int CompareTo(double other)
        {
            return (int)((Value * 1000000) - (other * 1000000));
        }


        public override bool Equals(object obj)
        {
            return Equals(obj as ElementBase);
        }

        public bool Equals(double other)
        {
            return Math.Round(Value, 2) == Math.Round(other, 2);
        }

        public bool Equals(IElementBase other)
        {
            if (other is null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

 
        public static bool operator ==(ElementBase left, IElementBase right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(ElementBase left, IElementBase right)
        {
            return !(left == right);
        }

        public static bool operator <(ElementBase left, IElementBase right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ElementBase left, IElementBase right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(ElementBase left, IElementBase right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(ElementBase left, IElementBase right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }


        public static double operator *(ElementBase left, IElementBase right)
        {
            return left.Value * right.Value;
        }

        public static double operator /(ElementBase left, IElementBase right)
        {
            return left.Value * right.Value;
        }

        public static double operator %(ElementBase left, IElementBase right)
        {
            return left.Value % right.Value;
        }

        public static bool operator ==(ElementBase left, double right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(ElementBase left, double right)
        {
            return !(left == right);
        }

        public static bool operator <(ElementBase left, double right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ElementBase left, double right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(ElementBase left, double right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(ElementBase left, double right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }


        public static double operator *(ElementBase left, double right)
        {
            return left.Value * right;
        }

        public static double operator /(ElementBase left, double right)
        {
            return left.Value * right;
        }

        public static double operator %(ElementBase left, double right)
        {
            return left.Value % right;
        }
    }
}

