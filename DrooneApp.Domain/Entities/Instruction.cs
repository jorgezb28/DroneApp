namespace DroneApp.Domain.Entities
{
    public abstract class Instruction
    {
        protected string InstructionString { get; set; }

        public abstract bool ValidInstruction();

        public abstract void ParseInstruction();

        public abstract bool ValidateNumberOfItems();
    }
}
