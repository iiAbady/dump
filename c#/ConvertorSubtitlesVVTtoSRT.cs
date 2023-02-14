using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConvertorSubtitlesVVTtoSRT
{
    class Program
    {


        static void Main(string[] args)
        {
            string[] dirs = Directory.GetDirectories(@"C:\Users\asus\Desktop\old");
            for (int i = 0; i < dirs.Length; i++)
            {
                string[] files = Directory.GetFiles(dirs[i]);
                var filiterdFiles = files.Where(item => item.EndsWith("vtt"));
                foreach (var file in filiterdFiles)
                {
                    Console.WriteLine($"Translating {file}...");
                    List<string> lines = new List<string>();
                    lines = File.ReadAllLines(file).ToList();
                    if (lines.Count < 2)
                        continue;
                    lines.RemoveRange(0, 2);
                    for (int j = 0; j < lines.Count; j++)
                    {
                        if (j >= lines.Count)
                            break;

                        try
                        {
                            lines[j] = (int.Parse(lines[j]) + 1).ToString();
                        }
                        catch (FormatException)
                        {
                            lines.Insert(j, j == 0 ? "1" : (j / 2).ToString());
                        }
                        try
                        {
                            int indx = lines[j + 1].IndexOf("-->");
                            string first_timestamp = "00:" + lines[j + 1].Substring(0, lines[j + 1].IndexOf("-->") - 1).Replace('.', ',');
                            string second_timestamp = "00:" + lines[j + 1].Substring(lines[j + 1].IndexOf("-->") + 4).Replace('.', ',');
                            lines[j + 1] = first_timestamp + " --> " + second_timestamp;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine(lines[j + 1]);
                            Environment.Exit(1);
                        }

                        j += 3;
                    }
                    File.Create(file.Substring(0, file.Length - 4) + ".srt").Close();
                    File.WriteAllLines(file.Substring(0, file.Length - 4) + ".srt", lines);
                    Console.WriteLine($"Finished translating {file}");
                }
            }
        }
    }
