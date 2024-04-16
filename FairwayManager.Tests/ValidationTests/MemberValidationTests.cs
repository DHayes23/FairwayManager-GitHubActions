using FairwayManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

public class MemberTests
{
    [Theory]
    [InlineData(null)]  // Expect fail for null
    [InlineData("")]    // Expect fail for empty
    [InlineData("A")]   // Expect fail for too short
    [InlineData("ThisNameIsWayTooLongAndShouldFailValidationCheck")]  // Expect fail for too long
    public void Member_Name_Validation_Should_Fail_When_OutOfRange(string name)
    {
        // Arrange
        var member = new Member { Name = name };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(member, new ValidationContext(member), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.MemberNames.Contains("Name"));
    }

    [Fact]
    public void Member_Name_Validation_Should_Pass_When_Valid()
    {
        // Arrange
        var member = new Member { Name = "Valid Name" };

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(member, new ValidationContext(member), validationResults, true);

        // Assert
        Assert.True(isValid);
    }
}
