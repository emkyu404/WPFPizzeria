using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Projet_Pizzaria
{
    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals([AllowNull] Item x, [AllowNull] Item y)
        {
           if(x.GetType() != y.GetType())
           {
                return false;
            }
            else
            {
                if (x.Equals(y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int GetHashCode([DisallowNull] Item obj)
        {
            return obj.GetHashCode();
        }
    }
}
