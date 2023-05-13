using System;
using System.Collections.Generic;
using System.IO;

class Program {
  	static void Main(string[] args) {
        // create a new Engine instance to call GetDataForRPM on
        Engine engine = new Engine();

		Test.RPMTest(engine);
        // engine.power = engine.GetDataForRPM(power_data, engine.rpm); // call method using instance
        // Console.WriteLine($"Power at {engine.rpm} RPM: {engine.power}");
	}
}
