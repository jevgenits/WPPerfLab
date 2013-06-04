using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Linq;
using Microsoft.Phone.Controls;
using WPPerfLab.Common.Entities;
using WPPerfLab.Common.Serialization;
using WPPerfLab.Common.Serialization.Binary;
using WPPerfLab.Common.Serialization.DataContract;
using WPPerfLab.Common.Serialization.DataContractJSON;
using WPPerfLab.Common.Serialization.XML;

namespace WPPerfLab.Samples.SerializationSamples
{
    public partial class SerializationSamplesPage : PhoneApplicationPage
    {
        Stopwatch sw = new Stopwatch();

        public SerializationSamplesPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var product = ProductRepository.GetProduct(numberOfKeys: 10000);

            // skip first execution for each test
            ExecuteSerializationTests(new BinarySerializationHelper(), product, 1);
            ExecuteSerializationTests(new DataContractSerializationHelper(), product, 1);
            ExecuteSerializationTests(new DataContractJsonSerializationHelper(), product, 1);
            ExecuteSerializationTests(new XMLSerializerHelper(), product, 1);

            const int numberOfTimes = 10;

            Debug.WriteLine("Running binary serialization tests");
            var binaryResults = ExecuteSerializationTests(new BinarySerializationHelper(), product, numberOfTimes);
            OutputResults(binaryResults);

            Debug.WriteLine("Running data contract serialization tests");
            var dataContactResults = ExecuteSerializationTests(new DataContractSerializationHelper(), product, numberOfTimes);
            OutputResults(dataContactResults);

            Debug.WriteLine("Running data contract JSON serialization tests");
            var dataContactJSONResults = ExecuteSerializationTests(new DataContractJsonSerializationHelper(), product, numberOfTimes);
            OutputResults(dataContactJSONResults);

            Debug.WriteLine("Running XML serialization tests");
            var xmlResults = ExecuteSerializationTests(new XMLSerializerHelper(), product, numberOfTimes);
            OutputResults(xmlResults);

            Debug.WriteLine("Tests have been executed!");
        }

        private void OutputResults(List<Tuple<long, double, double>> results)
        {
            if (results != null)
            {
                Debug.WriteLine("Size(bytes); Serialization time(ms); Deserialization time(ms)");
                foreach (var result in results)
                {
                    Debug.WriteLine(string.Format("{0};{1};{2}", result.Item1, result.Item2, result.Item3));
                }
                var averageFileSize = results.Average(r => r.Item1);
                var averageSerializationTime = results.Average(r => r.Item2);
                var averageDeserializationTime = results.Average(r => r.Item3);
                Debug.WriteLine("Average:");
                Debug.WriteLine(string.Format("{0};{1};{2}", averageFileSize, averageSerializationTime, averageDeserializationTime));
            }
        }

        private List<Tuple<long, double, double>> ExecuteSerializationTests(ISerializationHelper serializationHelper, ProductEntity product, int numberOfTimes)
        {
            var allResults = new List<Tuple<long, double, double>>();
            for (int i = 0; i < numberOfTimes; i++)
            {
                using (var memoryStream = new MemoryStream())
                {
                    // serialization
                    sw.Reset();
                    sw.Start();
                    serializationHelper.Serialize(memoryStream, product);
                    sw.Stop();
                    var serializationTime = sw.ElapsedMilliseconds;

                    // get size in bytes
                    var size = memoryStream.Length;

                    // reset position of stream
                    memoryStream.Position = 0;
                    
                    // deserialization
                    sw.Reset();
                    sw.Start();
                    var o = serializationHelper.Deserialize(memoryStream, typeof(ProductEntity));
                    sw.Stop();
                    var deserializationTime = sw.ElapsedMilliseconds;

                    allResults.Add(new Tuple<long, double, double>(size, serializationTime, deserializationTime));

                    memoryStream.Close();
                }
            }
            return allResults;
        } 
    }
}