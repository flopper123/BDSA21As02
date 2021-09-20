using System;

namespace Assignment02
{

  public record ImmutableStudent
  {
    
    public ImmutableStudent(
        int id,
        string givenName,
        string surname,
        Status status,
        DateTime startDate,
        DateTime graduationDate,
        DateTime endDate
      ) => (Id, GivenName, Surname, Status, StartDate, GraduationDate, EndDate)
        =  (id, givenName, surname, status, startDate, graduationDate, endDate);

    public int Id { get; init; }
    public string GivenName { get; init; }
    public string Surname { get; init; }
    public Status Status { get; init; }
    public DateTime StartDate { get; init; }

    public DateTime GraduationDate { get; init; }
    public DateTime EndDate { get; init; }

  }


}