using System;
using Xunit;

namespace Assignment02.Tests
{

  public class ImmutableStatusTests
  {

    private ImmutableStudent getImmutableStudent(int id) {
      if (id == 0) {
        return new ImmutableStudent
        (
          id,
          "John", "Doe",
          Status.GRADUATED,
          new DateTime(2003, 11, 21),
          new DateTime(2006, 10, 13),
          new DateTime(2006, 10, 13)
        );
      } else {
        return new ImmutableStudent
        (
          id,
          "Jane", "Doe",
          Status.ACTIVE,
          new DateTime(2020, 10, 21),
          new DateTime(2024, 11, 13),
          new DateTime(2024, 11, 13)
        );
      }
    }

    [Theory]
    [InlineData(0, 0)] // a == a
    [InlineData(1, 1)] // b == b
    public void ShouldEqual(int id0, int id1) {
      // Arrange
      ImmutableStudent a = getImmutableStudent(id0);
      ImmutableStudent b = getImmutableStudent(id1);

      // Act
      bool actual = a.Equals(b);

      // Assert
      Assert.True(actual);
    }

    [Theory]
    [InlineData(0, 1)] // a != b
    [InlineData(1, 0)] // b != a
    public void ShouldNotEqual(int id0, int id1)
    {
      // Arrange
      ImmutableStudent a = getImmutableStudent(id0);
      ImmutableStudent b = getImmutableStudent(id1);

      // Act
      bool actual = a.Equals(b);

      // Assert
      Assert.False(actual);
    }


    [Theory]
    [InlineData(
      0,
      "ImmutableStudent { Id = 0, GivenName = John, Surname = Doe, Status = GRADUATED, StartDate = 11/21/2003 12:00:00 AM, GraduationDate = 10/13/2006 12:00:00 AM, EndDate = 10/13/2006 12:00:00 AM }"
    )]
    [InlineData(
      1,
      "ImmutableStudent { Id = 1, GivenName = Jane, Surname = Doe, Status = ACTIVE, StartDate = 10/21/2020 12:00:00 AM, GraduationDate = 11/13/2024 12:00:00 AM, EndDate = 11/13/2024 12:00:00 AM }"
    )]
    public void HasCorrectToString(int id, string input)
    {
      // Arrange
      string expected = input;
      ImmutableStudent a = getImmutableStudent(id);

      // Act
      string actual = a.ToString();
      
      // Assert
      Assert.Equal(expected, actual);
    }
  }
}