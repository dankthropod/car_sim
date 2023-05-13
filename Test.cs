using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;

static class Test {
	public static void RPMTest(Engine engine) {
		List<double> rpm_list = new List<double>();
		List<double> power_list = new List<double>();
		List<double> torque_list = new List<double>();
		
		foreach (float value in Enumerable.Range(10,80)) {
			engine.rpm = value*100;
			
			engine.power = engine.GetDataForRPM(engine.power_data, engine.rpm);
			engine.torque = engine.GetDataForRPM(engine.torque_data, engine.rpm);

			rpm_list.Add(engine.rpm);
			power_list.Add(engine.power);
			torque_list.Add(engine.torque);
		}

		double[] rpm_array = rpm_list.Select(x => (double)x).ToArray();
		double[] power_array = power_list.Select(x => (double)x).ToArray();
		double[] torque_array = torque_list.Select(x => (double)x).ToArray();

		try {
			var plt_power = new ScottPlot.Plot(400, 300);
			plt_power.AddScatter(rpm_array, power_array);
			plt_power.SaveFig("Tests/PowerTest.png");

			var plt_torque = new ScottPlot.Plot(400,300);
			plt_torque.AddScatter(rpm_array, torque_array);
			plt_torque.SaveFig("Tets/TorqueTest.png");
		}

		catch (System.Exception) {
			Console.WriteLine("Is libgdiplus missing?");
		}
	}
}