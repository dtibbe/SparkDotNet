namespace SparkDotNet
{
    [System.AttributeUsage(System.AttributeTargets.Field)]
    class SparkARResettable : System.Attribute
    {
        public object DefaultValue = null;
    }
}
