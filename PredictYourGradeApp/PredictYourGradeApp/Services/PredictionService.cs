using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PredictYourGradeApp.Helpers;
using PredictYourGradeApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PredictYourGradeApp.Services
{
    public static class PredictionService
    {
        public async static Task<double> PredictGrade(Student student)
        {
            try
            {
                var inputs = new
                {
                    Inputs = new Dictionary<string, StringTable>()
                    {
                        {
                            "input1",
                                new StringTable()
                                {
                                    ColumnNames = new string[] 
                                    {
                                        "sex",
                                        "traveltime",
                                        "studytime",
                                        "internet",
                                        "G1",
                                        "G2",
                                        "G3"
                                    },
                                    Values = new string[,] 
                                    {  
                                        {
                                            student.Sex.ToString(),
                                            student.TravelTime.ToString(),
                                            student.StudyTime.ToString(),
                                            student.Internet.ToString(),
                                            student.G1.ToString(),
                                            student.G2.ToString(),
                                            student.G3.ToString()
                                        }
                                    }
                                }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                var json = JsonConvert.SerializeObject(inputs);

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new
                        AuthenticationHeaderValue("Bearer", Constants.PredictionKey);
                    client.BaseAddress = new Uri(Constants.PredictionURL);

                    var content = new StringContent(json);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync("", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var prediction = JsonConvert.DeserializeObject<Prediction>(result);

                        return double.Parse(prediction.Results.output1.value.Values[0][0]);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}