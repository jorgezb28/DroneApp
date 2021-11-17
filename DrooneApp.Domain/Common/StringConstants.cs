namespace DroneApp.Domain.Common
{
    public static class StringConstants
    {
        public static string Drone = "Drone";
        public static string Location = "Location";

        #region Error Messages

        public static string InvalidNumberOfItems = "Invalid number of minimun items for this instruction";
        public static string InvalidInstruction = "Invalid Instruction element";
        public static string EmptyInstruction = "Empty provided Instruction";
        public static string InvalidDroneWeigth = "Invalid Drone Weigth in provided instruction";
        public static string MaxDronesAllowed="Max number of drones in squad is 100";
        public static string InvalidDroneName="Invalid Drone name in provided instruction";
        public static string InvalidPackageWeigth = "Invalid Location Package Weigth in provided instruction";
        public static string InvalidLocationName = "Invalid Location name in provided instruction";
        public static string PackageTooBig="There is package bigger than drones max capacity";

        #endregion
    }
}
