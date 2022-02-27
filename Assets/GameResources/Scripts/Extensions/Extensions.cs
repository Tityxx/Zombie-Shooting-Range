using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Расширения для разных классов
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Находится ли число между двумя другими
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public static bool IsBetween<T>(this T item, T start, T end)
    {
        return Comparer<T>.Default.Compare(item, start) >= 0
            && Comparer<T>.Default.Compare(item, end) <= 0;
    }
}
