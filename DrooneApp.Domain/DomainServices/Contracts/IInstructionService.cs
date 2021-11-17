using DroneApp.Domain.Entities;
using DroneApp.Domain.Enums;

namespace DroneApp.Domain.DomainServices.Contracts
{
    public interface IInstructionService
    {
        /// <summary>
        /// Get the instruction type given a string instruction
        /// </summary>
        /// <param name="instruction">String instrucntion</param>
        /// <returns>InstructionType Drone or Location</returns>
        InstructionType GetIntructiontype(string instruction);

        /// <summary>
        /// Parse instruction string and returns the respective Drone or Location object
        /// </summary>
        /// <param name="instruction">Instruction String</param>
        /// <returns>Drone or Location object</returns>
        Instruction ParseInstruction(string instruction);
    }
}
