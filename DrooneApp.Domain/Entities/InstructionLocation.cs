using System;
using System.Collections.Generic;
using DroneApp.Domain.Common;

namespace DroneApp.Domain.Entities
{
    public class InstructionLocation: Instruction
    {
        public List<Location> Locations { get; set; } = new();

        public InstructionLocation(string instruction)
        {
            InstructionString = instruction;
        }
        
        public override void ParseInstruction()
        {
            var item = InstructionString.Split(',');
            var element = item[0];
            if (element.StartsWith(StringConstants.Location))
            {
                var sections = element.Split(' ');
                if (sections.Length != 2 || string.IsNullOrWhiteSpace(sections[1]))
                {
                    throw new Exception(StringConstants.InvalidLocationName);
                }

                var locationName = sections[1];
                var packageWeigth = item[1];
                if (float.TryParse(packageWeigth, out float weigth))
                {
                    Locations.Add(new Location()
                    {
                        Name = locationName,
                        PackageWeight = weigth
                    });
                }
                else
                {
                    throw new Exception(StringConstants.InvalidPackageWeigth);
                }
            }
        }

        public override bool ValidateNumberOfItems()
        {
            var items = InstructionString.Split(',');
            if (items.Length == 2)
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

            var item = InstructionString.Split(',');
            var element = item[0];
            if (element.StartsWith(StringConstants.Location))
            {
                var packageWeigth = item[1];
                if (!float.TryParse(packageWeigth, out _))
                {
                    throw new Exception(StringConstants.InvalidPackageWeigth); ;
                }
            }

            return true;
        }
    }
}
