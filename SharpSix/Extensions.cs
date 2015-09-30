namespace SharpSix
{
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void Add<T>(this LinkedList<T> list, T target)
        {
            list.AddLast(target);
        }
    }
}