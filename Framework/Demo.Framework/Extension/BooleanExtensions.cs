namespace Framework.Extension
{
    public static class BooleanExtensions
    {
        public static int ToInt32(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}
