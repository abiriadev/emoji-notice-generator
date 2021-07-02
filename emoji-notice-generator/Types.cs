namespace emoji_notice_generator
{
    public delegate T cb<T>(T item, int index);

    public delegate bool Condition(string option);
}