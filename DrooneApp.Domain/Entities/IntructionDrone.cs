using System;
using System.Collections.Generic;
using DroneApp.Domain.Common;

namespace DroneApp.Domain.Entities
{
    public class IntructionDrone: Instruction
    {
        public List<Drone> Drones { get; set; } = new();

        public IntructionDrone(string instruction)
        {
            InstructionString = instruction;
        }

        public override void ParseInstruction()
        {
            var items = InstructionString.Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                var element = items[i];
                if (element.StartsWith(StringConstants.Drone))
                {
                    var sections = element.Split(' ');
                    if (sections.Length != 2 || string.IsNullOrWhiteSpace(sections[1]))
                    {
                        throw new Exception(StringConstants.InvalidDroneName);
                    }

                    var droneName = sections[1];

                    var droneWeigth = items[i + 1];
                    if (float.TryParse(droneWeigth, out float weigth))
                    {
                        Drones.Add(new Drone()
                        {
                            Name = droneName,
                            MaxWeightCapacity = weigth
                        });
                    }
                    else
                    {
                        throw new Exception(StringConstants.InvalidDroneWeigth);
                    }
                }
            }
        }

        public override bool ValidateNumberOfItems()
        {
            var items = InstructionString.Split(',');
            if (items.Length >= 2)
            {
                return true;
            }
            return false;
        }

        public override bool ValidInstruction()
        {
            if (string.IsNullOrWhiteSpace(InstructionString))
            {
                throw new Exception(StringConstants.EmptyInstruction);
            }

            if (!ValidateNumberOfItems())
            {
                throw new Exception(StringConstants.InvalidNumberOfItems);
            }

            var items = InstructionString.Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                var element = items[i];
                if (element.StartsWith(StringConstants.Drone))
                {
                    var droneWeigth = items[i + 1];
                    if (float.TryParse(droneWeigth, out _))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        throw new Exception(StringConstants.InvalidDroneWeigth);
                    }
                }
            }

            return true;
        }
    }
}
