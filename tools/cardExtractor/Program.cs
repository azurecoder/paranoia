using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace cardExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = System.IO.Directory.GetFiles("input");
            Console.WriteLine($"Processing {files.Length} files");

            foreach (var file in files) {
                Console.WriteLine($"Processing {file}");
                
                using (var image = Image.Load(System.IO.File.OpenRead(file)))
                {
                    var image1 = image.Clone(x => x.Crop(new Rectangle { X = 128, Y = 96, Width = 788, Height = 1110 }));
                    image1.SaveAsJpeg(GetOutputPath(file, 1));

                    var image2 = image.Clone(x => x.Crop(new Rectangle { X = 128, Y = 1206, Width = 788, Height = 1110 }));
                    image2.SaveAsJpeg(GetOutputPath(file, 2));

                    var image3 = image.Clone(x => x.Crop(new Rectangle { X = 128, Y = 2316, Width = 788, Height = 1110 }));
                    image3.SaveAsJpeg(GetOutputPath(file, 3));
                }
            }
        }

        private static string GetOutputPath(string file, int ordinal)
        {
            return Path.Combine(Path.GetDirectoryName(file), "../output/", Path.GetFileNameWithoutExtension(file) + $".{ordinal}.jpg");
        }
    }
}
