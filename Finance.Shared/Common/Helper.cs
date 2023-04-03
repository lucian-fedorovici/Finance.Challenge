using System;
using System.Text.RegularExpressions;
using System.Web.Security.AntiXss;

namespace Finance.Shared.Common
{
    public static class Helper
    {

        /// <summary>
        ///  Removes any html tags which may have been pasted into free text inputs. Retains single < and > characters as entered, supporting all output mediums.
        /// </summary>
        /// <returns>
        ///  String replacing with blank parts matching: @"<[^>\s][^>]*>" being: A < followed by anything but a space or a >, followed by any number of anything (excepy a >), ending with a >.
        ///  For example "<script>alert('a');</script>" returned as just "alert('a');". "<> test < less > 5 <iframe x=y/>" returned as "<> test < less > 5". 
        /// </returns>
        public static string SanitizeString(string strSource)
        {
            if (strSource == null) return strSource;
            strSource = Regex.Replace(strSource.ToString(), @"<[^>\s][^>]*>", String.Empty);
            if (strSource.IndexOfAny("<>".ToCharArray()) != -1)
            {
                strSource = AntiXssEncoder.HtmlEncode(strSource, true);
            }
            return strSource;
        }
    }
}
