using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Transmission
{
    public Gear[] gears;
    public List<double> ratio_data = new List<double>();

    public Transmission()
    {
        ratio_data = GetData(ratio_data, "data/gear_ratio.csv"); // 0 is reverse

        gears = new Gear[ratio_data.Count];

        for (int gearIndex = 0; gearIndex < gears.Length; gearIndex++)
        {
            gears[gearIndex] = new Gear(); // Create instance of Gear before accessing its properties
            gears[gearIndex].ratio = ratio_data[gearIndex];
        }
    }

    public double GetDriveshaftSpeed(double rpm, Gear gear)
    {
        return rpm / gear.ratio;
    }

    public List<double> GetData(List<double> data, string path)
    {
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                double x = double.Parse(values[0]);

                data.Add(x);
            }
        }
        return data;
    }
}