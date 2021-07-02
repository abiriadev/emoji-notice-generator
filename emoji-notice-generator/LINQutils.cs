using System;

namespace emoji_notice_generator
{
    public class LINQutils
    {

        public static T[] Map<T>(T[] items, cb<T> callback)
        {
            T[] resArr = new T[items.Length];

            for (int i = 0; i < items.Length; ++i)
            {
                T res = callback(items[i], i);
                resArr[i] = res;
            }

            return resArr;
        }
    }
}