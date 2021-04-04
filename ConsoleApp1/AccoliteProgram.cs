using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AccoliteProgram
    {
        

        //Pattern matching

        public static bool PatternMatching(string str)
        {
            var patternSet = str.Split(' ').ToList();
            bool isCorrect = false;
            var pattern = patternSet[0];
            var matchString = patternSet[1];

            for(int i=0,j=0; i< pattern.Length; i++)
            {
               switch (pattern[i])
                {
                    case '+':
                        if (Regex.IsMatch(matchString[j].ToString(), @"[A-Za-z]"))
                        {
                            j++;
                        }
                        else
                        {
                            return isCorrect;
                        }
                        break;
                    case '$':
                        if (Regex.IsMatch(matchString[j].ToString(), @"[0-9]"))
                        {
                            j++;
                        }
                        else
                        {
                            return isCorrect;
                        }
                        
                        break;
                    case '*':
                        if (Regex.IsMatch(pattern[i + 1].ToString(), @"[$*+]")){
                            if(matchString.Substring(j, 3).Distinct().Count() == 1)
                            {
                                j = j + 3;
                            }
                            else
                            {
                                return isCorrect;
                            }
                        }
                        else
                        {
                            int.TryParse(pattern[i + 2].ToString(), out int result);
                            if (matchString.Substring(j, result).Distinct().Count() == 1)
                            {
                                j = j + 3;
                                i = i + 3;
                            }
                            else
                            {
                                return isCorrect;
                            }
                        }
                        
                        break;
                    default:
                        Console.WriteLine(pattern[i]);
                        return isCorrect;
                }
            }

            return true;
        }


        /// <summary>
        /// Class object to accept Json data
        /// </summary>
        public class DataObject
        {
            public string data { get; set; }
        }
        /// <summary>
        /// Get the age above 50 from the API call
        /// </summary>
        /// <param name="url">api url</param>
        public static async Task<int> GetAgeBove50(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("message", nameof(url));
            }
            int count = 0;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url);

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            //if success
            if (response.IsSuccessStatusCode)
            {
                
                var data = response.Content.ReadAsStringAsync().Result;

                var dataObjects = JsonConvert.DeserializeObject<DataObject>(data.ToString());

                Console.WriteLine("{0}", dataObjects.data);

                var dataValue =  dataObjects.data.Split(new string[] { "age=","key=",", "," ,"},StringSplitOptions.RemoveEmptyEntries);
                
                foreach(var value in dataValue)
                {
                    if(int.TryParse(value,out int result)){

                        if (result > 50)
                        {
                            count++;
                        }

                    }
                }
                Console.WriteLine("Total number of ages above 50 is : {0}", count);

            }
            
            return count;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMatchingParanthesis(string str)
        {

            int count = 0;
            if(str.Length == 0)
            {
                return false;
            }

            for(int i = 0; i < str.Length; i++)
            {

                if(str[i].Equals('('))
                {
                    count++;
                }
                else if(str[i].Equals(')'))
                {
                    count--;
                    if(count < 0)
                    {
                        return false;
                    }
                }
            }
            if(count == 0)
            {
                return true;
            }
            return false;
        }

    }
}
