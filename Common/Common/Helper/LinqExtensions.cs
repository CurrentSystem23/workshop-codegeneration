using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopTestProject.Common.Helper
{
  public static class LinqExtenstions
  {
    public static IEnumerable<TSource> Distinct<TSource, TProperty>(this IEnumerable<TSource> target,
        Func<TSource, TProperty> propertySelector)
    {
      return target.Distinct(propertySelector, EqualityComparer<TProperty>.Default);
    }

    public static IEnumerable<TSource> Distinct<TSource, TProperty>(this IEnumerable<TSource> target,
      Func<TSource, TProperty> propertySelector,
      IEqualityComparer<TProperty> propertyEqualityComparer)
    {
      return target.Distinct(new PropertyComparer<TSource, TProperty>(propertySelector, propertyEqualityComparer));
    }

    private class PropertyComparer<TElement, TProperty> : IEqualityComparer<TElement>
    {
      private readonly Func<TElement, TProperty> _propertySelector;
      private readonly IEqualityComparer<TProperty> _propertyComparer;

      public PropertyComparer(Func<TElement, TProperty> propertySelector)
      {
        _propertySelector = propertySelector;
      }

      public PropertyComparer(Func<TElement, TProperty> propertySelector, IEqualityComparer<TProperty> propertyComparer)
      {
        _propertySelector = propertySelector;
        _propertyComparer = propertyComparer;
      }

      public bool Equals(TElement x, TElement y)
      {
        return _propertyComparer?.Equals(_propertySelector(x), _propertySelector(y)) ??
               _propertySelector(x).Equals(_propertySelector(y));
      }

      public int GetHashCode(TElement obj)
      {
        return _propertyComparer?.GetHashCode(_propertySelector(obj)) ??
               _propertySelector(obj).GetHashCode();
      }
    }
  }
}
