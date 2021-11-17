using System;
using DroneApp.Domain.Common;
using DroneApp.Domain.DomainServices.Contracts;
using DroneApp.Domain.Entities;
using DroneApp.Domain.Enums;

namespace DrooneApp.Domain.DomainServices
{
    public class InstructionService: IInstructionService
    {
        /// <inheritdoc/>
        public InstructionType GetIntructiontype(string instruction)
        {
            var instructionArray = instruction.Split(',');
            if (instructionArray.Length <= 1)
            {
                throw new Exception(StringConstants.InvalidNumberOfItems);
            }

            var firstItem = instructionArray[0];
            var items = firstItem.Split(' ');
            var type = items[0];

            if (items.Length != 2)
            {
                throw new Exception(StringConstants.InvalidNumberOfItems);
            }

            if (type ==StringConstants.Drone)
            {
                return InstructionType.Drone;
            }

            if (type == StringConstants.Location)
            {
                return InstructionType.Location;
            }

            throw new Exception(StringConstants.InvalidInstruction);
        }

        /// <inheritdoc/>
        public Instruction ParseInstruction(string instruction)
        {
            var instructionType = GetIntructiontype(instruction);
            if (instructionType == InstructionType.Drone)
            {
                var droneInstruction = new IntructionDrone(instruction);
                if (droneInstruction.ValidInstruction())
                {
                    droneInstruction.ParseInstruction();
                }

                if (droneInstruction.Drones.Count >= 100)
                {
                    throw new Exception(StringConstants.MaxDronesAllowed);
                }
                return droneInstruction;
            }

            if (instructionType == InstructionType.Location)
            {
                var droneInstruction = new InstructionLocation(instruction);
                if (droneInstruction.ValidInstruction())
                {

                }
                droneInstruction.ParseInstruction();
                return droneInstruction;
            }

            throw new Exception(StringConstants.InvalidInstruction);
        }
    }
}
