using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game.Utils
{
public struct Index2 : IEquatable<Index2>
{
    public int x;
    public int y;

    public Index2(int x, int y)
    {
        this.y = y;
        this.x = x;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator == (Index2 lhs, Index2 rhs)
    {
        return lhs.x == rhs.x && lhs.y == rhs.y;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(Index2 lhs, Index2 rhs)
    {
        return !(lhs == rhs);
    }

    public bool Equals(Index2 other)
    {
        return x == other.x && y == other.y;
    }

    public override bool Equals(object obj)
    {
        return obj is Index2 other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
    
    /// <summary>
    ///   <para>Returns a formatted string for this vector.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="formatProvider">An object that specifies culture-specific formatting.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => ToString(null, null);

    /// <summary>
    ///   <para>Returns a formatted string for this vector.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="formatProvider">An object that specifies culture-specific formatting.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string format) => ToString(format, null);

    /// <summary>
    ///   <para>Returns a formatted string for this vector.</para>
    /// </summary>
    /// <param name="format">A numeric format string.</param>
    /// <param name="formatProvider">An object that specifies culture-specific formatting.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (string.IsNullOrEmpty(format))
            format = "F2";
        formatProvider ??= CultureInfo.InvariantCulture.NumberFormat;
        return $"({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}
}