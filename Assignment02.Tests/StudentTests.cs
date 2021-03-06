using System;
using Xunit;

namespace Assignment02.Tests
{

  public class StatusTests {

    [Fact]
    public void ShouldBeANewStudent() {
      // Arrange
      Student student = generateActiveStudent(2021, 8);
      Status expected = Status.NEW;
      
      // Act
      Status actual = student.Status;

      // Assert
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2019, 2)]
    [InlineData(2019, 8)]
    [InlineData(2020, 3)]
    [InlineData(2020, 8)]
    public void ShouldBeAnActiveStudent(int year, int month) {
      // Arrange
      Student student = generateActiveStudent(year, month);
      Status expected = Status.ACTIVE;
      
      // Act
      Status actual = student.Status;

      // Assert
      Assert.Equal(expected, actual);
    }

    private Student generateActiveStudent(int year, int month) {
      Student s = new Student(0);
      s.StartDate = new DateTime(year, month, 15);
      DateTime grad = new DateTime( year + 3, ((month + 8) % 11) + 1, 15);
      s.GraduationDate = grad;
      s.EndDate = grad;
      return s;
    }

    [Theory]
    [InlineData(2019, 2)]
    [InlineData(2019, 8)]
    [InlineData(2020, 4)]
    public void ShouldBeADropoutStudent(int year, int month) {
      // Arrange
      Student student = generateDropoutStudent(year, month);
      Status expected = Status.DROPOUT;
      
      // Act
      Status actual = student.Status;

      // Assert
      Assert.Equal(expected, actual);
    }

    private Student generateDropoutStudent(int year, int month) {
      Student s = new Student(0);
      s.StartDate = new DateTime(year, month, 15);
      s.GraduationDate = new DateTime( year + 3, ((month + 8) % 11) + 1, 4);
      s.EndDate = new DateTime(year + 1, month, 04);
      return s;
    }

  }


  public class StudentTests {


    [Theory]
    [InlineData(
      "#4 - Doe, John: Dropout (2020 - 2021)",
      4,
      "John", "Doe",
      2020, 09, 10,
      2021, 09, 10,
      true
    )]
    [InlineData(
      "#5 - Doe, Jane: Active (2019 - 2022)",
      5,
      "Jane", "Doe",
      2019, 09, 10,
      2022, 09, 10,
      false
    )]
    [InlineData(
      "#7 - G, Young: New (2021 - 2024)",
      7,
      "Young", "G",
      2021, 09, 10,
      2024, 09, 10,
      false
    )]
    [InlineData(
      "#7 - G, Original: Graduated (2000 - 2003)",
      7,
      "Original", "G",
      2000, 09, 10,
      2003, 09, 10,
      false
    )]
    public void GeneratesCorrectToString(string studentString, int id, string givenName, string surname, int sy, int sm, int sd, int ey, int em, int ed, bool isDropout) {
      // Arrange 
      string expected = studentString;

      DateTime start = new DateTime(sy, sm, sd); 
      DateTime end = new DateTime(ey, em, ed); 

      Student s = new Student(id);
      s.GivenName = givenName;
      s.Surname = surname;
      s.StartDate = start;
      s.GraduationDate = start.AddYears(3);
      s.EndDate = isDropout ? end : s.GraduationDate;

      // Act
      string actual = s.ToString();
      
      // Assert
      Assert.Equal(expected, actual);
    }
    

  }

}