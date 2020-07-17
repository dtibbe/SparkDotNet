using System.Reflection;
using Newtonsoft.Json;

namespace SparkDotNet
{
    /// <summary>
    /// This is a common superclass for all Webex API objects.
    /// It will bundle their common behavior
    /// </summary>
    public abstract class WebexObject
    {
        /// <summary>
        /// Reference to the Spark client object for this
        /// </summary>
        protected Spark SparkClient { get; set; }

        /// <summary>
        /// Returns the JSON representation of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        #region Spark AR
        public void Reset()
        {
            foreach (var prop in GetType().GetTypeInfo().GetProperties())
            {
                var resettableAttribute = prop.GetCustomAttribute<SparkARResettable>(true);
                if  (resettableAttribute != null)
                {
                    prop.SetValue(this, resettableAttribute.DefaultValue);
                }
            }
        }

        public virtual void UpdateObject(object source)
        {
        }
        #endregion Spark AR
    }
}
