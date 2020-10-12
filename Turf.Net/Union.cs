using NetTopologySuite.Geometries;
using System;

namespace Turf.Net
{

    public class Union<T1>
    {
        public object Value { get; private set; }

        public static implicit operator Union<T1>(T1 value) => new Union<T1>() { Value = value };
        public static implicit operator T1(Union<T1> union) => (T1)union.Value;
    }
    public class Union<T1, T2>
    {
        public object Value { get; private set; }
        public static implicit operator Union<T1, T2>(T1 value) => new Union<T1, T2>() { Value = value };
        public static implicit operator Union<T1, T2>(T2 value) => new Union<T1, T2>() { Value = value };

        public static implicit operator T2(Union<T1, T2> union) => (T2)union.Value;
        public static implicit operator T1(Union<T1, T2> union) => (T1)union.Value;
    }
    public class Union<T1, T2, T3>
    {
        public object Value { get; private set; }
        public static implicit operator Union<T1, T2, T3>(T1 value) => new Union<T1, T2, T3>() { Value = value };
        public static implicit operator Union<T1, T2, T3>(T2 value) => new Union<T1, T2, T3>() { Value = value };
        public static implicit operator Union<T1, T2, T3>(T3 value) => new Union<T1, T2, T3>() { Value = value };

        public static implicit operator T1(Union<T1, T2, T3> union) => (T1)union.Value;
        public static implicit operator T2(Union<T1, T2, T3> union) => (T2)union.Value;
        public static implicit operator T3(Union<T1, T2, T3> union) => (T3)union.Value;

    }

    public class Union<T1, T2, T3, T4>
    {
        public dynamic Value { get; private set; }
        public static implicit operator Union<T1, T2, T3, T4>(T1 value) => new Union<T1, T2, T3, T4>() { Value = value };
        public static implicit operator Union<T1, T2, T3, T4>(T2 value) => new Union<T1, T2, T3, T4>() { Value = value };
        public static implicit operator Union<T1, T2, T3, T4>(T3 value) => new Union<T1, T2, T3, T4>() { Value = value };
        public static implicit operator Union<T1, T2, T3, T4>(T4 value) => new Union<T1, T2, T3, T4>() { Value = value };

        public static implicit operator T1(Union<T1, T2, T3, T4> union) => (T1)union.Value;
        public static implicit operator T2(Union<T1, T2, T3, T4> union) => (T2)union.Value;
        public static implicit operator T3(Union<T1, T2, T3, T4> union) => (T3)union.Value;
        public static implicit operator T4(Union<T1, T2, T3, T4> union) => (T4)union.Value;
    }
}
