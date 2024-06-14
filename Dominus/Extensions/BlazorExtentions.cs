namespace Dominus.Extensions
{
    public static  class BlazorExtentions
    {
        public static string GetFullExceptionMessage(this Exception e)
        {
            string message = "";
            while (e != null)
            {
                message = e.Message + "\n";
                e = e.InnerException;
            }
            return message;
        }
    }
}
