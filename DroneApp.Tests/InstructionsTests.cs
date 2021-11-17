using System;
using Xunit;
using DroneApp.Domain.DomainServices.Contracts;
using DrooneApp.Domain.DomainServices;
using DroneApp.Domain.Enums;
using DroneApp.Domain.Common;
using DroneApp.Domain.Entities;

namespace DroneApp.Tests
{
    public class InstructionsTests
    {
        private IInstructionService _instructionService;

        public InstructionsTests()
        {
            _instructionService = new InstructionService();
        }

        #region Drone tests
        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionIsDrone()
        {
            //Arrange
            var instructionString = "Drone Name, 90";

            //Act
            var result = _instructionService.GetIntructiontype(instructionString);

            //Assert
            Assert.Equal(InstructionType.Drone, result);
        }

        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionDroneIsIncomplete()
        {
            //Arrange
            var instructionString = "Dron Name";

            //Act
            Action act = () => _instructionService.GetIntructiontype(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionLocationIsIncomplete()
        {
            //Arrange
            var instructionString = "Dron Name";

            //Act
            Action act = () => _instructionService.GetIntructiontype(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionDroneIsInvalid()
        {
            //Arrange
            var instructionString = "Dron Name, 90";

            //Act
            Action act = () => _instructionService.GetIntructiontype(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidInstruction, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionDrone()
        {
            //Arrange
            var instructionString = "Drone A, 90";

            //Act
            var result = _instructionService.ParseInstruction(instructionString);

            //Assert
            Assert.IsType<IntructionDrone>(result);
        }

        [Fact]
        public void ShouldParseInstructionDroneWhenInstructionIsEmpty()
        {
            //Arrange
            var instructionString = string.Empty;

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionDroneWhenInstructionIncomplete()
        {
            //Arrange
            var instructionString = "Drone,90";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionDroneWhenWeigthIsIncorrect()
        {
            //Arrange
            var instructionString = "Drone A,X";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidDroneWeigth, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionDroneWhenDroneNameIsIncomplete()
        {
            //Arrange
            var instructionString = "Drone ,90";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidDroneName, exception.Message);
        }
        #endregion

        #region Location Tests
        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionIsLocation()
        {
            //Arrange
            var instructionString = "Location Name, 90";

            //Act
            var result = _instructionService.GetIntructiontype(instructionString);

            //Assert
            Assert.Equal(InstructionType.Location, result);
        }

        [Fact]
        public void ShouldGetInstructionTypeWhenInstructionLocationIsInvalid()
        {
            //Arrange
            var instructionString = "Locations Name, 90";

            //Act
            Action act = () => _instructionService.GetIntructiontype(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidInstruction, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionLocation()
        {
            //Arrange
            var instructionString = "Location A, 10";

            //Act
            var result = _instructionService.ParseInstruction(instructionString);

            //Assert
            Assert.IsType<InstructionLocation>(result);
        }

        [Fact]
        public void ShouldParseInstructionLocationWhenInstructionIsEmpty()
        {
            //Arrange
            var instructionString = string.Empty;

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionLocationWhenInstructionIncomplete()
        {
            //Arrange
            var instructionString = "Location,10";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidNumberOfItems, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionLocationWhenWeigthIsIncorrect()
        {
            //Arrange
            var instructionString = "Location A,X";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidPackageWeigth, exception.Message);
        }

        [Fact]
        public void ShouldParseInstructionLocationWhenDroneNameIsIncomplete()
        {
            //Arrange
            var instructionString = "Location ,90";

            //Act
            Action act = () => _instructionService.ParseInstruction(instructionString);

            //assert
            var exception = Assert.Throws<Exception>(act);
            Assert.Equal(StringConstants.InvalidLocationName, exception.Message);
        }
        #endregion Location Tests
    }
}
