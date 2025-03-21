using System;
using System.Collections.Generic;
using LibreHardwareMonitor.Hardware;

namespace Strayacoin_Miner_v0._06a
{
    public class ohm_lib : IDisposable
    {
        private readonly Computer _computer;
        private readonly UpdateVisitor _updateVisitor;

        public ohm_lib()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true
            };
            _updateVisitor = new UpdateVisitor();
            _computer.Open();
        }

        public void Update()
        {
            _computer.Accept(_updateVisitor);
        }

        public List<CpuInfo> GetCpuInfo()
        {
            var cpuInfoList = new List<CpuInfo>();

            foreach (IHardware hardware in _computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();
                    var cpuInfo = new CpuInfo
                    {
                        Name = hardware.Name,
                        Sensors = new List<SensorInfo>()
                    };

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature || sensor.SensorType == SensorType.Load)
                        {
                            var sensorInfo = new SensorInfo
                            {
                                Name = sensor.Name,
                                Value = sensor.Value.HasValue ? sensor.Value.Value : (float?)null
                            };
                            cpuInfo.Sensors.Add(sensorInfo);
                        }
                    }

                    cpuInfoList.Add(cpuInfo);
                }
            }

            return cpuInfoList;
        }

        public List<SensorInfo> GetCoreTemperatures()
        {
            var coreTemperatures = new List<SensorInfo>();

            foreach (IHardware hardware in _computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Core"))
                        {
                            var sensorInfo = new SensorInfo
                            {
                                Name = sensor.Name,
                                Value = sensor.Value.HasValue ? sensor.Value.Value : (float?)null
                            };
                            coreTemperatures.Add(sensorInfo);
                        }
                    }
                }
            }

            return coreTemperatures;
        }

        public List<SensorInfo> GetCoreLoads()
        {
            var coreLoads = new List<SensorInfo>();

            foreach (IHardware hardware in _computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("Core"))
                        {
                            var sensorInfo = new SensorInfo
                            {
                                Name = sensor.Name,
                                Value = sensor.Value.HasValue ? sensor.Value.Value : (float?)null
                            };
                            coreLoads.Add(sensorInfo);
                        }
                    }
                }
            }

            return coreLoads;
        }

        public SensorInfo GetCpuPackageTemperature()
        {
            foreach (IHardware hardware in _computer.Hardware)
            {
                if (hardware.HardwareType == HardwareType.Cpu)
                {
                    hardware.Update();

                    foreach (ISensor sensor in hardware.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("Package"))
                        {
                            return new SensorInfo
                            {
                                Name = sensor.Name,
                                Value = sensor.Value.HasValue ? sensor.Value.Value : (float?)null
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void Dispose()
        {
            _computer.Close();
        }
    }

    public class CpuInfo
    {
        public string Name { get; set; }
        public List<SensorInfo> Sensors { get; set; }
    }

    public class SensorInfo
    {
        public string Name { get; set; }
        public float? Value { get; set; }
    }

    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware)
            {
                subHardware.Accept(this);
            }
        }

        public void VisitSensor(ISensor sensor) { }
        public void VisitParameter(IParameter parameter) { }
    }
}
