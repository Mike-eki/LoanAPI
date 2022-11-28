namespace LoanAPI.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static object GetPropValue(this object src, string propertyName)
        {
            return src.GetType()?.GetProperty(propertyName)?.GetValue(src);
        }
    }
}
