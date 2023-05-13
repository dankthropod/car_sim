using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Engine {
    public double rpm_limit;
    public double torque;
    public double rpm;
    public double power;
	public double throttle;
	public double rpm_change_rate;
	
    public List<(double, double)> power_data = new List<(double, double)>();
    public List<(double, double)> torque_data = new List<(double, double)>();

    public Engine() {
		power_data = GetData(power_data, "data/rpm_power.csv");
		torque_data = GetData(torque_data, "data/rpm_torque.csv");

        power_data.Sort((x, y) => x.Item1.CompareTo(y.Item1));
		torque_data.Sort((x, y) => x.Item1.CompareTo(y.Item1));
    }

	public void Run() {
		
	}

	public List<(double, double)> GetData(List<(double,double)> data, String path) {
		using (var reader = new StreamReader(path)) {
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var values = line.Split(',');

                double x = double.Parse(values[0]); // declare and initialize rpm variable
                double y = double.Parse(values[1]); // declare and initialize power variable

                data.Add((x, y));
            }
        }
		return data;
	}

    public double GetDataForRPM(List<(double, double)> data, double rpm) {
        double x = 0.0;
        for (int i = 1; i < data.Count; i++) {
            if (data[i].Item1 > rpm) {
                double x1 = data[i - 1].Item1;
                double y1 = data[i - 1].Item2;
                double x2 = data[i].Item1;
                double y2 = data[i].Item2;

                x = y1 + (y2 - y1) * ((rpm - x1) / (x2 - x1));
                break;
            }
        }
        return x;
    }
}
