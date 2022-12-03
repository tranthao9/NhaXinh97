using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhaXinhBUS.common
{
	public class Stringhelper
	{
        public static string ConvertToUnSign(string text)

        {
            for (int i = 32; i < 48; i++)

            {

                text = text.Replace(((char)i).ToString(), " ");

            }

            text = text.Replace(".", "-");

            text = text.Replace(" ", "-");

            text = text.Replace(",", "-");

            text = text.Replace(";", "-");

            text = text.Replace(":", "-");



            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");



            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

        }
    }
}
